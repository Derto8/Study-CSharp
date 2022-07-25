using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using LearningCShap.Classies.WorkWithDB;


namespace LearningCShap.Pages.Tasks.AfterAuth.AdminConsole
{
    public partial class ManipulationsDB : Page
    {
        DataGridColumn CurrentColumn = null;

        MainWindow mainWindow;
        public ManipulationsDB(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            AdminConsoleDB admin = new AdminConsoleDB();
            admin.SelectAllUsers(dbGrid);
        }

        private void AddUser(object sender, RoutedEventArgs e)
        {
            if (tb_log.Text != "")
                if (tb_pass.Text != "")
                {
                    string login = tb_log.Text;
                    string password = tb_pass.Text;
                    string status = "User";
                    if (Check.IsChecked == true)
                    {
                        status = "Administrator";
                    }
                    AdminConsoleDB admin = new AdminConsoleDB();
                    admin.AddUser(login, password, status, addUser);
                    admin.SelectAllUsers(dbGrid);
                }
        }

        private void BeginEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            try
            {
                DataRowView dataRow = (DataRowView)dbGrid.SelectedItem;
                int index = dbGrid.CurrentCell.Column.DisplayIndex;
                string cellValueSt = dataRow.Row.ItemArray[index].ToString();

                if (index == 1 || index == 2 || index == 3)
                {
                    MessageBox.Show("Выберите id пользователя!");
                }

                int cellValue = Convert.ToInt32(cellValueSt);

                AdminConsoleDB admin = new AdminConsoleDB();
                admin.DeleteUser(cellValue);
                admin.SelectAllUsers(dbGrid);
            }

            catch
            {
            }
        }

        private void dbGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dataGrid = (DataGrid)sender;
            if (CurrentColumn != null)
                CurrentColumn.CellStyle = null;
            CurrentColumn = dataGrid.CurrentColumn;
            if (CurrentColumn != null)
                CurrentColumn.CellStyle = (Style)dataGrid.Resources["SelectedColumnStyle"];
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.AdminConsole);
        }
    }
}
