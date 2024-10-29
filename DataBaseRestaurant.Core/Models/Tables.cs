namespace DataBaseRestaurant.Core.Models
{
    public class Tables
    {
        public const int MAX_LENGTH_STATUS = 15;

        private Tables(int id, string status, int quantitySeat, int workerId)
        {
            Id = id;
            Status = status;
            QuantitySeat = quantitySeat;
            WorkerId = workerId;
        }
        public int Id { get; }

        public string Status { get; } = string.Empty;

        public int QuantitySeat { get;  }

        public int WorkerId { get; }

        public Workers? Worker { get; }

        public List<Orders> Orders { get; } = [];

        public static (Tables? table , string error) Create(int id, string status, int quantitySeat, int workerId)
        {
            Tables? table = null;
            string error = string.Empty;
            if(string.IsNullOrEmpty(status) || status.Length >= MAX_LENGTH_STATUS)
            {
                error = "status is null or the allowed number of characters is exceeded";
                return (table , error);
            }
            if(quantitySeat < 0)
            {
                error = "invalid quantitySeat";
                return (table , error);
            }
            table = new(id, status, quantitySeat, workerId);
            return (table , error);
        }
            
    }
}
