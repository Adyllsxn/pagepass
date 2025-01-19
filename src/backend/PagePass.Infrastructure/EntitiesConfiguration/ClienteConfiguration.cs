namespace PagePass.Infrastructure.EntitiesConfiguration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<ClienteEntity>
    {
        public void Configure(EntityTypeBuilder<ClienteEntity> builder)
        {
            builder.ToTable("TBL_CLIENTES");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CliBI).
                    IsRequired(true).
                    HasMaxLength(14).
                    HasColumnType("VARCHAR");
            builder.Property(x => x.CliNome).
                    IsRequired(true).
                    HasMaxLength(200).
                    HasColumnType("VARCHAR");
            builder.Property(x => x.CliEndereco).
                    IsRequired(true).
                    HasMaxLength(50).
                    HasColumnType("VARCHAR");
            builder.Property(x => x.CliCidade).
                    IsRequired(true).
                    HasMaxLength(50).
                    HasColumnType("VARCHAR");
            builder.Property(x => x.CliBairro).
                    IsRequired(true).
                    HasMaxLength(50).
                    HasColumnType("VARCHAR");
            builder.Property(x => x.CliNumero).
                    IsRequired(true).
                    HasMaxLength(50).
                    HasColumnType("VARCHAR");
            builder.Property(x => x.CliTelefoneCelular).
                    IsRequired(true).
                    HasMaxLength(17).
                    HasColumnType("VARCHAR");
            builder.Property(x => x.CliTelefoneFixo).
                    IsRequired(true).
                    HasMaxLength(17).
                    HasColumnType("VARCHAR");
            builder.HasData(
                new ClienteEntity(1,"007623437LD032","Pedro Narciso","Benfica Casa N 01","Luanda","Benfica","12","+244 914 765 765","+244 986 322 000"),
                new ClienteEntity(2,"007623437LD032","Maria Sousa","Zango Casa N 01","Luanda","Zango","10","+244 934 654 765","+244 986 111 123"),
                new ClienteEntity(3,"007623437ZE032","Luisa Bernada","Soyo Casa N 01","Soyo","Soyo","10","+244 934 000 000","+244 924 123 987")
            );
        }
    }
}