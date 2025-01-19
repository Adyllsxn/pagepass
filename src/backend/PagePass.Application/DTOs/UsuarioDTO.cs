namespace PagePass.Application.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(250, ErrorMessage = "O nome não pode ter mais de 250 caracteres")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "O email é obrigatório")]
        [MaxLength(250, ErrorMessage = "O email não pode ter mais de 2o0 caracteres")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "A senha é obrigatório")]
        [MaxLength(250, ErrorMessage = "A senha deve ter, no máximo, 100 caracteres.")]
        [MinLength(8, ErrorMessage = "A senha deve ter, no mínimo, 8 caracteres.")]
        [NotMapped]
        public string Password { get; set; } = null!;

        [JsonIgnore]
        public bool IsAdmin { get; set; }
    }
}