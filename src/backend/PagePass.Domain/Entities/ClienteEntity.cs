namespace PagePass.Domain.Entities
{
    public sealed class ClienteEntity : EntityBase
    {
        public string CliBI { get; private set;} = null!;
        public string CliNome { get; private set; } = null!;
        public string CliEndereco { get; private set; } = null!;
        public string CliCidade { get; private set; } = null!;
        public string CliBairro { get; private set; } = null!;
        public string CliNumero { get; private set; } = null!;
        public string CliTelefoneCelular { get; private set; } = null!;
        public string CliTelefoneFixo { get; private set; } = null!;

        [JsonIgnore]
        public ICollection<EmprestimoEntity>? Emprestimos { get; set;}

        [JsonConstructor]
        public ClienteEntity(){}
        public ClienteEntity(int id, string cliBI, string cliNome, string cliEndereco, string cliCidade, string cliBairro, string cliNumero, string cliTelefoneCelular, string cliTelefoneFixo)
        {
            DomainExceptionValidation.When(id < 0, "O Id do Cliente deve ser positivo");
            Id = id;
            ValidationDomain( cliBI, cliNome, cliEndereco, cliCidade, cliBairro, cliNumero, cliTelefoneCelular, cliTelefoneFixo);
        }
        public ClienteEntity(string cliBI, string cliNome, string cliEndereco, string cliCidade, string cliBairro, string cliNumero, string cliTelefoneCelular, string cliTelefoneFixo)
        {
            ValidationDomain( cliBI, cliNome, cliEndereco, cliCidade, cliBairro, cliNumero, cliTelefoneCelular, cliTelefoneFixo);
        }
        public void Update(string cliBI, string cliNome, string cliEndereco, string cliCidade, string cliBairro, string cliNumero, string cliTelefoneCelular, string cliTelefoneFixo)
        {
            ValidationDomain( cliBI, cliNome, cliEndereco, cliCidade, cliBairro, cliNumero, cliTelefoneCelular, cliTelefoneFixo);
        }
        public void ValidationDomain(string cliBI, string cliNome, string cliEndereco, string cliCidade, string cliBairro, string cliNumero, string cliTelefoneCelular, string cliTelefoneFixo)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(cliBI), "BI obrigatório");
            DomainExceptionValidation.When(cliBI.Length != 14, "O BI deve ter, 14 caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(cliNome), "Nome obrigatório");
            DomainExceptionValidation.When(cliNome.Length > 200, "O Nome deve ter, no máximo, 200 caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(cliEndereco), "Endereço obrigatório");
            DomainExceptionValidation.When(cliEndereco.Length > 50, "O Endereço deve ter, no máximo, 50 caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(cliCidade), "Cidade obrigatório");
            DomainExceptionValidation.When(cliCidade.Length > 50, "A cidade deve ter, no máximo, 50 caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(cliBairro), "Bairro obrigatório");
            DomainExceptionValidation.When(cliBairro.Length > 50, "O Bairro deve ter, no máximo, 50 caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(cliNumero), "Número obrigatório");
            DomainExceptionValidation.When(cliNumero.Length > 50, "O Número deve ter, no máximo, 50 caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(cliTelefoneCelular), "Celular obrigatório");
            DomainExceptionValidation.When(cliTelefoneCelular.Length > 17, "O Celular deve ter, no máximo, 111 caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(cliTelefoneFixo), "Telefone obrigatório");
            DomainExceptionValidation.When(cliTelefoneFixo.Length > 17, "O Telefone deve ter, no máximo, 10 caracteres");

            CliBI = cliBI;
            CliNome = cliNome;
            CliEndereco = cliEndereco;
            CliCidade = cliCidade;
            CliBairro = cliBairro;
            CliNumero = cliNumero;
            CliTelefoneCelular = cliTelefoneCelular;
            CliTelefoneFixo = cliTelefoneFixo;
        }
    }
}