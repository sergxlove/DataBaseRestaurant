using DataBaseRestaurant.Application.Services;
using DataBaseRestaurant.Core.Abstraction.IRepository;
using DataBaseRestaurant.Core.Abstraction.IService;
using DataBaseRestaurant.Core.Models;
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

        private async void button9_Click(object sender, EventArgs e)
        {
            try
            {
                var worker = Workers.Create(Convert.ToInt32(idWorkerBox.Text), nameWorkerBox.Text,
                    emailWorkerBox.Text, numberPhoneWorkersBox.Text, positionWorkerBox.Text,
                    Convert.ToInt32(salaryWorkersBox.Text));
                if (!string.IsNullOrEmpty(worker.error))
                {
                    throw new Exception(worker.error);
                }
                var workersService = _serviceProvider.GetService<IWorkersService>();
                var checkIdWorker = await workersService!.GetWorkerByIdAsync(Convert.ToInt32(idWorkerBox.Text));
                if (checkIdWorker is not null)
                {
                    throw new Exception("an worker with this id already exists");
                }
                await workersService!.AddNewWorkerAsync(worker.worker!);
                outputAddWorkers.Text = "done";
            }
            catch (Exception ex)
            {
                if (ex.Message.Length >= 45)
                {
                    MessageBox.Show(ex.Message);
                }
                else
                {
                    outputAddWorkers.Text = ex.Message;
                }
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            var workerService = _serviceProvider.GetService<IWorkersService>();
            var workers = await workerService!.GetAllWorkersAsync();
            StringBuilder workersString = new StringBuilder();
            foreach (var worker in workers)
            {
                workersString.Append($"ID: {worker.Id} \r\nName: {worker.Name} \r\nEmail: {worker.Email} \r\n" +
                    $"Number phone: {worker.NumberPhone} \r\nPosition: {worker.Position} \r\n" +
                    $"Salary: {worker.Salary}\r\n");
                workersString.Append("\r\n");
            }
            dataWorkersTB.Text = workersString.ToString();
            outputGetWorkers.Text = "done";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private async void button7_Click(object sender, EventArgs e)
        {
            try
            {
                var workerService = _serviceProvider.GetService<IWorkersService>();
                var worker = await workerService!.GetWorkerByIdAsync(Convert.ToInt32(idForGetWorker.Text));
                if (worker is null)
                {
                    outputGetWorkers.Text = "not found element";
                }
                else
                {
                    dataWorkersTB.Text = $"ID: {worker.Id} \r\nName: {worker.Name} \r\nEmail: {worker.Email} \r\n" +
                        $"Number phone: {worker.NumberPhone} \r\nPosition: {worker.Position} \r\n" +
                        $"Salary: {worker.Salary}\r\n";
                    outputGetWorkers.Text = "done";
                }
            }
            catch(Exception ex)
            {
                if (ex.Message.Length >= 45)
                {
                    MessageBox.Show(ex.Message);
                }
                else
                {
                    outputGetWorkers.Text = ex.Message;
                }
            }
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            try
            {
                var worker = Workers.Create(Convert.ToInt32(idWorkerBox.Text), nameWorkerBox.Text,
                        emailWorkerBox.Text, numberPhoneWorkersBox.Text, positionWorkerBox.Text,
                        Convert.ToInt32(salaryWorkersBox.Text));
                if (!string.IsNullOrEmpty(worker.error))
                {
                    throw new Exception(worker.error);
                }
                var workerService = _serviceProvider.GetService<IWorkersService>();
                int result = await workerService!.UpdateWorkerAsync(worker.worker!);
                if (result == 0)
                {
                    outputAddWorkers.Text = "not found element";
                }
                else
                {
                    outputAddWorkers.Text = "done";
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Length >= 45)
                {
                    MessageBox.Show(ex.Message);
                }
                else
                {
                    outputAddWorkers.Text = ex.Message;
                }
            }
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            try
            {
                var workerService = _serviceProvider.GetService<IWorkersService>();
                int result = await workerService!.DeleteWorkerAsync(Convert.ToInt32(idForDeleteWorker.Text));
                if(result == 0)
                {
                    outputDeleteWorker.Text = "not found element";
                }
                else
                {
                    outputDeleteWorker.Text = "done";
                }
            }
            catch (Exception ex) 
            {
                if (ex.Message.Length >= 45)
                {
                    MessageBox.Show(ex.Message);
                }
                else
                {
                    outputDeleteWorker.Text = ex.Message;
                }
            }
        }
    }
}
