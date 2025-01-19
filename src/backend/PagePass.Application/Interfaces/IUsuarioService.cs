namespace PagePass.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> IncluirAsync(UsuarioDTO usuarioDTO);
        Task<UsuarioDTO> AlterarAsync(UsuarioDTO usuarioDTO);
        Task<UsuarioDTO> ExcluirAsync(int id);
        Task<UsuarioDTO> SelecionarAsync(int id);
        Task<bool> ExisteUsuarioCadastradoAsyn();
        Task<PagedList<UsuarioDTO>> SelecionarTodosAsync(int pageNumber, int pageSize);
    }
}