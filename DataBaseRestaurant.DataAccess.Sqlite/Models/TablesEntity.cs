namespace DataBaseRestaurant.DataAccess.Sqlite.Models
{
    public class TablesEntity
    {
        public int Id { get; set; }

        public string Status { get; set; } = string.Empty;

        public int QuantitySeat { get; set;  }

        public int WorkerId { get; set; }

        public WorkersEntity? Worker { get; set; }

        public List<OrdersEntity> Orders { get; set; } = [];
    }
}
