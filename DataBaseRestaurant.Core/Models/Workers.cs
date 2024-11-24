namespace DataBaseRestaurant.Core.Models
{
    public class Workers
    {
        public const int MAX_LENGTH_NAME = 40;

        public const int MAX_LENGTH_EMAIL = 40;

        public const string NUMBER_PHONE_FORMAT = "+7(999)999-99-99";

        public const int MAX_LENGTH_POSITION = 40;

        private Workers(int id, string name, string email, string numberPhone, string position, int salary)
        {
            Id = id;
            Name = name;
            Email = email;
            NumberPhone = numberPhone;
            Position = position;
            Salary = salary;
        }

        public int Id { get; }

        public string Name { get; } = string.Empty;

        public string Email { get; } = string.Empty;

        public string NumberPhone { get; } = string.Empty;

        public string Position { get; } = string.Empty;

        public int Salary { get; }

        public List<Tables> Tables { get; } = [];

        public static (Workers? worker, string error) Create(int id, string name, string email, string numberphone, string position, int salary)
        {
            Workers? worker = null;
            string error = string.Empty;
            if(string.IsNullOrEmpty(name) || name.Length >= MAX_LENGTH_NAME)
            {
                error = "name is null or the allowed number of characters is exceeded";
                return (worker, error);
            }
            if(string.IsNullOrEmpty(email) || email.Length >= MAX_LENGTH_EMAIL)
            {
                error = "email is null or the allowed number of characters is exceeded";
                return (worker, error);
            }
            if(!email.Contains("@mail") && !email.Contains("@gmail"))
            {
                error = "invalid email";
                return (worker, error);
            }
            if(string.IsNullOrEmpty(numberphone))
            {
                error = "email is null";
                return (worker, error);
            }
            if (numberphone[0] != NUMBER_PHONE_FORMAT[0] || numberphone[2] != NUMBER_PHONE_FORMAT[2] || numberphone[6] != NUMBER_PHONE_FORMAT[6]
                || numberphone[10] != NUMBER_PHONE_FORMAT[10] || numberphone[13] != NUMBER_PHONE_FORMAT[13])
            {
                error = "numberPhone invalid format";
                return (worker, error);
            }
            if(string.IsNullOrEmpty(position) || position.Length >= MAX_LENGTH_POSITION)
            {
                error = "position is null or the allowed number of characters is exceeded";
                return (worker, error);
            }
            if(salary < 0)
            {
                error = "invalid salary";
                return (worker, error);
            }

            worker = new(id, name, email, numberphone, position, salary);
            return(worker, error);


        }

    }
}
