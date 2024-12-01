namespace DataBaseRestaurant.Core.Models
{
    public class Suppliers
    {
        public const int MAX_LENGTH_NAME = 40;

        public const int MAX_LENGTH_EMAIL = 40;

        public const string NUMBER_PHONE_FORMAT = "+7(999)999-99-99";

        private Suppliers(int id, string name, string email, string numberphone, int ratting)
        {
            Id = id;
            Name = name;
            Email = email;
            NumberPhone = numberphone;
            Ratting = ratting;
        }
        public int Id { get; }

        public string Name { get; } = string.Empty;

        public string Email { get; } = string.Empty;

        public string NumberPhone { get; } = string.Empty;

        public int Ratting { get; }

        public List<Ingredients> Ingredient { get; } = [];

        public static (Suppliers? supplier, string error) Create(int id, string name, string email, string numberphone, int ratting)
        {
            Suppliers? supplier = null;
            string error = string.Empty;
            if (string.IsNullOrEmpty(name) || name.Length >= MAX_LENGTH_NAME) 
            {
                error = "name is null or the allowed number of characters is exceeded";
                return (supplier, error);
            }
            if (string.IsNullOrEmpty(email) || email.Length >= MAX_LENGTH_EMAIL) 
            {
                error = "email is null or the allowed number of characters is exceeded";
                return (supplier, error);
            }
            if(!email.Contains("@mail") && !email.Contains("@gmail"))
            {
                error = "invalid email";
                return (supplier, error);
            }
            if(string.IsNullOrEmpty(numberphone))
            {
                error = "numberPhone is null";
                return (supplier, error);
            }
            if (numberphone[0] != NUMBER_PHONE_FORMAT[0] || numberphone[2] != NUMBER_PHONE_FORMAT[2] || numberphone[6] != NUMBER_PHONE_FORMAT[6]
                || numberphone[10] != NUMBER_PHONE_FORMAT[10] || numberphone[13] != NUMBER_PHONE_FORMAT[13]) 
            {
                error = "numberPhone invalid format";
                return (supplier, error);
            }
            if(ratting < 0)
            {
                error = "invalid ratting";
                return (supplier, error);
            }
            supplier = new(id, name, email, numberphone, ratting);
            return (supplier, error);
        }
    }
}
