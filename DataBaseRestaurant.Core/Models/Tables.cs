namespace DataBaseRestaurant.Core.Models
{
    public class Tables
    {
        public int Id { get; }

        public string Status { get; } = string.Empty;

        public int QuantitySeat { get;  }

        public int WorkerId { get; }

        public Workers? Worker { get; }

        public List<Orders> Orders { get; } = [];
    }
}
