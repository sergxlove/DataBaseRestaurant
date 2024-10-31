using DataBaseRestaurant.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBaseRestaurant.DataAccess.Sqlite.Configurations
{
    public class HistoryOrdersConfiguration : IEntityTypeConfiguration<HistoryOrdersEntity>
    {
        public void Configure(EntityTypeBuilder<HistoryOrdersEntity> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Client)
                .WithMany(a => a.HistoryOrders)
                .HasForeignKey(a => a.ClientId);
        }
    }
}
