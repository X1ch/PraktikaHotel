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
    /// Логика взаимодействия для clientPage.xaml
    /// </summary>
    public partial class clientPage : Page
    {
        public clientPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditClient((sender as Button).DataContext as client));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditClient(null));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var delclient = ClientDG.SelectedItems.Cast<client>().ToList();
            foreach (var clients in delclient)
                if (Connect.context.register.Any(x => x.id_client == clients.id_client))
                {
                    MessageBox.Show("Данные используются в другой таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            if (MessageBox.Show($"Удалить{delclient.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Connect.context.client.RemoveRange(delclient);
            try
            {
                Connect.context.SaveChanges();
                ClientDG.ItemsSource = Connect.context.client.ToList();
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ClientDG.ItemsSource = Connect.context.client.ToList();
        }

        private void SortBtn_Click(object sender, RoutedEventArgs e)
        {
            var sortedRegisters = Connect.context.client.OrderBy(r => r.fio).ToList();
            ClientDG.ItemsSource = sortedRegisters;
        }

        private void searchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            ClientDG.ItemsSource = Connect.context.client.ToList().Where(r => r.fio.ToLower().Contains(searchTB.Text.ToString().ToLower())).ToList();

        }
    }
}
