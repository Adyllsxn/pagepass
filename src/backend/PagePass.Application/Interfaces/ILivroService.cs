namespace PagePass.Application.Interfaces
{
    public interface ILivroService
    {
        Task<LivroDTO> IncluirAsync(LivroDTO livroDTO);
        Task<LivroDTO> AlterarAsync(LivroDTO livroDTO);
        Task<LivroDTO> ExcluirAsync(int id);
        Task<LivroDTO> SelecionarAsync(int id);
        Task<PagedList<LivroDTO>> SelecionarTodosAsync(int pageNumber, int pageSize);
    }
}