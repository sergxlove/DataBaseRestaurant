using DataBaseRestaurant.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBaseRestaurant.DataAccess.Sqlite.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<MenuEntity>
    {
        public void Configure(EntityTypeBuilder<MenuEntity> builder)
        {
            builder.ToTable("Menu");
            builder.HasKey(a => a.Id);

            builder.HasMany(a => a.Ingredients)
                .WithMany(a => a.Menu);

            builder.HasMany(a => a.Orders)
                .WithMany(a => a.Menu);
        }
    }
}
