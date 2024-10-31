using DataBaseRestaurant.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBaseRestaurant.DataAccess.Sqlite.Configurations
{
    public class WorkersConfiguration : IEntityTypeConfiguration<WorkersEntity>
    {
        public void Configure(EntityTypeBuilder<WorkersEntity> builder)
        {
            builder.ToTable("Workers");
            builder.HasKey(a => a.Id);

            builder.HasMany(a => a.Tables)
                .WithOne(a => a.Worker)
                .HasForeignKey(a => a.WorkerId);
        }
    }
}
