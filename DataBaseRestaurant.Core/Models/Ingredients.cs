namespace DataBaseRestaurant.Core.Models
{
    public class Ingredients
    {
        public const int MAX_LENGTH_NAME = 30;
        private Ingredients(int id, string name, int weight, int quantityInWarehouse, int supplierId)
        {
            Id = id;
            Name = name;
            Weight = weight;
            QuantityInWareHouse = quantityInWarehouse;
            SupplierId = supplierId;
        }
        public int Id { get; }

        public string Name { get; } = string.Empty;

        public int Weight { get; }

        public int QuantityInWareHouse { get; }

        public int SupplierId { get; }

        public Suppliers? Supplier { get; }

        public List<Menu> Menu { get; } = [];

        public static (Ingredients? ingredients, string error) Create(int id, string name, int weight, int quantityInWarehouse, int supplierId)
        {
            Ingredients? ingredients = null;
            string error = string.Empty;
            if (string.IsNullOrEmpty(name) || name.Length >= MAX_LENGTH_NAME)
            {
                error = "name is null or the allowed number of characters is exceeded";
                return (ingredients, error);
            }
            if (weight < 0)
            {
                error = "invalid weight";
                return (ingredients, error);
            }
            if (quantityInWarehouse < 0)
            {
                error = "invalid name";
                return (ingredients, error);
            }

            ingredients = new(id, name, weight, quantityInWarehouse, supplierId);
            return (ingredients, error);

        }
    }
}
