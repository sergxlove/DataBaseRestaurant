namespace DataBaseRestaurant.DataAccess.Sqlite.Models
{
    public class MenuEntity
    {
        public int Id { get; set; }

        public string Name { get; set;  } = string.Empty;

        public int QuantityCalorie { get; set;  }

        public string Description { get; set; } = string.Empty;

        public int Price { get; set; }

        public List<IngredientsEntity> Ingredients { get; } = [];

        public List<OrdersEntity> Orders { get; } = [];
    }
}
