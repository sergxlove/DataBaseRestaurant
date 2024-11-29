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


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private async void button30_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                var supplierService = _serviceProvider.GetService<ISuppliersService>();
                if (autoIdSupplier.Checked == true)
                {
                    var listId = await supplierService!.GetAllIdSuppliersAsync();
                    id = listId.Max() + 1;
                }
                else
                {
                    id = Convert.ToInt32(idSupplierBox.Text);
                }
                var supplier = Suppliers.Create(id, nameSupplierBox.Text, emailSupplierBox.Text,
                    numberPhoneSupplierBox.Text, Convert.ToInt32(rattingSupplierBox.Text));
                if (!string.IsNullOrEmpty(supplier.error))
                {
                    throw new Exception(supplier.error);
                }
                var checkIdSuppler = await supplierService!.GetSupplierByIdAsync(id);
                if (checkIdSuppler is not null)
                {
                    throw new Exception("an supplier with this id already exists");
                }
                await supplierService.AddNewSupplierAsync(supplier.supplier!);
                outputAddSupplier.Text = "done";
            }
            catch (Exception ex)
            {
                if (ex.Message.Length >= 45)
                {
                    MessageBox.Show(ex.Message);
                }
                else
                {
                    outputAddSupplier.Text = ex.Message;
                }
            }
        }

        private void autoIdWorkers_CheckedChanged(object sender, EventArgs e)
        {
            if (autoIdWorkers.Checked == true)
            {
                idWorkerBox.Text = "Auto";
            }
            else
            {
                idWorkerBox.Text = string.Empty;
            }
        }

        private void autoIdSupplier_CheckedChanged(object sender, EventArgs e)
        {
            if (autoIdSupplier.Checked == true)
            {
                idSupplierBox.Text = "Auto";
            }
            else
            {
                idSupplierBox.Text = string.Empty;
            }
        }

        private async void button29_Click(object sender, EventArgs e)
        {
            try
            {
                var supplier = Suppliers.Create(Convert.ToInt32(idSupplierBox.Text), nameSupplierBox.Text, emailSupplierBox.Text,
                    numberPhoneSupplierBox.Text, Convert.ToInt32(rattingSupplierBox.Text));
                if (!string.IsNullOrEmpty(supplier.error))
                {
                    throw new Exception(supplier.error);
                }
                var supplierService = _serviceProvider.GetService<ISuppliersService>();
                int result = await supplierService!.UpdateSupplierAsync(supplier.supplier!);
                if (result == 0)
                {
                    outputAddSupplier.Text = "not found element";
                }
                else
                {
                    outputAddSupplier.Text = "done";
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
                    outputAddSupplier.Text = ex.Message;
                }
            }
        }

        private async void button17_Click(object sender, EventArgs e)
        {
            try
            {
                var supplierService = _serviceProvider.GetService<ISuppliersService>();
                int result = await supplierService!.DeleteSupplierAsync(Convert.ToInt32(idForDeleteSupplier.Text));
                if (result == 0)
                {
                    outputDeleteSupplier.Text = "not found element";
                }
                else
                {
                    outputDeleteSupplier.Text = "done";
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
                    outputDeleteSupplier.Text = ex.Message;
                }
            }
        }

        private async void button25_Click(object sender, EventArgs e)
        {
            var supplierService = _serviceProvider.GetService<ISuppliersService>();
            var suppliers = await supplierService!.GetAllSuppliersAsync();
            StringBuilder supplierString = new();
            foreach (var supplier in suppliers)
            {
                supplierString.Append($"ID: {supplier.Id} \r\nName: {supplier.Name} \r\nEmail: {supplier.Email} " +
                    $"\r\nNumberPhone: {supplier.NumberPhone} \r\nRatting: {supplier.Ratting} \r\n");
                supplierString.Append("\r\n");
            }
            dataSuppliersTB.Text = supplierString.ToString();
            outputGetSupplier.Text = "done";
        }

        private async void button26_Click(object sender, EventArgs e)
        {
            try
            {
                var supplierService = _serviceProvider.GetService<ISuppliersService>();
                var supplier = await supplierService!.GetSupplierByIdAsync(Convert.ToInt32(idForGetSupplier.Text));
                if(supplier is not null)
                {
                    dataSuppliersTB.Text = $"ID: {supplier.Id} \r\nName: {supplier.Name} \r\nEmail: {supplier.Email} " +
                    $"\r\nNumberPhone: {supplier.NumberPhone} \r\nRatting: {supplier.Ratting} \r\n";
                    outputGetSupplier.Text = "done";
                }
                else
                {
                    outputGetSupplier.Text = "";
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
                    outputGetSupplier.Text = ex.Message;
                }
            }
        }
    }
}
