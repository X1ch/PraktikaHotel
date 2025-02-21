using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hotel.AppData;

namespace Hotel.Pages
{
    /// <summary>
    /// Логика взаимодействия для employeePage.xaml
    /// </summary>
    public partial class employeePage : Page
    {
        public employeePage()
        {
            InitializeComponent();
            EmployeeDG.ItemsSource = Connect.context.employee.ToList();
            combobox1.ItemsSource = Connect.context.employee.Select(x=>x.post).ToList().Distinct().ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditEmployee(null));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            EmployeeDG.ItemsSource = Connect.context.employee.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//edit
        {
            Nav.MainFrame.Navigate(new AddEditEmployee((sender as Button).DataContext as employee));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var delemployee = EmployeeDG.SelectedItems.Cast<employee>().ToList();
            foreach(var delemployes in delemployee)
                if (Connect.context.service.Any(x=>x.id_employee == delemployes.id_employee))
                {
                    MessageBox.Show("Данные используются в другой таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            if (MessageBox.Show($"Удалить{delemployee.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            Connect.context.employee.RemoveRange(delemployee);
            try
            {
                Connect.context.SaveChanges();
                EmployeeDG.ItemsSource = Connect.context.employee.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void SortBtn_Click(object sender, RoutedEventArgs e)
        {
            var sortedEmployees = Connect.context.employee.OrderBy(r => r.fio).ToList();
            EmployeeDG.ItemsSource = sortedEmployees;
        }

        private void FilterBtn_Click(object sender, RoutedEventArgs e)
        {
            var filterEmployee = combobox1.SelectedItem.ToString();
            var employees = Connect.context.employee.ToList();
            var filteredEmployees = employees.Where(r => r.post == filterEmployee).ToList();
            EmployeeDG.ItemsSource = filteredEmployees;
        }

        private void searchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            EmployeeDG.ItemsSource = Connect.context.employee.ToList().Where(r => r.fio.ToLower().Contains(searchTB.Text.ToString().ToLower())).ToList();

        }
    }
}
