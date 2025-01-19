namespace PagePass.Domain.Entities
{
    public sealed class LivroEntity : EntityBase 
    {
        public string LivroNome { get; private set;} = null!;
        public string LivroAutor { get; private set;} = null!;
        public string LivroEditora { get; private set; } = null!;
        public DateTime LivroAnoPublicacao { get; private set; }
        public string LivroEdicao { get; private set; } = null!;

        [JsonIgnore]
        public ICollection<EmprestimoEntity>? Emprestimos { get; set;}

        [JsonConstructor]
        public LivroEntity(){}

        public LivroEntity(int id, string livroNome, string livroAutor, string livroEditora, DateTime livroAnoPublicacao, string livroEdicao)
        {
            DomainExceptionValidation.When(id < 0, "O Id do Livro deve ser positivo");
            Id = id;
            ValidationDomain(livroNome, livroAutor, livroEditora, livroAnoPublicacao, livroEdicao);
        }
        public LivroEntity(string livroNome, string livroAutor, string livroEditora, DateTime livroAnoPublicacao, string livroEdicao)
        {
            ValidationDomain(livroNome, livroAutor, livroEditora, livroAnoPublicacao, livroEdicao);
        }
        public void Update(string livroNome, string livroAutor, string livroEditora, DateTime livroAnoPublicacao, string livroEdicao)
        {
            ValidationDomain(livroNome, livroAutor, livroEditora, livroAnoPublicacao, livroEdicao);
        }
        public void ValidationDomain(string livroNome, string livroAutor, string livroEditora, DateTime livroAnoPublicacao, string livroEdicao)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(livroNome), "Nome do livro é obrigatório");
            DomainExceptionValidation.When(livroNome.Length > 50, "O nome do livro deve ter, no máximo 50, caracteres.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(livroAutor), "Nome do autor é obrigatório");
            DomainExceptionValidation.When(livroAutor.Length > 200, "O autor de livro deve ter, no máximo, 200 caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(livroEditora), "Editora obrigatório");
            DomainExceptionValidation.When(livroEditora.Length > 50, "O nome da editora do livro deve ter, no máximo, 50 caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(livroEdicao), "Edição obrigatório");
            DomainExceptionValidation.When(livroEdicao.Length > 50, "A edição do livro deve ter, no máximo, 50 caracteres");

            LivroNome = livroNome;
            LivroAutor = livroAutor;
            LivroEditora = livroEditora;
            LivroAnoPublicacao = livroAnoPublicacao;
            LivroEdicao = livroEdicao;
        }
    } 
}