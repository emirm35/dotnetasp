using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
        {

            //Primary key
            builder.HasKey(p => p.CategoryId);
            //Required
            builder.Property(c => c.CategoryName).IsRequired();

            builder.HasData(

                 new Category() { CategoryId = 1, CategoryName = "Book" },
                new Category() { CategoryId = 2, CategoryName = "Electronic" }
            );
        }
    }
}