namespace PagePass.Infrastructure.EntitiesConfiguration
{
    public class EmprestimoConfiguartion : IEntityTypeConfiguration<EmprestimoEntity>
    {
        public void Configure(EntityTypeBuilder<EmprestimoEntity> builder)
        {
            builder.ToTable("TBL_EMPRESTIMOS");
            builder.Property(x => x.IdLivro).
                    IsRequired(true);
            builder.Property(x => x.IdCliente).
                    IsRequired(true);
            builder.Property(x => x.DataEmprestimo).
                    IsRequired(true);
            builder.Property(x => x.DataEntrega).
                    IsRequired(true);
            builder.Property(x => x.Entrega).
                    IsRequired(true);
            builder.HasOne(x => x.Cliente).WithMany(x => x.Emprestimos).HasForeignKey(x => x.IdCliente).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Livro).WithMany(x => x.Emprestimos).HasForeignKey(x => x.IdLivro).OnDelete(DeleteBehavior.NoAction);
        }
    }
}