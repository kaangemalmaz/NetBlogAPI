using Microsoft.EntityFrameworkCore;
using NetBlog.Core.Entities.Abstract;
using NetBlog.Core.Entities.Concrete;
using NetBlog.Entities.Concrete;
using System.Reflection;

namespace NetBlog.DataAccess.Context.EntityFramework
{
    public class NetBlogContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // MSSQL
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NetBlog;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            // POSTGRESQL
            // Npgsql.EntityFrameworkCore.PostgreSQL yüklenir.
            //optionsBuilder.UseNpgsql(@"User ID=postgres;Password=12345;Server=localhost;Port=5432;Database=NetBlog;Integrated Security=true;Pooling=true;");
        }


        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<EmailParameter> EmailParameters { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Modified:
                            entityReference.LastModifiedDate = DateTime.Now;
                            break;
                        case EntityState.Added:
                            entityReference.CreatedDate = DateTime.UtcNow;
                            entityReference.LastModifiedDate = DateTime.MinValue;
                            break;
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
