using System.Security.Cryptography.X509Certificates;

namespace DataBaseRestaurant.Core.Models
{
    public class HistoryOrders
    {
        public const int MAX_LENGTH_LISTDISHES = 100;

        public const string DATE_FORMAT = "hh.mm.ss dd.mm.yyyy";

        private HistoryOrders(int id, string listDishes, int totalsum, DateTime dateorder, int clientId)
        {
            Id = id;
            ListDishes = listDishes;
            TotalSum = totalsum;
            DateOrder = dateorder;
            ClientId = clientId;
        }
        public int Id { get; }

        public string ListDishes { get; } = string.Empty;

        public int TotalSum { get; }

        public DateTime DateOrder { get; }

        public int ClientId { get; }

        public Clients? Client { get; }

        public static (HistoryOrders? historyorder, string error) Create(int id, string listDishes, int totalsum, DateTime dateorder, int clientId)
        {
            HistoryOrders? historyOrders = null;
            string error = string.Empty;
            if(!string.IsNullOrEmpty(listDishes) || listDishes.Length >=MAX_LENGTH_LISTDISHES )
            {
                error = "listDishes is null or the allowed number of characters is exceeded";
                return (historyOrders, error);
            }
            if(totalsum < 0)
            {
                error = "invalid totalsum";
                return (historyOrders, error);
            }
            string date = dateorder.ToString();
            if (date[2] != DATE_FORMAT[2] || date[5] != DATE_FORMAT[5] || date[8] != DATE_FORMAT[8] 
                || date[11] != DATE_FORMAT[11] || date[14] != DATE_FORMAT[14])
            {
                error = "invalid date";
                return (historyOrders, error);
            }

            historyOrders = new(id, listDishes, totalsum, dateorder, clientId);
            return (historyOrders, error);
        }

    }
}
