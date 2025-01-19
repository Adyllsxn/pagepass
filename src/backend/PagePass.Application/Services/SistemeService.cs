namespace PagePass.Application.Services
{
    public class SistemeService : ISistemeService
    {
        private readonly ISistemeRepository _repository;
        private readonly IMapper _mapper;
        public SistemeService(ISistemeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QuantidadeItemsDTO> SelecionarQtdItems()
        {
            var quantidadeItens = await _repository.SelecionarQtdItems();
            var QuantidadeItemsDTO = _mapper.Map<QuantidadeItemsDTO>(quantidadeItens);
            return QuantidadeItemsDTO;
        }
    }
}