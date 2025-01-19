namespace PagePass.Application.Interfaces
{
    public interface IEmprestimoService
    {
        Task<EmprestimoDTO> IncluirAsync(EmprestimoPostDTO emprestimoPostDTO);
        Task<EmprestimoDTO> AlterarAsync(EmprestimoDTO emprestimoDTO);
        Task<EmprestimoDTO> ExcluirAsync(int id);
        Task<EmprestimoDTO> SelecionarAsync(int id);
        Task<bool> VerificaDisponibilidade(int idLivro);
        Task<PagedList<EmprestimoDTO>> SelecionarTodosAsync(int pageNumber, int pageSize);
    }
}