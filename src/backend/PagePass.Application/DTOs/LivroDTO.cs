namespace PagePass.Application.DTOs
{
    public class LivroDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "O Nome deve no mínimo 50 caracteres")]
        public string LivroNome { get; set;} = null!;
        
        [Required]
        [MaxLength(200, ErrorMessage = "O Autor deve no mínimo 50 caracteres")]
        public string LivroAutor { get; set;} = null!;

        [Required]
        [MaxLength(50, ErrorMessage = "A editora deve no mínimo 50 caracteres")]
        public string LivroEditora { get; set; } = null!;

        [Required]
        public DateTime LivroAnoPublicacao { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "A edição deve no mínimo 50 caracteres")]
        public string LivroEdicao { get; set; } = null!;
    }
}