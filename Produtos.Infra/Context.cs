using Microsoft.EntityFrameworkCore;
using Produtos.Domain.ProdutoAggregate;
using Produtos.Infra.Maps;

namespace Produtos.Infra
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }
    }
}
