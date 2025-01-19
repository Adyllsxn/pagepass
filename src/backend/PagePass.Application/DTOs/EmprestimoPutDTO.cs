namespace PagePass.Application.DTOs
{
    public class EmprestimoPutDTO
    {
        [Required(ErrorMessage = "O id é obrigatorio")]
        public int Id { get; set; }

        [Required(ErrorMessage = "A data de entregue é obrigatorio")]
        public DateTime DataEntrega { get; set; }

        [Required(ErrorMessage = "O estado entregue é obrigatorio")]
        public bool Entrega { get; set; }
    }
}