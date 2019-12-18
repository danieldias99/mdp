using Microsoft.EntityFrameworkCore;
using MDP.Models.Association;

namespace MDP.Models.ClassesDeDominio
{
    public class MDPContext : DbContext
    {
        public MDPContext(DbContextOptions<MDPContext> options) : base(options) { }

        public DbSet<PlanoFabrico> PlanosFabrico { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<OrdemFabrico> OrdensFabrico { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Produto
            modelBuilder.Entity<Produto>().HasKey(f => f.Id);
            modelBuilder.Entity<Produto>().Property(f => f.Id).ValueGeneratedNever();

            modelBuilder.Entity<Produto>().OwnsOne(f => f.informacaoProduto);
            modelBuilder.Entity<Produto>().HasOne(f => f.planoFabrico);

            //plano fabrico
            modelBuilder.Entity<PlanoFabrico>().HasKey(a => a.Id);
            modelBuilder.Entity<PlanoFabrico>().Property(a => a.Id).ValueGeneratedNever();

            modelBuilder.Entity<PlanoFabrico>().HasMany<OrdemFabrico>(a => a.operacoes);

            //orde de fabrico
            modelBuilder.Entity<OrdemFabrico>().HasKey(b => new { b.Id_operacao, b.Id_planoFabrico });


        }

    }
}