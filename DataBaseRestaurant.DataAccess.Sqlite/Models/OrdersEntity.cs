namespace DataBaseRestaurant.DataAccess.Sqlite.Models
{
    public class OrdersEntity
    {
        public int Id { get; set; }

        public int TotalSum { get; set; }

        public List<MenuEntity> Menu { get; set; } = [];

        public int ClientId { get; set; }

        public ClientsEntity? Clients { get; set; }

        public int TableId { get; set; }

        public TablesEntity? Table { get; set; }
    }
}
