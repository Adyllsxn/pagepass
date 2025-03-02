namespace PagePass.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<ClienteEntity> Clientes { get; set; } = null!;
        public DbSet<LivroEntity> Livros { get; set; } = null!;
        public DbSet<EmprestimoEntity> Emprestimos { get; set; } = null!;
        public DbSet<UsuarioEntity> Usuarios { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}