using DataBaseRestaurant.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBaseRestaurant.DataAccess.Sqlite.Configurations
{
    public class SuppliersConfiguration : IEntityTypeConfiguration<SuppliersEntity>
    {
        public void Configure(EntityTypeBuilder<SuppliersEntity> builder)
        {
            builder.ToTable("Suppliers");
            builder.HasKey(a => a.Id);

            builder.HasMany(a => a.Ingredient)
                .WithOne(a => a.Supplier)
                .HasForeignKey(a => a.SupplierId);
        }
    }
}
