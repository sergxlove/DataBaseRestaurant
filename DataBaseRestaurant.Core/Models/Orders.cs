namespace DataBaseRestaurant.Core.Models
{
    public class Orders
    {
        private Orders(int totalsum, int clientId, int tableId)
        {
            TotalSum = totalsum;
            ClientId = clientId;
            TableId = tableId;
        }
        public int Id { get; }

        public int TotalSum { get; }

        public List<Menu> Menu { get; } = [];

        public int ClientId { get; }

        public Clients? Clients { get; }

        public int TableId { get; }

        public Tables? Table { get; }

        public static (Orders? order, string error) Create(int totalsum, int clientId, int tableId)
        {
            Orders? order = null;
            string error = string.Empty;
            if(totalsum < 0)
            {
                error = "invalid totalprice";
                return (order, error);
            }
            order = new(totalsum, clientId, tableId);
            return (order, error);

        }
    }
}
