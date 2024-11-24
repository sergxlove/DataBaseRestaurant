using DataBaseRestaurant.Application.Services;
using DataBaseRestaurant.Core.Abstraction.IRepository;
using DataBaseRestaurant.Core.Abstraction.IService;
using DataBaseRestaurant.DataAccess.Sqlite;
using DataBaseRestaurant.DataAccess.Sqlite.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace DataBaseRestaurant
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _serviceColection = new ServiceCollection();
            _serviceColection.AddDbContext<RestaurantDbContext>();
            _serviceColection.AddSingleton<IClientsRepository, ClientsRepository>();
            _serviceColection.AddSingleton<IHistoryOrdersRepository, HistoryOrdersRepository>();
            _serviceColection.AddSingleton<IIngredientsRepository, IngredientsRepository>();
            _serviceColection.AddSingleton<IMenuRepository, MenuRepository>();
            _serviceColection.AddSingleton<IOrdersRepository, OrdersRepository>();
            _serviceColection.AddSingleton<ISuppliersRepository, SuppliersRepository>();
            _serviceColection.AddSingleton<ITablesRepository, TablesRepository>();
            _serviceColection.AddSingleton<IWorkersRepository, WorkersRepository>();
            _serviceColection.AddSingleton<IClientsService, ClientsService>();
            _serviceColection.AddSingleton<IHistoryOrdersService, HistoryOrdersService>();
            _serviceColection.AddSingleton<IIngredientsService, IngredientsService>();
            _serviceColection.AddSingleton<IMenuService, MenuService>();
            _serviceColection.AddSingleton<IOrdersService, OrdersService>();
            _serviceColection.AddSingleton<ISuppliersService, SuppliersService>();
            _serviceColection.AddSingleton<ITablesService, TablesService>();
            _serviceColection.AddSingleton<IWorkersService, WorkersService>();
            _serviceProvider = _serviceColection.BuildServiceProvider();
        }

        private ServiceCollection _serviceColection;
        private ServiceProvider _serviceProvider;

        private async void button2_Click(object sender, EventArgs e)
        {
            var clientService = _serviceProvider.GetService<IClientsService>();
            var clients = await clientService!.GetAllClientsAsync();
            StringBuilder clientString = new StringBuilder();
            foreach (var client in clients)
            {
                clientString.Append($"ID: {client.Id} \r\nName: {client.Name} \r\nEmail: {client.Email}\r\n" +
                    $"Preferences: {client.Preferences} \r\nOrderID: {client.OrderId} \r\n");
                clientString.Append("\r\n");
            }
            textBox1.Text = clientString.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var workersService = _serviceProvider.GetService<IWorkersService>();
        }
    }
}
