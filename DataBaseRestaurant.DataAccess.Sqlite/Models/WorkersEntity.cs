namespace DataBaseRestaurant.DataAccess.Sqlite.Models
{
    public class WorkersEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string NumberPhone { get; set; } = string.Empty;

        public string Position { get; set; } = string.Empty;

        public int Salary { get; set; }

        public List<TablesEntity> Tables { get; set; } = [];
    }
}
