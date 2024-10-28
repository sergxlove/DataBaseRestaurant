namespace DataBaseRestaurant.Core.Models
{
    public class Workers
    {
        public int Id { get; }

        public string Name { get; } = string.Empty;

        public string Email { get; } = string.Empty;

        public string NumberPhone { get; } = string.Empty;

        public string Position { get; } = string.Empty;

        public int Salary { get; }

        public List<Tables> tables { get; } = [];

    }
}
