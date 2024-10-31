using DataBaseRestaurant.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBaseRestaurant.DataAccess.Sqlite.Configurations
{
    public class IngredientsConfiguration : IEntityTypeConfiguration<IngredientsEntity>
    {
        public void Configure(EntityTypeBuilder<IngredientsEntity> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Supplier)
                .WithMany(a => a.Ingredient)
                .HasForeignKey(a => a.SupplierId);

            builder.HasMany(a => a.Menu)
                .WithMany(a => a.Ingredients);
        }
    }
}
