
namespace PagePass.Application.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IEmprestimoRepository _repository;
        private readonly IMapper _mapper;
        public EmprestimoService(IEmprestimoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<EmprestimoDTO> AlterarAsync(EmprestimoDTO emprestimoDTO)
        {
            try
            {
                var emprestimo = _mapper.Map<EmprestimoEntity>(emprestimoDTO);
                var emprestimoAlterado = await _repository.AlterarAsync(emprestimo);
                return _mapper.Map<EmprestimoDTO>(emprestimoAlterado);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EmprestimoDTO> ExcluirAsync(int id)
        {
            try
            {
                var livroExcluido = await _repository.ExcluirAsync(id);
                return _mapper.Map<EmprestimoDTO>(livroExcluido);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EmprestimoDTO> IncluirAsync(EmprestimoPostDTO emprestimoPostDTO)
        {
            try
            {
                emprestimoPostDTO.DataEntrega = DateTime.Now;
                emprestimoPostDTO.Entregue = false; 

                var emprestimo = _mapper.Map<EmprestimoEntity>(emprestimoPostDTO);
                var emprestimoAdicionado = await _repository.IncluirAsync(emprestimo);
                return _mapper.Map<EmprestimoDTO>(emprestimoAdicionado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EmprestimoDTO> SelecionarAsync(int id)
        {
            try
            {
                var emprestimo = await _repository.SelecionarAsync(id);
                return _mapper.Map<EmprestimoDTO>(emprestimo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PagedList<EmprestimoDTO>> SelecionarTodosAsync(int pageNumber, int pageSize)
        {
            try
            {
                var emprestimos = await _repository.SelecionarTodosAsync(pageNumber, pageSize);
                var emprestimoDTO = _mapper.Map<IEnumerable<EmprestimoDTO>>(emprestimos);
                return new PagedList<EmprestimoDTO>(emprestimoDTO, pageNumber, pageSize, emprestimos.TotalCount);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<bool> VerificaDisponibilidade(int idLivro)
        {
            try
            {
                return await _repository.VerificaDisponibilidade(idLivro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}