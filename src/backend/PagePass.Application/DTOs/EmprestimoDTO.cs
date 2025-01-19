namespace PagePass.Application.DTOs
{
    public class EmprestimoDTO
    {
        public int Id { get; set;}
        public int IdCliente { get; set; }
        public int IdLivro { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataEntrega { get; set; }
        public bool Entrega { get; set; }
        public ClienteDTO? ClienteDTO { get; set;}
        public LivroDTO? LivroDTO { get; set; }
    }
}