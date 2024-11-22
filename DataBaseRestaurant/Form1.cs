using DataBaseRestaurant.Application.Services;
using DataBaseRestaurant.Core.Abstraction.IRepository;
using DataBaseRestaurant.Core.Abstraction.IService;
using DataBaseRestaurant.DataAccess.Sqlite;
using DataBaseRestaurant.DataAccess.Sqlite.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DataBaseRestaurant
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            serviceColection = new ServiceCollection();
            serviceColection.AddDbContext<RestaurantDbContext>();
            serviceColection.AddSingleton<IClientsRepository, ClientsRepository>();
            serviceColection.AddSingleton<IHistoryOrdersRepository, HistoryOrdersRepository>();
            serviceColection.AddSingleton<IIngredientsRepository, IngredientsRepository>();
            serviceColection.AddSingleton<IMenuRepository, MenuRepository>();
            serviceColection.AddSingleton<IOrdersRepository, OrdersRepository>();
            serviceColection.AddSingleton<ISuppliersRepository, SuppliersRepository>();
            serviceColection.AddSingleton<ITablesRepository, TablesRepository>();
            serviceColection.AddSingleton<IWorkersRepository, WorkersRepository>();
            serviceColection.AddSingleton<IClientsService, ClientsService>();
            serviceColection.AddSingleton<IHistoryOrdersService, HistoryOrdersService>();
            serviceColection.AddSingleton<IIngredientsService, IngredientsService>();
            serviceColection.AddSingleton<IMenuService, MenuService>();
            serviceColection.AddSingleton<IOrdersService, OrdersService>();
            serviceColection.AddSingleton<ISuppliersService, SuppliersService>();
            serviceColection.AddSingleton<ITablesService, TablesService>();
            serviceColection.AddSingleton<IWorkersService, WorkersService>();
        }

        private ServiceCollection serviceColection;

    }
}
