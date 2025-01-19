namespace PagePass.Api.Features.Controllers
{
     [ApiController]
     [Route("api/[controller]")]
     public class UsuariosController : ControllerBase
     {
          private readonly IUsuarioService _service;
          private readonly IAuthenticate _authenticate;
          public UsuariosController(IUsuarioService service, IAuthenticate authenticate)
          {
               _service = service;
               _authenticate = authenticate;
          } 

          [HttpPost("register")]
          public async Task<ActionResult<UserToken>> Incluir(UsuarioDTO usuarioDTO)
          {
               try
               {
                    if(usuarioDTO == null)
                    {
                         return BadRequest("Dados inválidos");
                    }
                    
                    var emailExiste = await _authenticate.UserExits(usuarioDTO.Email);
                    if(emailExiste == null)
                    {
                         return BadRequest("Este já possui um cadastro");
                    } 

                    var existeUsuarioSistema = await _service.ExisteUsuarioCadastradoAsyn();
                    if(!existeUsuarioSistema)
                    {
                         usuarioDTO.IsAdmin = true;
                    }
                    else
                    {
                         if(User.FindFirst("id") == null)
                         {
                              return Unauthorized();
                         }
                         var userId = User.GetId();
                         var user = await _service.SelecionarAsync(userId);
                         if(!user.IsAdmin)
                         {
                              return Unauthorized("Você não tem permissão para incluir novos usuários");
                         }
                    }

                    var usuario = await _service.IncluirAsync(usuarioDTO);
                    if(usuario == null)
                    {
                         return BadRequest("Ocorreu um erro ao cadastrar");
                    }

                    var token = _authenticate.GenerateToken(usuario.Id, usuario.Email);
                    return new UserToken{
                         Token = token
                    };
               }
               catch (Exception ex)
               {
                    throw new Exception(ex.ToString());
               }
          
               
          }
     
          [HttpPost("login")]
          public async Task<ActionResult<UserToken>> Selecionar(LoginModel login)
          {
               try
               {
                    var existe = await _authenticate.UserExits(login.Email);
                    if(!existe)
                    {
                         return Unauthorized("Usuário não existe");
                    }

                    var result = await _authenticate.AuthenticateAsync(login.Email, login.Password);
                    if(!result)
                    {
                         return Unauthorized("Usuário ou Senha inválida.");
                    }

                    var usuario = await _authenticate.GetUserByEmail(login.Email);
                    var token = _authenticate.GenerateToken(usuario.Id, usuario.Email);

                    return new UserToken
                    {
                         Token = token,
                         IsAdmin =  usuario.IsAdmin,
                         Email = usuario.Email,
                         Nome = usuario.Nome
                    };
               }
               catch (Exception ex)
               {
                    throw new Exception(ex.ToString());
               }
               
          }
     
             
          [HttpPut]
          [Authorize]
          public async Task<ActionResult> Alterar(UsuarioDTO usuarioDTO)
        {
            try
            {
               var userId = User.GetId();
               var user = await _service.SelecionarAsync(userId);
               if (!user.IsAdmin && usuarioDTO.Id != userId)
               {
                    return Unauthorized("Você não tem permissão para alterar os usuários do sistema");
               }
               if (!user.IsAdmin && usuarioDTO.Id == userId && usuarioDTO.IsAdmin)
               {
                    return Unauthorized("Você não tem permissão para definir você mesmo com administardor");
               }

                var usuario = await _service.AlterarAsync(usuarioDTO);
                if (usuario == null)
                {
                    return BadRequest("Ocorreu um erro ao alterar o usuário!");
                }
                return Ok("Usuário alterado com sucesso!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            
        }
    
          [HttpDelete]
          [Authorize]
          public async Task<ActionResult> Deletar(int id)
          {
            try
            {
               var userId = User.GetId();
               var user = await _service.SelecionarAsync(userId);
               if (!user.IsAdmin)
               {
                    return Unauthorized("Você não tem permissão para deletar os usuários do sistema");
               }

               var usuario = await _service.ExcluirAsync(id);
               if (usuario == null)
               {
                    return BadRequest("Ocorreu um erro ao deletar o usuário!");
               }
               return Ok("Usuário deletado com sucesso!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            
        }
        
          [HttpGet]
          [Authorize]
          public async Task<ActionResult> SelecionarTodo([FromQuery]PaginationParams paginationParams)
          {
               try
               {
                    var userId = User.GetId();
                    var user = await _service.SelecionarAsync(userId);
                    if(!user.IsAdmin)
                    {
                         return Unauthorized("Você não tem permissão para consultar os usuários do sistema");
                    }

                    var usuarioDTOs = await _service.SelecionarTodosAsync(paginationParams.PageNumber, paginationParams.PageSize);
                    if (usuarioDTOs == null)
                    {
                         return NotFound("Usuários não foram encontrados!");
                    }
                    Response.AddPaginationHeader(new PaginationHeader(usuarioDTOs.CurrentPage, usuarioDTOs.PageSize, usuarioDTOs.TotalCount, usuarioDTOs.TotalPages));

                    return Ok(usuarioDTOs);
               }
               catch (Exception ex)
               {
                    throw new Exception(ex.ToString());
               }
          }
  

          [HttpGet("{id}")]
          [Authorize]
          public async Task<ActionResult> Selecionar(int id)
          {
               try
               {
                    var userId = User.GetId();
                    var user = await _service.SelecionarAsync(userId);

                    if(id == 0)
                    {
                         id = userId;
                    }
                    if(!user.IsAdmin && user.Id != id)
                    {
                         return Unauthorized("Você não tem permissão para consultar os usuários do sistema.");
                    }

                    var usuario = await _service.SelecionarAsync(id);
                    if (usuario == null)
                    {
                         return NotFound("Usuário não encontrado!");
                    }
                    return Ok(usuario);
               }
               catch (Exception ex)
               {
                    throw new Exception(ex.ToString());
               }
            
        }
     }
}