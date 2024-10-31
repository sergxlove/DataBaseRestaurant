namespace DataBaseRestaurant.DataAccess.Sqlite.Models
{
    public class IngredientsEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Weight { get; set; }

        public int QuantityInWareHouse { get; set; }

        public int SupplierId { get; set; }

        public SuppliersEntity? Supplier { get; set; }

        public List<MenuEntity> Menu { get; set;  } = [];
    }
}
