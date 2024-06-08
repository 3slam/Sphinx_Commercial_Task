using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sphinx_Commercial_Task.Data.Entities;

namespace Sphinx_Commercial_Task.Data.Context
{
    public class ApplicationDatabaseContext : DbContext
    {

        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options)
      : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ClientProduct> ClientProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureClientEntity(modelBuilder.Entity<Client>());
            ConfigureClientProductEntity(modelBuilder.Entity<ClientProduct>());
            ConfigureProductEntity(modelBuilder.Entity<Product>());
        }

        private void ConfigureClientEntity(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Code)
                .IsRequired()
                .HasMaxLength(9);

            builder.HasIndex(c => c.Code).IsUnique();

            builder.Property(c => c.Class)
                .IsRequired();

            builder.Property(c => c.State)
                .IsRequired();

            builder.HasMany(c => c.ClientProducts)
                .WithOne(cp => cp.Client)
                .HasForeignKey(cp => cp.ClientId);
        }

        private void ConfigureClientProductEntity(EntityTypeBuilder<ClientProduct> builder)
        {
            builder.HasKey(cp => cp.Id);

            builder.Property(cp => cp.ClientId)
                .IsRequired();

            builder.Property(cp => cp.ProductId)
                .IsRequired();

            builder.Property(cp => cp.StartDate)
                .IsRequired();

            builder.Property(cp => cp.EndDate)
                .IsRequired(false);

            builder.Property(cp => cp.License)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(cp => cp.Client)
                .WithMany(c => c.ClientProducts)
                .HasForeignKey(cp => cp.ClientId);

            builder.HasOne(cp => cp.Product)
                .WithMany(p => p.ClientProducts)
                .HasForeignKey(cp => cp.ProductId);
        }

        private void ConfigureProductEntity(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.IsActive)
                .IsRequired();

            builder.HasMany(p => p.ClientProducts)
                .WithOne(cp => cp.Product)
                .HasForeignKey(cp => cp.ProductId);
        }
    }
}

