namespace PagePass.Application.DTOs
{
    public class EmprestimoPostDTO
    {
        [Required(ErrorMessage = "O livro é obrigatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "O identificador do livro é inválido")]
        public int IdLivro { get; set; }

        [Required(ErrorMessage = "O cliente é obrigatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "O identificador do livro é inválido")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "A data de entrega é obrigatorio")]
        public DateTime DataEntrega { get; set; }

        [JsonIgnore]
        public DateTime DataEmprestimo { get; set; }

        [JsonIgnore]
        public bool Entregue { get; set; }
    }
}