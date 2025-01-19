

namespace PagePass.Infrastructure.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly AppDbContext _context;
        public EmprestimoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<EmprestimoEntity> AlterarAsync(EmprestimoEntity emprestimo)
        {
            try
            {
                _context.Emprestimos.Update(emprestimo);
                await _context.SaveChangesAsync();  
                return emprestimo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EmprestimoEntity?> ExcluirAsync(int id)
        {
            try
            {
                var emprestimo = await _context.Emprestimos.FindAsync(id);
                if (emprestimo != null)
                {
                    _context.Emprestimos.Remove(emprestimo);
                    await _context.SaveChangesAsync();
                }
                return emprestimo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EmprestimoEntity> IncluirAsync(EmprestimoEntity emprestimo)
        {
            try
            {
                await _context.Emprestimos.AddAsync(emprestimo);
                await _context.SaveChangesAsync();
                return emprestimo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EmprestimoEntity?> SelecionarAsync(int id)
        {
            try
            {
                return await _context.Emprestimos.AsNoTracking().Include(x => x.Cliente).Include(x => x.Livro).FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<PagedList<EmprestimoEntity>> SelecionarTodosAsync(int pageNumber, int pageSize)
        {
            try
            {
                var query = _context.Emprestimos.AsQueryable().AsNoTracking().Include(x => x.Cliente).Include(x => x.Livro);
                return await PaginationHelper.CreateAsync(query,pageNumber, pageSize);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> VerificaDisponibilidade(int idLivro)
        {
            try
            {
                var existeEmprestimo = await _context.Emprestimos.Where(x => x.IdLivro == idLivro && x.Entrega == false).AnyAsync();
                return !existeEmprestimo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}