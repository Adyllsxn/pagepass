namespace PagePass.Api.Domain.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O E-mail é obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}