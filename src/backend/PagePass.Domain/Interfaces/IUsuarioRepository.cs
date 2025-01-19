namespace PagePass.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<UsuarioEntity> IncluirAsync(UsuarioEntity usuario);
        Task<UsuarioEntity> AlterarAsync(UsuarioEntity usuario);
        Task<UsuarioEntity?> ExcluirAsync(int id);
        Task<UsuarioEntity?> SelecionarAsync(int id);
        Task<bool> ExisteUsuarioCadastradoAsyn();
        Task<PagedList<UsuarioEntity>> SelecionarTodosAsync(int pageNumber, int pageSize);
    }
}