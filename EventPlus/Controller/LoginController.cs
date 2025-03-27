using EventoPlus.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using EventoPlus.Interfaces;
using EventPlus.Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EventoPlus.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(loginDTO.Email!, loginDTO.Senha!);

                if (usuarioBuscado == null)
                {
                    return NotFound("Usuário não encontrado, emaill ou senha inválidos!");
                }

                //Caso o usuário seja encontrado, prossegue para a criação do token

                //1º Passo - Definir as Claims() que serão fornecidos no token(Payload)
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email!),

                    //podemos definir uma claim personalizada
                    new Claim("Nome da Claim","Valor da Claim")
                };

                //2º Passo - Definir a chave de acesso do token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("EventPlus-chave-autenticacao-webapi-dev"));

                //3º Passo - Definir as credenciais do Token (HEADER)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4º Passo - Gerar o Token
                var token = new JwtSecurityToken
                (
                    //emissor do token
                    issuer: "EventPlus",

                    //destinatário do token
                    audience: "EventPlus",

                    //dados definidos nas claims
                    claims: claims,

                    //tempo de expiração do token
                    expires: DateTime.Now.AddMinutes(5),

                    //credenciais do token
                    signingCredentials: creds
                );

                //retorna o token criado
                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    }
                    );

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
