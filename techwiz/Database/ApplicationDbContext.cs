using Microsoft.EntityFrameworkCore;
using TechWiz.Models;

namespace TechWiz.Database
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users{ get; set; }
        DbSet<Technology> Technologies { get; set; }
    }

    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
        public DbSet<User> Users { get; set; }
        public DbSet<Technology> Technologies { get; set; }

        public Task<object?> FindAsync(int v)
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                
                entity.Property(e => e.Name).HasMaxLength(255).IsRequired();
                entity.HasIndex(u => u.Name).IsUnique();

                entity.Property(e => e.Email).HasMaxLength(255).IsRequired();
                entity.HasIndex(u => u.Email).IsUnique();

                entity.Property(e => e.AboutMe).HasMaxLength(255);
                entity.Property(e => e.Title).HasMaxLength(255);
                entity.Property(e => e.GithubUrl).HasMaxLength(255);
                entity.Property(e => e.LinkedinUrl).HasMaxLength(255);
                entity.Property(e => e.ImageUrl).HasMaxLength(255);

                entity.Property(e => e.PasswordHash).HasMaxLength(255).IsRequired();

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("NOW(6)").ValueGeneratedOnAdd();

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("NOW(6)").ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<Technology>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).HasMaxLength(255).IsRequired();
                entity.HasIndex(u => u.Name).IsUnique();

                entity.Property(e => e.ImageUrl).HasMaxLength(255);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("NOW(6)").ValueGeneratedOnAdd();

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("NOW(6)").ValueGeneratedOnAddOrUpdate();
            });
        }
    }
}