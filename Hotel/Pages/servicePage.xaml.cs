using Hotel.AppData;
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

namespace Hotel.Pages
{
    /// <summary>
    /// Логика взаимодействия для servicePage.xaml
    /// </summary>
    public partial class servicePage : Page
    {
        public servicePage()
        {
            InitializeComponent();
            combobox1.ItemsSource = Connect.context.service.Select(x => x.employee.fio).ToList().Distinct().ToList();

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditService(null));
            
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var delservice = ServiceDG.SelectedItems.Cast<service>().ToList();
            foreach (var delservices in delservice)
                if (Connect.context.service_register.Any(x => x.id_service == delservices.id_service))
                {
                    MessageBox.Show("Данные используются в другой таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            if (MessageBox.Show($"Удалить{delservice.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Connect.context.service.RemoveRange(delservice);
            try
            {
                Connect.context.SaveChanges();
                ServiceDG.ItemsSource = Connect.context.employee.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditService((sender as Button).DataContext as service));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ServiceDG.ItemsSource = Connect.context.service.ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void SortBtn_Click(object sender, RoutedEventArgs e)
        {
            var sortedServices = Connect.context.service.OrderBy(r => r.price_service).ToList();
            ServiceDG.ItemsSource = sortedServices;
        }

        private void FilterBtn_Click(object sender, RoutedEventArgs e)
        {
            var filterService = combobox1.SelectedItem.ToString();
            var services = Connect.context.service.ToList();
            var a = combobox1.SelectedItem.ToString();
            var filteredServices = services.Where(r => r.employee.fio == filterService).ToList();
            ServiceDG.ItemsSource = filteredServices;
        }

        private void searchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            ServiceDG.ItemsSource = Connect.context.service.ToList().Where(r => r.name_service.ToLower().Contains(searchTB.Text.ToString().ToLower())).ToList();
        }
    }
}
