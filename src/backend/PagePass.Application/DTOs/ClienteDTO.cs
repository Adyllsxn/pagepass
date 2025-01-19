namespace PagePass.Application.DTOs
{
    public class ClienteDTO
    {
        [IgnoreDataMember]
        public int Id { get; set; }

        [Required]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O BI deve ter 14 caracteres!")]
        public string CliBI { get; set;} = null!;

        [Required]
        [StringLength(200, ErrorMessage = "O Nome deve ter 200 caracteres")]
        public string CliNome { get; set; } = null!;

        [Required]
        [StringLength(50, ErrorMessage = "O Endereço deve ter 50 caracteres!")]
        public string CliEndereco { get; set; } = null!;

        [Required]
        [StringLength(50, ErrorMessage = "A Cidade deve ter 50 caracteres!")]
        public string CliCidade { get; set; } = null!;

        [Required]
        [StringLength(50, ErrorMessage = "O Bairro deve ter 50 caracteres!")]
        public string CliBairro { get; set; } = null!;

        [Required]
        [StringLength(50, ErrorMessage = "A Número deve ter 50 caracteres!")]
        public string CliNumero { get; set; } = null!;

        [Required]
        [StringLength(17, ErrorMessage = "O Celular deve ter 17 caracteres!")]
        public string CliTelefoneCelular { get; set; } = null!;

        [Required]
        [StringLength(17, ErrorMessage = "O Telefone deve ter 17 caracteres!")]
        public string CliTelefoneFixo { get; set; } = null!;
    }
}