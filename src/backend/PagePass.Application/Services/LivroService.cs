namespace PagePass.Application.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _repository;
        private readonly IMapper _mapper;
        public LivroService(ILivroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<LivroDTO> AlterarAsync(LivroDTO livroDTO)
        {
            try
            {
                var livro = _mapper.Map<LivroEntity>(livroDTO);
                var livroAlterado = await _repository.AlterarAsync(livro);
                return _mapper.Map<LivroDTO>(livroAlterado);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LivroDTO> ExcluirAsync(int id)
        {
            try
            {
                var livroExcluido = await _repository.ExcluirAsync(id);
                return _mapper.Map<LivroDTO>(livroExcluido);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LivroDTO> IncluirAsync(LivroDTO livroDTO)
        {
            try
            {
                var livro = _mapper.Map<LivroEntity>(livroDTO);
                var livroAdicionado = await _repository.IncluirAsync(livro);
                return _mapper.Map<LivroDTO>(livroAdicionado);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LivroDTO> SelecionarAsync(int id)
        {
            try
            {
                var livro = await _repository.SelecionarAsync(id);
                return _mapper.Map<LivroDTO>(livro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<PagedList<LivroDTO>> SelecionarTodosAsync(int pageNumber, int pageSize)
        {
            try
            {
                var livros = await _repository.SelecionarTodosAsync(pageNumber, pageSize);
                var livroDTOs = _mapper.Map<IEnumerable<LivroDTO>>(livros);
                return new PagedList<LivroDTO>(livroDTOs, pageNumber, pageSize, livros.TotalCount);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}