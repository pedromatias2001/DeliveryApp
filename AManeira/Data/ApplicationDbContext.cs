using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AManeira.Models;
using Microsoft.AspNetCore.Identity;

namespace AManeira.Data
{
    public class ApplicationUser : IdentityUser
    {

        /// <summary>
        /// data em que o utilizador criou o registo
        /// </summary>
        public DateTime DataRegisto { get; set; }

        //public string NomeBatismo { get; set; }

        /* aqui poderiam ser adicionados mais atributos,
        * se isso fosse considerado necessário
        * exemplo
        *   nome
        *   morada
        *   cod postal
        *   nif
        *   ...
        */
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options){
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            /*
             * esta instrução importa todas as tarefas associadas ao método
             * qd foi definida na superclasse
             * */
            base.OnModelCreating(modelBuilder);

            // criar dados das ROLES
            modelBuilder.Entity<IdentityRole>().HasData(
               new IdentityRole { Id = "a", Name = "Admin", NormalizedName = "ADMIN" },
               new IdentityRole { Id = "c", Name = "Cliente", NormalizedName = "CLIENTE" }
               );

            // inicializar os dados das tabelas da BD
            modelBuilder.Entity<Pratos>().HasData(
            new Pratos { Id = 1, Nome = "Tostas Mistas", Preco = (decimal)4.50, Foto = "tostas1.jpg", Descricao = "Tostas de Queijo e Fiambre", NumStock = 5 },
            new Pratos { Id = 2, Nome = "Pizza", Preco = (decimal)7.50, Foto = "pizza1.jpg", Descricao = "Pizza de Pepperoni", NumStock =  7},
            new Pratos { Id = 3, Nome = "Hamburguer", Preco = (decimal)5.50, Foto = "burguer1.jpg", Descricao = "Hamburguer com Queijo, Tomate e Bacon", NumStock = 1}
            );

            modelBuilder.Entity<Fotos>().HasData(
            new Fotos { Id = 1, Name = "tostas2.jpg", PratoFK = 1},
            new Fotos { Id = 2, Name = "tostas3.jpg", PratoFK = 1 },
            new Fotos { Id = 3, Name = "hamburguer2.jpg", PratoFK = 3},
            new Fotos { Id = 4, Name = "pizza2.jpg", PratoFK = 2 },
            new Fotos { Id = 5, Name = "pizza3.jpg", PratoFK = 2 },
            new Fotos { Id = 6, Name = "hamburguer3.jpg", PratoFK = 3 },
            new Fotos { Id = 7, Name = "tostas4.jpg", PratoFK = 1 },
            new Fotos { Id = 8, Name = "pizza4.jpg", PratoFK = 2 },
            new Fotos { Id = 9, Name = "hamburguer4.jpg", PratoFK = 3 }
            );
        }
        public DbSet<AManeira.Models.Pratos> Pratos { get; set; }
        public DbSet<AManeira.Models.Encomendas> Encomendas { get; set; }
        public DbSet<AManeira.Models.Fotos> Fotos { get; set; }
        public DbSet<AManeira.Models.Clientes> Clientes { get; set; }
        public DbSet<AManeira.Models.EncomendasPratos> EncomendasPratos { get; set; }
    }
}