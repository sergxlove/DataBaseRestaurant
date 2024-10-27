using System.Security.Cryptography.X509Certificates;

namespace DataBaseRestaurant.Core.Models
{
    public class HistoryOrders
    {
        public int Id { get; }

        public string ListDishes { get; } = string.Empty;

        public int TotalSum { get; }

        public DateTime DateOrder { get; }
    }
}
