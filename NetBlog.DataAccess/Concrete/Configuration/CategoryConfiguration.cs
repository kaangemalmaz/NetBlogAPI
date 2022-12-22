using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetBlog.Entities.Concrete;

namespace NetBlog.DataAccess.Concrete.Configuration
{
    //fluent API
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(70);
            builder.Property(a => a.CreatedBy).IsRequired();
            builder.Property(a => a.CreatedBy).HasMaxLength(50);
            builder.Property(a => a.LastModifiedBy).HasMaxLength(50);
            builder.Property(a => a.CreatedDate).IsRequired().HasColumnType("Date");
            builder.Property(a => a.LastModifiedDate).HasColumnType("Date");
            builder.ToTable("Categories");

            builder.HasData(
              new Category
              {
                  Id = 1,
                  Name = "C#",
                  CreatedBy = "Admin",
                  CreatedDate = DateTime.UtcNow,
                  //LastModifiedBy = string.Empty,
                  //LastModifiedDate = null
              },
              new Category
              {
                  Id = 2,
                  Name = "Java",
                  CreatedBy = "Admin",
                  CreatedDate = DateTime.UtcNow,
                  //LastModifiedBy = string.Empty,
                  //LastModifiedDate = null
              },
              new Category
              {
                  Id = 3,
                  Name = "NodeJs",
                  CreatedBy = "Admin",
                  CreatedDate = DateTime.UtcNow,
                  //LastModifiedBy = string.Empty,
                  //LastModifiedDate = null
              },
              new Category
              {
                  Id = 4,
                  Name = "React",
                  CreatedBy = "Admin",
                  CreatedDate = DateTime.UtcNow,
                  //LastModifiedBy = string.Empty,
                  //LastModifiedDate = null
              },
              new Category
              {
                  Id = 5,
                  Name = "PHP Symfony",
                  CreatedBy = "Admin",
                  CreatedDate = DateTime.UtcNow,
                  //LastModifiedBy = string.Empty,
                  //LastModifiedDate = null
              },
              new Category
              {
                  Id = 6,
                  Name = "MongoDb",
                  CreatedBy = "Admin",
                  CreatedDate = DateTime.UtcNow,
                  //LastModifiedBy = string.Empty,
                  //LastModifiedDate = null
              },
              new Category
              {
                  Id = 7,
                  Name = "MSSQL",
                  CreatedBy = "Admin",
                  CreatedDate = DateTime.UtcNow,
                  //LastModifiedBy = string.Empty,
                  //LastModifiedDate = null
              },
              new Category
              {
                  Id = 8,
                  Name = "PostreSQL",
                  CreatedBy = "Admin",
                  CreatedDate = DateTime.UtcNow,
                  //LastModifiedBy = string.Empty,
                  //LastModifiedDate = null
              },
              new Category
              {
                  Id = 9,
                  Name = "Firebase",
                  CreatedBy = "Admin",
                  CreatedDate = DateTime.UtcNow,
                  //LastModifiedBy = string.Empty,
                  //LastModifiedDate = null
              }
            );
        }
    }
}
