namespace PagePass.Domain.Interfaces
{
    public interface IEmprestimoRepository
    {
        Task<EmprestimoEntity> IncluirAsync(EmprestimoEntity emprestimo);
        Task<EmprestimoEntity> AlterarAsync(EmprestimoEntity emprestimo);
        Task<EmprestimoEntity?> ExcluirAsync(int id);
        Task<EmprestimoEntity?> SelecionarAsync(int id);
        Task<PagedList<EmprestimoEntity>> SelecionarTodosAsync(int pageNumber, int pageSize);
        Task<bool> VerificaDisponibilidade(int idLivro);
    }
}