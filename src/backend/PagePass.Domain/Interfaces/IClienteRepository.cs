

namespace PagePass.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<ClienteEntity> IncluirAsync(ClienteEntity cliente);
        Task<ClienteEntity> AlterarAsync(ClienteEntity cliente);
        Task<ClienteEntity?> ExcluirAsync(int id);
        Task<ClienteEntity?> SelecionarAsync(int id);
        Task<PagedList<ClienteEntity>> SelecionarTodosAsync(int pageNumber, int pageSize);
    } 
}