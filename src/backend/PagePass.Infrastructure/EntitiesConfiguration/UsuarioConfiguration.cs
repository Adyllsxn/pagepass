namespace PagePass.Infrastructure.EntitiesConfiguration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<UsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            builder.ToTable("TBL_USUARIOS");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).
                    IsRequired(true).
                    HasMaxLength(250).
                    HasColumnType("VARCHAR");
            builder.Property(x => x.Email).
                    IsRequired(true).
                    HasMaxLength(200).
                    HasColumnType("VARCHAR");
            builder.Property(x => x.IsAdmin).
                    IsRequired(true);
        }
    }
}