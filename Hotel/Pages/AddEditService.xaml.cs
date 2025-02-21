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
    /// Логика взаимодействия для AddEditService.xaml
    /// </summary>
    public partial class AddEditService : Page
    {
        service services;
        bool checkNew;
        public AddEditService(service c)
        {
            InitializeComponent();
            if (c == null)
            {
                c = new service();
                checkNew = true;
            }
            else
                checkNew = false;
            DataContext = services = c;
            combobox1.ItemsSource = Connect.context.employee.ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (checkNew)
            {
                Connect.context.service.Add(services);
            }
            try
            {
                Connect.context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Nav.MainFrame.GoBack();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
    }
}
