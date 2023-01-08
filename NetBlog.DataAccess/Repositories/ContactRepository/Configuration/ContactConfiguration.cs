using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetBlog.Entities.Concrete;

namespace NetBlog.DataAccess.Repositories.ContactRepository.Configuration
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        // FLUENT API
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.Content).IsRequired();
            builder.Property(c => c.CreatedBy).IsRequired();

            builder.HasData(
                new Contact
                {
                    Id = 1,
                    CreatedBy = "Admin",
                    Content = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA",
                    CreatedDate = DateTime.UtcNow,
                    Email = "aaaa@gmail.com",
                    Title = "AAAAAAAAAAAAAAAAA",
                    //LastModifiedDate = null
                    //LastModifiedDate = DateTime.MinValue
                }
                );
        }
    }
}
