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
    /// Логика взаимодействия для main.xaml
    /// </summary>
    public partial class main : Page
    {
        public main()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new employeePage());
        }
        
        private void ServBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new servicePage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new clientPage());
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new registerPage());
        }
        private void CalcBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new CalcPage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        
    }
}
