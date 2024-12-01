namespace DataBaseRestaurant.Core.Models
{
    public class Clients
    {
        public const int MAX_LENGTH_NAME = 60;

        public const int MAX_LENGHT_EMAIL = 40;

        public const int MAX_LENGTH_PREFERENCES = 150;
        private Clients(int id, string name, string email, string preferences, int orderId)
        {
            Id = id;
            Name = name;
            Email = email;
            Preferences = preferences;
            OrderId = orderId;
        }
        public int Id { get; }
        
        public string Name { get; } = string.Empty;

        public string Email { get; } = string.Empty;

        public string Preferences { get; } = string.Empty;

        public int OrderId { get; }

        public Orders? Orders { get; }

        public List<HistoryOrders> HistoryOrders { get; } = [];

        public static (Clients? client, string error) Create(int id, string name, string email, string preferences, int orderId)
        {
            Clients? client = null;
            string error = string.Empty;
            if(string.IsNullOrEmpty(name) ||  name.Length >= MAX_LENGTH_NAME)
            {
                error = "name is null or the allowed number of characters is exceeded";
                return (client, error);
            }
            if(string.IsNullOrEmpty(email) || email.Length >= MAX_LENGHT_EMAIL)
            {
                error = "email is null or the allowed number of characters is exceeded";
                return (client, error);
            }
            if(!email.Contains("@mail") && !email.Contains("@gmail"))
            {
                error = "invalid email";
                return (client, error);
            }
            if(string.IsNullOrEmpty(preferences) || preferences.Length >= MAX_LENGTH_PREFERENCES)
            {
                error = "preferences is null or the allowed number of characters is exceeded";
                return (client, error);
            }
            client = new(id, name, email, preferences, orderId);
            return (client, error);

        }
    }
}
