using DataBaseRestaurant.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBaseRestaurant.DataAccess.Sqlite.Configurations
{
    public class ClientsConfiguration : IEntityTypeConfiguration<ClientsEntity>
    {
        public void Configure(EntityTypeBuilder<ClientsEntity> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Orders)
                .WithOne(a => a.Clients)
                .HasForeignKey<OrdersEntity>(a => a.ClientId);

            builder.HasMany(a => a.HistoryOrders)
                .WithOne(a => a.Client)
                .HasForeignKey(a => a.ClientId);

        }
    }
}
