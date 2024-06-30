using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using SaveUpp.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;

namespace SaveUpp.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        private const string FileName = "expenses.json";

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private decimal price;

        [ObservableProperty]
        private ObservableCollection<ExpenseItem> expenses;

        [ObservableProperty]
        private decimal totalAmount;

        public MainViewModel()
        {
            Expenses = new ObservableCollection<ExpenseItem>();
            Expenses.CollectionChanged += (s, e) => CalculateTotalAmount();
            LoadExpenses();
        }

        [RelayCommand]
        private void AddExpense()
        {
            if (!string.IsNullOrEmpty(Description) && Price > 0)
            {
                Expenses.Add(new ExpenseItem { Description = Description, Price = Price });
                SaveExpenses();
                Description = string.Empty;
                Price = 0;
            }
        }

        [RelayCommand]
        private void ClearExpense()
        {
            Description = string.Empty;
            Price = 0;
        }

        [RelayCommand]
        private void ClearExpenses()
        {
            Expenses.Clear();
            SaveExpenses();
        }

        private async void SaveExpenses()
        {
            try
            {
                var json = JsonConvert.SerializeObject(Expenses);
                var filePath = Path.Combine(FileSystem.AppDataDirectory, FileName);
                await File.WriteAllTextAsync(filePath, json);
            }
            catch (Exception ex)
            {
                // Fehlerbehandlung (z.B. Logging)
                Console.WriteLine(ex.Message);
            }
        }

        private async void LoadExpenses()
        {
            try
            {
                var filePath = Path.Combine(FileSystem.AppDataDirectory, FileName);
                if (File.Exists(filePath))
                {
                    var json = await File.ReadAllTextAsync(filePath);
                    var expenses = JsonConvert.DeserializeObject<ObservableCollection<ExpenseItem>>(json);
                    if (expenses != null)
                    {
                        Expenses = expenses;
                        Expenses.CollectionChanged += (s, e) => CalculateTotalAmount();
                        CalculateTotalAmount();
                    }
                }
            }
            catch (Exception ex)
            {
                // Fehlerbehandlung (z.B. Logging)
                Console.WriteLine(ex.Message);
            }
        }

        private void CalculateTotalAmount()
        {
            TotalAmount = 0;
            foreach (var expense in Expenses)
            {
                TotalAmount += expense.Price;
            }
            OnPropertyChanged(nameof(TotalAmount));
        }
    }
}
