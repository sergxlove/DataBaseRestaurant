namespace DataBaseRestaurant.DataAccess.Sqlite.Models
{
    public class SuppliersEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string NumberPhone { get; set; } = string.Empty;

        public int Ratting { get; set; }

        public List<IngredientsEntity> Ingredient { get; set; } = [];
    }
}
