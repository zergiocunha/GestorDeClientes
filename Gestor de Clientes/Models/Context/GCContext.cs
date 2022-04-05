using Microsoft.EntityFrameworkCore;
using GestorDeClientes.Models.Cliente;
using GestorDeClientes.Models.Carrinho;
using GestorDeClientes.Models.Produto;

namespace GestorDeClientes.Models.Context
{
    public class GCContext : DbContext
    {
        public GCContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClsClienteEndereco>()
                .HasOne<ClsCliente>()
                .WithMany()
                .HasForeignKey(p => p.IdClienteEndereco);

            modelBuilder.Entity<ClsCarrinho>()
                .HasOne<ClsCliente>()
                .WithMany()
                .HasForeignKey(p => p.Cliente);

            modelBuilder.Entity<ClsCarrinhoItens>()
                .HasOne<ClsProduto>()
                .WithMany()
                .HasForeignKey(p => p.Produto);

        }

        public DbSet<ClsCliente> Cliente { get; set; }
        public DbSet<ClsClienteEndereco> ClienteEndereco { get; set; }
        public DbSet<ClsCarrinho> Carrinho { get; set; }
        public DbSet<ClsCarrinhoItens> CarrinhoItens { get; set; }
        public DbSet<ClsProduto> Produto { get; set; }
    }
}
