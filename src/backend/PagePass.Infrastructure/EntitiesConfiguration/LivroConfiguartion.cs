namespace PagePass.Infrastructure.EntitiesConfiguration
{
    public class LivroConfiguartion : IEntityTypeConfiguration<LivroEntity>
    {
        public void Configure(EntityTypeBuilder<LivroEntity> builder)
        {
            builder.ToTable("TBL_LIVROS");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.LivroNome).
                    IsRequired(true).
                    HasColumnType("VARCHAR")
                    .HasMaxLength(50);
            builder.Property(x => x.LivroAutor).
                    IsRequired(true).
                    HasColumnType("VARCHAR")
                    .HasMaxLength(200);
            builder.Property(x => x.LivroEditora).
                    IsRequired(true).
                    HasColumnType("VARCHAR")
                    .HasMaxLength(50);
            builder.Property(x => x.LivroAnoPublicacao).
                    IsRequired(true);
            builder.Property(x => x.LivroEdicao).
                    IsRequired(true).
                    HasColumnType("VARCHAR")
                    .HasMaxLength(50);

        }
    }
}