using Hotel.AppData;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace Hotel.Pages
{
    public partial class AddEditRegister : Page
    {
        register registers;
        ObservableCollection<service_register> service_registers;
        bool checkNew;

        public AddEditRegister(register c)
        {
            InitializeComponent();
            if (c == null)
            {
                c = new register() { client = Connect.context.client.FirstOrDefault(), apartment = Connect.context.apartment.FirstOrDefault()};
                checkNew = true;
            }
            else
                checkNew = false;
            DataContext = registers = c;
            service_registers = new ObservableCollection<service_register>(registers.service_register.ToList());
            Update();
            combobox1.ItemsSource = Connect.context.client.ToList();
            combobox2.ItemsSource = Connect.context.apartment.ToList();
     
 
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            registers.service_register = service_registers;
            if(checkNew)
                if(ServRegDG.Items.Count !=0)
                    Connect.context.register.Add(registers);
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

        private void Update()
        {
            ServRegDG.ItemsSource = service_registers;
            combobox3.ItemsSource = Connect.context.service.ToList().Except(ServRegDG.ItemsSource.Cast<service_register>().Select(x => x.service).ToList()).ToList();
            stackPanel.Visibility = combobox3.ItemsSource.Cast<service>().ToList().Count == 0? Visibility.Collapsed : Visibility.Visible;
            combobox3.SelectedIndex = 0;
            
        }


        private void ServBtn_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(kolServ.Text, out int n))
            {
                service_registers.Add(new service_register() { register = registers, service = combobox3.SelectedItem as service, kolvo = n});
            }
            //Connect.context.SaveChanges();
            //MessageBox.Show(Connect.context.service_register.Select(x => new{ x.kolvo, x.service.price_service, Sum = x.service.price_service * x.kolvo}).ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var delregister = ServRegDG.SelectedItems.Cast<service_register>().ToList();
            if (MessageBox.Show($"Удалить{delregister.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Connect.context.service_register.RemoveRange(delregister);
            try
            {
                Connect.context.SaveChanges();
                ServRegDG.ItemsSource = Connect.context.register.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        //private void Page_Loaded(object sender, RoutedEventArgs e)
        //{
        //    ServRegDG.ItemsSource = Connect.context.employee.ToList();
        //}
    }
}
