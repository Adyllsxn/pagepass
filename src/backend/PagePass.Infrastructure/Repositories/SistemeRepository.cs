
namespace PagePass.Infrastructure.Repositories
{
    public class SistemeRepository : ISistemeRepository
    {
        private readonly AppDbContext _context;
        public SistemeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<QuantidadeItensEntity> SelecionarQtdItems()
        {
            QuantidadeItensEntity quantidadeItens =  new  QuantidadeItensEntity();
            quantidadeItens.QtdLivro = await _context.Livros.CountAsync();
            quantidadeItens.QtdCliente = await _context.Clientes.CountAsync();
            quantidadeItens.QtdEmprestimo = await _context.Emprestimos.CountAsync();
            return quantidadeItens;
        }
    }
}