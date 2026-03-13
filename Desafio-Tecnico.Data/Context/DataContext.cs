using Desafio_Tecnico.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Tecnico.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Assinatura> Assinaturas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica todos os mappings automaticamente
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}
