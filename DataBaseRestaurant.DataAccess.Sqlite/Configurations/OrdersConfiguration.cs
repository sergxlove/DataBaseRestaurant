using DataBaseRestaurant.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBaseRestaurant.DataAccess.Sqlite.Configurations
{
    public class OrdersConfiguration : IEntityTypeConfiguration<OrdersEntity>
    {
        public void Configure(EntityTypeBuilder<OrdersEntity> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasMany(a => a.Menu)
                .WithMany(a => a.Orders);

            builder.HasOne(a => a.Clients)
                .WithOne(a => a.Orders)
                .HasForeignKey<OrdersEntity>(a => a.ClientId);

            builder.HasOne(a => a.Table)
                .WithMany(a => a.Orders)
                .HasForeignKey(a => a.TableId);
                
        }
    }
}
