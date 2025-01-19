namespace PagePass.Api.Domain.Models
{
    public class UserToken
    {
        public string Token { get; set; } = null!;
        public bool IsAdmin { get; set; }
        public string Email { get; set; } = null!;
        public string Nome { get; set; } = null!;
    }
}