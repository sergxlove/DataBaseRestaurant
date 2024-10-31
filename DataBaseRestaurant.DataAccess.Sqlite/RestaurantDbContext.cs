using DataBaseRestaurant.DataAccess.Sqlite.Configurations;
using DataBaseRestaurant.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseRestaurant.DataAccess.Sqlite
{
    public class RestaurantDbContext :DbContext
    {
        public RestaurantDbContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<ClientsEntity> Clients { get; set; }

        public DbSet<HistoryOrdersEntity> HistoryOrders { get; set; }

        public DbSet<IngredientsEntity> Ingredients { get; set; }

        public DbSet<MenuEntity> Menu { get; set; }

        public DbSet<OrdersEntity> Orders { get; set; }

        public DbSet<SuppliersEntity> Suppliers { get; set; }

        public DbSet<TablesEntity> Tables { get; set; }

        public DbSet<WorkersEntity> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=D:\projects\DataBaseRestaurant\Data\data.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientsConfiguration());
            modelBuilder.ApplyConfiguration(new HistoryOrdersConfiguration());
            modelBuilder.ApplyConfiguration(new IngredientsConfiguration());
            modelBuilder.ApplyConfiguration(new MenuConfiguration());
            modelBuilder.ApplyConfiguration(new OrdersConfiguration());
            modelBuilder.ApplyConfiguration(new SuppliersConfiguration());
            modelBuilder.ApplyConfiguration(new TablesConfiguration());
            modelBuilder.ApplyConfiguration(new WorkersConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
