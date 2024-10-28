namespace DataBaseRestaurant.Core.Models
{
    public class Orders
    {
        public int Id { get; }

        public int TotalSum { get; }

        public List<Menu> Menu { get; } = [];

        public int ClientId { get; }

        public Clients? Clients { get; }

        public int TableId { get; }

        public Tables? Table { get; }
    }
}
