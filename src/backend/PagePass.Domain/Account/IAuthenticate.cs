namespace PagePass.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> AuthenticateAsync(string email, string senha);
        Task<bool> UserExits(string email);
        Task<UsuarioEntity?>  GetUserByEmail(string email);
        public string GenerateToken(int id, string email);
    }
}