using DataBaseRestaurant.Core.Abstraction.IService;
using DataBaseRestaurant.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace DataBaseRestaurant
{
    partial class Form1
    {
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

    }

}

