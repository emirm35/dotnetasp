using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config


{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Primary key
            builder.HasKey(p => p.ProductId);

            //Zorunlu alanalr
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.Price).IsRequired();



            builder.HasData(

             new Product() { ProductId = 1, ImageUrl = "/images/2.jpg", CategoryId = 1, ProductName = "Computer", Price = 10000, ShowCase = false },
            new Product() { ProductId = 2, ImageUrl = "/images/2.jpg", CategoryId = 1, ProductName = "Desk", Price = 2000, ShowCase = false },
            new Product() { ProductId = 3, ImageUrl = "/images/2.jpg", CategoryId = 2, ProductName = "Keyboard", Price = 1000, ShowCase = false },
            new Product() { ProductId = 4, ImageUrl = "/images/2.jpg", CategoryId = 2, ProductName = "Mouse", Price = 800, ShowCase = true },
            new Product() { ProductId = 5, ImageUrl = "/images/2.jpg", CategoryId = 2, ProductName = "Router", Price = 750, ShowCase = true },
            new Product() { ProductId = 6, ImageUrl = "/images/2.jpg", CategoryId = 2, ProductName = "Chair", Price = 500, ShowCase = true }
            );
        }

    }
}