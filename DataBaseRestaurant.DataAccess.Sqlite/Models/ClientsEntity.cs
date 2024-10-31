namespace DataBaseRestaurant.DataAccess.Sqlite.Models
{
    public class ClientsEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Preferences { get; set; } = string.Empty;

        public int OrderId { get; set;  }

        public OrdersEntity? Orders { get; set; }

        public List<HistoryOrdersEntity> HistoryOrders { get; set; } = [];
    }
}
