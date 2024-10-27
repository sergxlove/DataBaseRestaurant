namespace DataBaseRestaurant.Core.Models
{
    public class Clients
    {
        public int Id { get; }
        
        public string Name { get; } = string.Empty;

        public string Email { get; } = string.Empty;

        public string Preferences { get; } = string.Empty;
    }
}
