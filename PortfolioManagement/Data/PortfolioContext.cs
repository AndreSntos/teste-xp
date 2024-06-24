using Microsoft.EntityFrameworkCore;
using PortfolioManagement.Models;

namespace PortfolioManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ProdutoFinanceiro> ProdutosFinanceiros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Investimento> Investimentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Investimento>()
                .HasOne(i => i.Cliente)
                .WithMany(c => c.Portfolio)
                .HasForeignKey(i => i.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Investimento>()
                .HasOne(i => i.ProdutoFinanceiro)
                .WithMany()
                .HasForeignKey(i => i.ProdutoFinanceiroId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
