namespace PagePass.Api.Features.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SistemaController : ControllerBase
    {
        private readonly IUsuarioService _usuario;
        private readonly ISistemeService _service;
        public SistemaController(IUsuarioService usuario, ISistemeService service)
        {
            _usuario = usuario;
            _service = service;
        }

        [HttpGet("VerificarPrimeiroUso")]
        public async Task<ActionResult> PrimeiroUso()
        {
            var existeUsuarioCadastrado = await _usuario.ExisteUsuarioCadastradoAsyn();
            return Ok(new {primeiroUso = !existeUsuarioCadastrado});
        }

        [HttpGet("Dashboard")]
        [Authorize]
        public async Task<ActionResult> Dashboard()
        {
            var quantidadeItemsDTO = await _service.SelecionarQtdItems();
            return Ok(quantidadeItemsDTO);
        }
    }
}