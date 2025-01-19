namespace PagePass.Api.Features.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroService _service;
        private readonly IUsuarioService _usuario;
        public LivrosController(ILivroService service, IUsuarioService usuario)
        {
            _service = service;
            _usuario = usuario;
        } 

        [HttpPost]
        public async Task<ActionResult> Incluir(LivroDTO livroDTO)
        {
            try
            {
                var userId = User.GetId();
                var usuario = await _usuario.SelecionarAsync(userId);
                if(!usuario.IsAdmin)
                {
                    return Unauthorized("Você não tem permissão para incluir livro.");
                }

                var livro = await _service.IncluirAsync(livroDTO);
                if (livro == null)
                {
                    return BadRequest("Ocorreu um erro ao incluir o livro!");
                }
                return Ok("Livro incluido com sucesso!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            
        }
    
        [HttpPut]
        public async Task<ActionResult> Alterar(LivroDTO livroDTO)
        {
            try
            {
                var livro = await _service.AlterarAsync(livroDTO);
                if (livro == null)
                {
                    return BadRequest("Ocorreu um erro ao alterar o livro!");
                }
                return Ok("Livro alterado com sucesso!");
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
                    return Unauthorized("Você não tem permissão para excluir livro.");
                }

                var livro = await _service.ExcluirAsync(id);
                if (livro == null)
                {
                    return BadRequest("Ocorreu um erro ao deletar o livro!");
                }
                return Ok("Livro deletado com sucesso!");
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
                var livro = await _service.SelecionarAsync(id);
                if (livro == null)
                {
                    return NotFound("Livro não encontrado!");
                }
                return Ok(livro);
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
                var livroDTOs = await _service.SelecionarTodosAsync(paginationParams.PageNumber, paginationParams.PageSize);
                if (livroDTOs == null)
                {
                    return NotFound("Livros não foram encontrados!");
                }
                Response.AddPaginationHeader(new PaginationHeader(livroDTOs.CurrentPage, livroDTOs.PageSize, livroDTOs.TotalCount, livroDTOs.TotalPages));

                return Ok(livroDTOs);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    
    }
}