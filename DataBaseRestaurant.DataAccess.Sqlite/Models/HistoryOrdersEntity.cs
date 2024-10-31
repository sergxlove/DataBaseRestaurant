namespace DataBaseRestaurant.DataAccess.Sqlite.Models
{
    public class HistoryOrdersEntity
    {
        public int Id { get; set; }

        public string ListDishes { get; set;  } = string.Empty;

        public int TotalSum { get; set;  }

        public DateTime DateOrder { get; set; }

        public int ClientId { get; set; }

        public ClientsEntity? Client { get; set; }
    }
}
