namespace PagePass.Domain.Interfaces
{
    public interface ILivroRepository
    {
        Task<LivroEntity> IncluirAsync(LivroEntity livro);
        Task<LivroEntity> AlterarAsync(LivroEntity livro);
        Task<LivroEntity?> ExcluirAsync(int id);
        Task<LivroEntity?> SelecionarAsync(int id);
        Task<PagedList<LivroEntity>> SelecionarTodosAsync(int pageNumber, int pageSize);
    }
}