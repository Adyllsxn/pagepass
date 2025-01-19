namespace PagePass.Api.Features.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;
        private readonly IUsuarioService _usuario;
        public ClientesController(IClienteService service, IUsuarioService usuario)
        {
            _service = service;
            _usuario = usuario;
        }  
        
        [HttpPost]
        public async Task<ActionResult> Incluir(ClienteDTO clienteDTO)
        {
            try
            {
                var userId = User.GetId();
                var usuario = await _usuario.SelecionarAsync(userId);
                if(!usuario.IsAdmin)
                {
                    return Unauthorized("Você não tem permissão para incluir cliente.");
                }

                var cliente = await _service.IncluirAsync(clienteDTO);
                if (cliente == null)
                {
                    return BadRequest("Ocorreu um erro ao incluir o cliente!");
                }
                return Ok("Cliente incluido com sucesso!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            
        }

        [HttpPut]
        public async Task<ActionResult> Alterar(ClienteDTO clienteDto)
        {
            try
            {
                var cliente = await _service.AlterarAsync(clienteDto);
                if (cliente == null)
                {
                    return BadRequest("Ocorreu um erro ao alterar o cliente!");
                }
                return Ok("Cliente alterado com sucesso!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            
        }

        [HttpDelete]
        public async Task<ActionResult> Deletar(int id)
        {
            try
            {
                var userId = User.GetId();
                var usuario = await _usuario.SelecionarAsync(userId);
                if(!usuario.IsAdmin)
                {
                    return Unauthorized("Você não tem permissão para excluir cliente.");
                }

                var cliente = await _service.ExcluirAsync(id);
                if (cliente == null)
                {
                    return BadRequest("Ocorreu um erro ao deletar o cliente!");
                }
                return Ok("Cliente deletado com sucesso!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult> Selecionar(int id)
        {
            try
            {
                var cliente = await _service.SelecionarAsync(id);
                if (cliente == null)
                {
                    return NotFound("Cliente não encontrado!");
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            
        }

        [HttpGet]
        public async Task<ActionResult> SelecionarTodo([FromQuery]PaginationParams paginationParams)
        {
            try
            {
                var clientesDTO = await _service.SelecionarTodosAsync(paginationParams.PageNumber, paginationParams.PageSize);
                if (clientesDTO == null)
                {
                    return NotFound("Clientes não foram encontrados!");
                }
                Response.AddPaginationHeader(new PaginationHeader(clientesDTO.CurrentPage, clientesDTO.PageSize, clientesDTO.TotalCount, clientesDTO.TotalPages));

                return Ok(clientesDTO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    
    }
}