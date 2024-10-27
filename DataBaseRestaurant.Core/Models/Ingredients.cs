namespace DataBaseRestaurant.Core.Models
{
    public class Ingredients
    {
        public int Id { get; }

        public string Name { get; } = string.Empty;

        public int Weight { get; }

        public int QuantityInWareHouse { get; }

    }
}
