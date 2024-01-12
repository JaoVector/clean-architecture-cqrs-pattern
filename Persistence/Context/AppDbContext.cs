using FollowMe.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FollowMe.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Carrinho> Carrinho { get; set;}
        public DbSet<ItemCarrinho> ItemCarrinho { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {

            model.Entity<ItemCarrinho>()
                .HasKey(x => x.ItemCarrinhoId);

            model.Entity<Carrinho>()
                .HasMany(p => p.Items)
                .WithOne(c => c.Carrinho)
                .HasForeignKey(c => c.CarrinhoId);

            model.Entity<ItemCarrinho>()
                .HasOne(p => p.Produto)
                .WithMany()
                .HasForeignKey(p => p.CodProduto);

            model.Entity<ItemCarrinho>()
                .HasOne(c => c.Carrinho)
                .WithMany(p => p.Items)
                .HasForeignKey(c => c.CarrinhoId);


            model.Entity<ItemPedido>()
                .HasKey(p => p.ItemPedidoId);

            model.Entity<Pedido>()
                .HasMany(p => p.ItensPedido)
                .WithOne(x => x.Pedido)
                .HasForeignKey(x => x.PedidoId);

            model.Entity<ItemPedido>()
                .HasOne(p => p.Produto)
                .WithMany()
                .HasForeignKey(p => p.CodProduto);

            model.Entity<ItemPedido>()
                .HasOne(pe => pe.Pedido)
                .WithMany(p => p.ItensPedido)
                .HasForeignKey(pe => pe.PedidoId);

            base.OnModelCreating(model);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}

/*
 * 
 * 
 *  protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Carrinho>()
                .HasKey(car => car.CodProduto);
                
        }
 * 
 * 
 * model.Entity<ItemCarrinho>()
                .HasKey(x => new { x.CarrinhoId, x.CodProduto });
 * 
 * 
 * 
 *   protected override void OnModelCreating(ModelBuilder model) 
        {

            model.Entity<ItemCarrinho>()
                .HasKey(x => x.ItemCarrinhoId);

            model.Entity<ItemCarrinho>()
                .HasKey(x => new { x.CarrinhoId, x.CodProduto });

            model.Entity<Carrinho>()
                .HasMany(p => p.Items)
                .WithOne(c => c.Carrinho)
                .HasForeignKey(c => c.CarrinhoId);

            model.Entity<ItemCarrinho>()
                .HasOne(p => p.Produto)
                .WithMany()
                .HasForeignKey(p => p.CodProduto);

            model.Entity<ItemCarrinho>()
                .HasOne(c => c.Carrinho)
                .WithMany(p => p.Items)
                .HasForeignKey(c => c.CarrinhoId);

            base.OnModelCreating(model);
        }
 * 
 * 
 */