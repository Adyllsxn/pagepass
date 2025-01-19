

namespace PagePass.Infrastructure.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly AppDbContext _context;
        public LivroRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<LivroEntity> AlterarAsync(LivroEntity livro)
        {
            try
            {
                _context.Livros.Update(livro);
                await _context.SaveChangesAsync();  
                return livro;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LivroEntity?> ExcluirAsync(int id)
        {
            try
            {
                var livro = await _context.Livros.FindAsync(id);
                if (livro != null)
                {
                    _context.Livros.Remove(livro);
                    await _context.SaveChangesAsync();
                }
                return livro;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LivroEntity> IncluirAsync(LivroEntity livro)
        {
            try
            {
                await _context.Livros.AddAsync(livro);
                await _context.SaveChangesAsync();
                return livro;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LivroEntity?> SelecionarAsync(int id)
        {
            try
            {
                return await _context.Livros.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PagedList<LivroEntity>> SelecionarTodosAsync(int pageNumber, int pageSize)
        {
            try
            {
                var query = _context.Livros.AsQueryable();
                return await PaginationHelper.CreateAsync(query,pageNumber, pageSize);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}