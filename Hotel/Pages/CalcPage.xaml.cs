using Hotel.AppData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для CalcPage.xaml
    /// </summary>
    public partial class CalcPage : Page
    {
        public CalcPage()
        {
            InitializeComponent();
            var s = Connect.context.register.Select(x => new
            {
                x.id_register,
                x.apartment,
                x.service_register,
                x.date_register,
                x.date_out,
                x.id_client,
                x.client,
                SumReg = (decimal)DbFunctions.DiffDays(x.date_register, x.date_out) * x.apartment.price_day + x.service_register.Sum(t => t.kolvo * t.service.price_service)
            }).ToList();
            RegisterDG.ItemsSource = s;
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
    }
}
