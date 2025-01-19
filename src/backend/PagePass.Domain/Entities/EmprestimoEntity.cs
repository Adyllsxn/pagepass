namespace PagePass.Domain.Entities
{
    public sealed class EmprestimoEntity : EntityBase
    {
        public int IdCliente { get; private set; }
        public int IdLivro { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public DateTime DataEntrega { get; private set; }
        public bool Entrega { get; private set; }

        [JsonIgnore]
        public ClienteEntity? Cliente { get; set;}

        [JsonIgnore]
        public LivroEntity? Livro { get; set; }

        [JsonConstructor]
        public EmprestimoEntity(){}
        public EmprestimoEntity(int id, int idCliente, int idLivro, DateTime dataEmprestimo, DateTime dataEntrega, bool entrega)
        {
            DomainExceptionValidation.When(id < 0, "O Id do Emprestimo deve ser positivo");
            Id = id;
            ValidationDomain( idCliente,  idLivro,  dataEmprestimo,  dataEntrega,  entrega);
        }
        public EmprestimoEntity(int idCliente, int idLivro, DateTime dataEmprestimo, DateTime dataEntrega, bool entrega)
        {
            ValidationDomain( idCliente,  idLivro,  dataEmprestimo,  dataEntrega,  entrega);
        }
        public void Update(int idCliente, int idLivro, DateTime dataEmprestimo, DateTime dataEntrega, bool entrega)
        {
            ValidationDomain( idCliente,  idLivro,  dataEmprestimo,  dataEntrega,  entrega);
        }
        public void ValidationDomain(int idCliente, int idLivro, DateTime dataEmprestimo, DateTime dataEntrega, bool entrega)
        {
            DomainExceptionValidation.When(int.IsNegative(idCliente), "Id do cliente deve ser, Positivo");
            DomainExceptionValidation.When(idCliente <= 0, "Id do cliente deve ser maior que 0");

            DomainExceptionValidation.When(int.IsNegative(idLivro), "Id do livro deve ser, positivo");
            DomainExceptionValidation.When(idLivro <= 0, "Id do livro deve ser maior que 0");

            IdCliente = idCliente;
            IdLivro = idLivro;
            DataEmprestimo = dataEmprestimo;
            DataEntrega = dataEntrega;
            Entrega = entrega;
        }
    }
}