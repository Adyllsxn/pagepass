namespace PagePass.Domain.Entities
{
     public class UsuarioEntity
     {
          public int Id { get; private set; } 
          public string Nome { get; private set; } = null!;
          public string Email { get; private set; } = null!;
          public bool IsAdmin { get; private set; }
          public byte[] PasswordHash { get; private set; } = null!;
          public byte[] PasswordSalt { get; private set; } = null!;

       [JsonConstructor]
       public UsuarioEntity(){}

       public UsuarioEntity(int id, string nome, string email)
       {    
            DomainExceptionValidation.When(id < 0, "O Id do Usuário deve ser positivo");
            Id = id;
            ValidationDomain(nome, email);
       }
       public UsuarioEntity(string nome, string email)
       {
            ValidationDomain(nome, email);
       }

       public void SetAdmin(bool isAdmin)
       {
          IsAdmin = isAdmin;
       }
       public void UpdatePassword(byte[] passwordHash, byte[] passwordSalt)
       {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
       }
       public void ValidationDomain(string nome, string email)
       {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "Email é obrigatório");
            DomainExceptionValidation.When(nome.Length > 250, "O Nome não pode ultrapassar de 200 caracteres");
            DomainExceptionValidation.When(email.Length > 200, "O Nome não pode ultrapassar de 200 caracteres");

            Nome = nome;
            Email = email;
            IsAdmin = false;
       }
    }
}