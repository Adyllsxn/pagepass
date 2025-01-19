namespace PagePass.Application.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteDTO> IncluirAsync(ClienteDTO clienteDto);
        Task<ClienteDTO> AlterarAsync(ClienteDTO clienteDto);
        Task<ClienteDTO> ExcluirAsync(int id);
        Task<ClienteDTO> SelecionarAsync(int id);
        Task<PagedList<ClienteDTO>> SelecionarTodosAsync(int pageNumber, int pageSize);

    }
}