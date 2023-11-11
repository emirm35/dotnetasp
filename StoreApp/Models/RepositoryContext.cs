using Microsoft.EntityFrameworkCore;

namespace StoreApp.Models
{


    public class RepositoryContext : DbContext
    {


        public DbSet<Product> Products { get; set; }
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product() { ProductId = 1, ProductName = "Computer", Price = 10000 },
                new Product() { ProductId = 2, ProductName = "Desk", Price = 2000 },
                new Product() { ProductId = 3, ProductName = "Keyboard", Price = 1000 }
            );
        }


    }
}