using System.ComponentModel.DataAnnotations;

namespace EventoPlus.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Informe email do usuário")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário")]
        public string? Senha { get; set; }
    }
}
