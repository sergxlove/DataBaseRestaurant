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
                if (supplier is not null)
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
            catch (Exception ex)
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
            catch (Exception ex)
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

        private async void button9_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                var workersService = _serviceProvider.GetService<IWorkersService>();
                if (autoIdWorkers.Checked == true)
                {
                    var listId = await workersService!.GetAllIdWorkersAsync();
                    id = listId.Max() + 1;
                }
                else
                {
                    id = Convert.ToInt32(idWorkerBox.Text);
                }
                var worker = Workers.Create(id, nameWorkerBox.Text,
                    emailWorkerBox.Text, numberPhoneWorkersBox.Text, positionWorkerBox.Text,
                    Convert.ToInt32(salaryWorkersBox.Text));
                if (!string.IsNullOrEmpty(worker.error))
                {
                    throw new Exception(worker.error);
                }
                var checkIdWorker = await workersService!.GetWorkerByIdAsync(id);
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
                if (result == 0)
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

        private async void comboBox2_Click(object sender, EventArgs e)
        {
            idSupplierComboBox.Items.Clear();
            var suppliersService = _serviceProvider.GetService<ISuppliersService>();
            var suppliersId = await suppliersService!.GetAllIdSuppliersAsync();
            if (suppliersId.Count == 0)
            {
                idSupplierComboBox.Items.Add("not elements");
            }
            foreach (var id in suppliersId)
            {
                idSupplierComboBox.Items.Add(id);
            }
        }

        private async void button19_Click(object sender, EventArgs e)
        {
            var ingredientsService = _serviceProvider.GetService<IIngredientsService>();
            var ingredients = await ingredientsService!.GetAllIngredientsAsync();
            StringBuilder ingredientsString = new();
            foreach (var ingredient in ingredients)
            {
                ingredientsString.Append($"ID: {ingredient.Id} \r\nName: {ingredient.Name} \r\n" +
                    $"Weight: {ingredient.Weight} \r\nCount in warehouse: {ingredient.QuantityInWareHouse} \r\n" +
                    $"ID supplier: {ingredient.SupplierId} \r\n");
                ingredientsString.Append("\r\n");
            }
            dataIngredientsTB.Text = ingredientsString.ToString();
            outputGetIngredients.Text = "done";
        }

        private async void button20_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(idForGetIngredients.Text);
                var ingredientsService = _serviceProvider.GetService<IIngredientsService>();
                var ingredient = await ingredientsService!.GetIngredientsByIdAsync(id);
                if (ingredient is not null)
                {
                    outputGetIngredients.Text = "done";
                    dataIngredientsTB.Text = $"ID: {ingredient.Id} \r\nName: {ingredient.Name} \r\n" +
                    $"Weight: {ingredient.Weight} \r\nCount in warehouse: {ingredient.QuantityInWareHouse} \r\n" +
                    $"ID supplier: {ingredient.SupplierId} \r\n";
                }
                else
                {
                    outputGetIngredients.Text = "not found element";
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
                    outputGetIngredients.Text = ex.Message;
                }
            }
        }

        private async void button31_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                var ingredientsService = _serviceProvider.GetService<IIngredientsService>();
                if (autoIdIngredients.Checked == true)
                {
                    var listId = await ingredientsService!.GetAllIdIngredientsAsync();
                    id = listId.Max() + 1;
                }
                else
                {
                    id = Convert.ToInt32(idIngredientsBox.Text);
                }
                var ingredient = Ingredients.Create(id, nameIngredientsBox.Text,
                    Convert.ToInt32(weightIngredientBox.Text), Convert.ToInt32(countInWareIngredientsBox.Text),
                    Convert.ToInt32(idSupplierComboBox.Text));
                if (!string.IsNullOrEmpty(ingredient.error))
                {
                    throw new Exception(ingredient.error);
                }
                var checkIdSupplier = await ingredientsService!.GetIngredientsByIdAsync(id);
                if (checkIdSupplier is not null)
                {
                    throw new Exception("an ingredients with this id already exists");
                }
                await ingredientsService.AddNewIngredientsAsync(ingredient.ingredients!);
                outputAddIngredients.Text = "done";
            }
            catch (Exception ex)
            {
                if (ex.Message.Length >= 45)
                {
                    MessageBox.Show(ex.Message);
                }
                else
                {
                    outputAddIngredients.Text = ex.Message;
                }
            }
        }

        private async void button30_Click_1(object sender, EventArgs e)
        {
            try
            {
                var ingredient = Ingredients.Create(Convert.ToInt32(idIngredientsBox.Text), nameIngredientsBox.Text,
                    Convert.ToInt32(weightIngredientBox.Text), Convert.ToInt32(countInWareIngredientsBox.Text),
                    Convert.ToInt32(idSupplierComboBox.Text));
                if (!string.IsNullOrEmpty(ingredient.error))
                {
                    throw new Exception(ingredient.error);
                }
                var ingredientsService = _serviceProvider.GetService<IIngredientsService>();
                int result = await ingredientsService!.UpdateIngredientsAsync(ingredient.ingredients!);
                if (result == 0)
                {
                    outputAddIngredients.Text = "not found element";
                }
                else
                {
                    outputAddIngredients.Text = "done";
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
                    outputAddIngredients.Text = ex.Message;
                }
            }
        }

        private async void button14_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(idForDeleteIngredients.Text);
                var ingredientsService = _serviceProvider.GetService<IIngredientsService>();
                int result = await ingredientsService!.DeleteIngredientsAsync(id);
                if (result == 0)
                {
                    outputDeleteIngredients.Text = "not found element";
                }
                else
                {
                    outputDeleteIngredients.Text = "done";
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
                    outputDeleteIngredients.Text = ex.Message;
                }
            }
        }
    }
}
