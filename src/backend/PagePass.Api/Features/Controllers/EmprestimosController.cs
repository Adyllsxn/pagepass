namespace PagePass.Api.Features.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmprestimosController : ControllerBase
    {
        private readonly IEmprestimoService _service;
        private readonly IUsuarioService _usuario;
        public EmprestimosController(IEmprestimoService service, IUsuarioService usuario)
        {
            _service = service;
            _usuario = usuario;
        } 

        [HttpPost]
        public async Task<ActionResult> Incluir(EmprestimoPostDTO emprestimoPostDTO)
        {
            try
            {
                var disponivel = await _service.VerificaDisponibilidade(emprestimoPostDTO.IdLivro);
                if (!disponivel)
                {
                    return BadRequest("O livro não está disponivel para emprestimo");
                }
                var emprestimo = await _service.IncluirAsync(emprestimoPostDTO);
                if (emprestimo == null)
                {
                    return BadRequest("Ocorreu um erro ao incluir o emprestimo!");
                }
                return Ok("Emprestimo incluido com sucesso!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            
        }
    
        [HttpPut]
        public async Task<ActionResult> Alterar(EmprestimoPutDTO emprestimoPutDTO)
        {
            try
            {
                var emprestimoDTO = await _service.SelecionarAsync(emprestimoPutDTO.Id);
                if (emprestimoDTO == null)
                {
                    return NotFound("Emprestimo não encontrado.");
                }

                emprestimoDTO.DataEntrega = emprestimoPutDTO.DataEntrega;
                emprestimoDTO.Entrega = emprestimoPutDTO.Entrega;

                var emprestimoDTOAlerado = await _service.AlterarAsync(emprestimoDTO);
                if (emprestimoDTOAlerado == null)
                {
                    return BadRequest("Ocorreu um erro ao alterar o emprestimo!");
                }
                return Ok("Emprestimo alterado com sucesso!");
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
                var emprestimo = await _service.ExcluirAsync(id);
                if (emprestimo == null)
                {
                    return BadRequest("Ocorreu um erro ao deletar o emprestimo!");
                }
                return Ok("Emprestimo deletado com sucesso!");
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
                var emprestimo = await _service.SelecionarAsync(id);
                if (emprestimo == null)
                {
                    return NotFound("Emprestimo não encontrado!");
                }
                return Ok(emprestimo);
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
                var emprestimoDTOs = await _service.SelecionarTodosAsync(paginationParams.PageNumber, paginationParams.PageSize);
                if (emprestimoDTOs == null)
                {
                    return NotFound("Emprestimos não foram encontrados!");
                }
                Response.AddPaginationHeader(new PaginationHeader(emprestimoDTOs.CurrentPage, emprestimoDTOs.PageSize, emprestimoDTOs.TotalCount, emprestimoDTOs.TotalPages));

                return Ok(emprestimoDTOs);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}