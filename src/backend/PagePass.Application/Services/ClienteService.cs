namespace PagePass.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;
        public ClienteService(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<ClienteDTO> AlterarAsync(ClienteDTO clienteDto)
        {
            try
            {
                var cliente = _mapper.Map<ClienteEntity>(clienteDto);
                var clienteAlterado = await _repository.AlterarAsync(cliente);
                return _mapper.Map<ClienteDTO>(clienteAlterado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<ClienteDTO> ExcluirAsync(int id)
        {
            try
            {
                var clienteExcluido = await _repository.ExcluirAsync(id);
                return _mapper.Map<ClienteDTO>(clienteExcluido);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<ClienteDTO> IncluirAsync(ClienteDTO clienteDto)
        {
            try
            {
                var cliente = _mapper.Map<ClienteEntity>(clienteDto);
                var clienteAdicionado = await _repository.IncluirAsync(cliente);
                return _mapper.Map<ClienteDTO>(clienteAdicionado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<ClienteDTO> SelecionarAsync(int id)
        {
            try
            {
                var cliente = await _repository.SelecionarAsync(id);
                return _mapper.Map<ClienteDTO>(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<PagedList<ClienteDTO>> SelecionarTodosAsync(int pageNumber, int pageSize)
        {
            try
            {
                var clientes = await _repository.SelecionarTodosAsync(pageNumber, pageSize);
                var clienteDTO = _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
                return new PagedList<ClienteDTO>(clienteDTO, pageNumber, pageSize, clientes.TotalCount);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}