using DataBaseRestaurant.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBaseRestaurant.DataAccess.Sqlite.Configurations
{
    public class TablesConfiguration : IEntityTypeConfiguration<TablesEntity>
    {
        public void Configure(EntityTypeBuilder<TablesEntity> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Worker)
                .WithMany(a => a.Tables)
                .HasForeignKey(a => a.WorkerId);

            builder.HasMany(a => a.Orders)
                .WithOne(a => a.Table)
                .HasForeignKey(a => a.TableId);

        }
    }
}
