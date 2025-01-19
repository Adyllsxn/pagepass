
namespace PagePass.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;
        public UsuarioService(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UsuarioDTO> AlterarAsync(UsuarioDTO usuarioDTO)
        {
            try
            {
                var usuario = _mapper.Map<UsuarioEntity>(usuarioDTO);
                var usuarioAlterado = await _repository.AlterarAsync(usuario);
                return _mapper.Map<UsuarioDTO>(usuarioAlterado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<UsuarioDTO> ExcluirAsync(int id)
        {
            try
            {
                var usuarioExcluido = await _repository.ExcluirAsync(id);
                return _mapper.Map<UsuarioDTO>(usuarioExcluido);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<bool> ExisteUsuarioCadastradoAsyn()
        {
            try
            {
                return await _repository.ExisteUsuarioCadastradoAsyn();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UsuarioDTO> IncluirAsync(UsuarioDTO usuarioDTO)
        {
            try
            {
                var usuario = _mapper.Map<UsuarioEntity>(usuarioDTO);
                if (usuarioDTO.Password != null)
                {
                    using var hmac = new HMACSHA3_512();
                    byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(usuarioDTO.Password));
                    byte[] passwordSalt = hmac.Key;

                    usuario.UpdatePassword(passwordHash, passwordSalt);
                }
                var usuarioAdicionado = await _repository.IncluirAsync(usuario);
                return _mapper.Map<UsuarioDTO>(usuarioAdicionado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<UsuarioDTO> SelecionarAsync(int id)
        {
            try
            {
                var usuario = await _repository.SelecionarAsync(id);
                return _mapper.Map<UsuarioDTO>(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<PagedList<UsuarioDTO>> SelecionarTodosAsync(int pageNumber, int pageSize)
        {
            try
            {
                var usuarios = await _repository.SelecionarTodosAsync(pageNumber, pageSize);
                var usuarioDTOs = _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
                return new PagedList<UsuarioDTO>(usuarioDTOs, pageNumber, pageSize, usuarios.TotalCount);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}