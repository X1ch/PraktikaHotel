 using Hotel.AppData;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Excel = Microsoft.Office.Interop.Excel;


namespace Hotel.Pages
{
    public partial class registerPage : Page
    {
        public registerPage()
        {
            InitializeComponent();
            RegisterDG.ItemsSource = Connect.context.register.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditRegister(null));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var delregister = RegisterDG.SelectedItems.Cast<register>().ToList();
            if (MessageBox.Show($"Удалить{delregister.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Connect.context.register.RemoveRange(delregister);
            try
            {
                Connect.context.SaveChanges();
                RegisterDG.ItemsSource = Connect.context.employee.ToList();
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

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.Navigate(new AddEditRegister((sender as Button).DataContext as register));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RegisterDG.ItemsSource = Connect.context.register.ToList();
            
        }

        private void ExcelBtn_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application app = new Excel.Application
            {
                Visible = true,
                SheetsInNewWorkbook = 1
            };
            Excel.Workbook workBook = app.Workbooks.Add(Type.Missing);
            app.DisplayAlerts = false;
            Excel.Worksheet sheet = (Excel.Worksheet)app.Worksheets.get_Item(1);
            sheet.Name = "Журнал регистрация";

            for (int i = 0; i < RegisterDG.Columns.Count; i++)
            {
                sheet.Cells[1, i + 1] = RegisterDG.Columns[i].Header;
            }

            for (int row = 0; row < RegisterDG.Items.Count; row++)
            {
                var item = RegisterDG.Items[row];
                for (int col = 0; col < RegisterDG.Columns.Count; col++)
                {

                    var cellValue = (RegisterDG.Columns[col].GetCellContent(item) as TextBlock)?.Text;
                    sheet.Cells[row + 2, col + 1] = cellValue;
                }
            }
        }

        private void SortBtn_Click(object sender, RoutedEventArgs e)
        {
            var registers = Connect.context.register.ToList();
            var sortedRegisters = registers.OrderByDescending(r => r.date_register).ToList();
            RegisterDG.ItemsSource = sortedRegisters;
        }

        private void FilterBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime filterDate = datePicker.SelectedDate ?? DateTime.MinValue;
            var registers = Connect.context.register.ToList();
            var filteredRegisters = registers.Where(r => r.date_register >= filterDate).ToList();
            RegisterDG.ItemsSource = filteredRegisters;
        }


            

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            RegisterDG.ItemsSource = Connect.context.register.ToList().Where(r => r.client.fio.ToLower().Contains(searchTB.Text.ToString().ToLower())).ToList();
        }
    }
}
