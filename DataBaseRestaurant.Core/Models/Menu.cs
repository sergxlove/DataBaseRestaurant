namespace DataBaseRestaurant.Core.Models
{
    public class Menu
    {
        public const int MAX_LENGHT_NAME = 30;

        public const int MAX_LENGTH_DESCRIPTION = 150;

        private Menu(int id, string name, int quantityCalorie, string description, int price)
        {
            Id = id;
            Name = name;
            QuantityCalorie = quantityCalorie;
            Description = description;
            Price = price;
        }
        public int Id { get; }

        public string Name { get; } = string.Empty;

        public int QuantityCalorie { get; }

        public string Description { get; } = string.Empty;

        public int Price { get; }

        public List<Ingredients> Ingredients { get; } = [];

        public List<Orders> Orders { get; } = [];

        public static (Menu? menu, string error) Create(int id, string name, int quantityCalorie, string description, int price)
        {
            Menu? menu = null;
            string error = string.Empty;
            if (string.IsNullOrEmpty(name) || name.Length >= MAX_LENGHT_NAME)
            {
                error = "name is null or the allowed number of characters is exceeded";
                return (menu, error);
            }
            if (quantityCalorie < 0)
            {
                error = "invalid quantityCalorie";
                return (menu, error);
            }
            if (string.IsNullOrEmpty(description) || description.Length >= MAX_LENGTH_DESCRIPTION)
            {
                error = "description is null or the allowed number of characters is exceeded";
                return (menu, error);
            }
            if (price < 0)
            {
                error = "invalid price";
                return (menu, error);
            }
            menu = new(id, name, quantityCalorie, description, price);
            return (menu, error);

        }
    }
}
