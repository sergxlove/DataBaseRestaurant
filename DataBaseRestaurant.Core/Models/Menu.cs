namespace DataBaseRestaurant.Core.Models
{
    public class Menu
    {
        public int Id { get; }

        public string Name { get; } = string.Empty;

        public int QuantityCalorie { get; }

        public string Description { get; } = string.Empty; 

        public int Price { get; }

    }
}
