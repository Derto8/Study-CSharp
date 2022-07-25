using System;
using LearningCShap.Classies.WorkWithDB;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace LearningCShap.Pages.Tasks.AfterAuth.AdminConsole
{
    public partial class AdminConsole : Page
    {
        MainWindow mainWindow;

        DataGridColumn CurrentColumn = null;

        int idUser;

        public AdminConsole(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            AdminConsoleDB admin = new AdminConsoleDB();
            admin.SelectAllUsers(dbGrid);
            label.Content = $"Количество пользователей в базе данных: {admin.CountUsers()}";
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.main);
        }

        private void Information(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.infBD);
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dataGrid = (DataGrid)sender;
            if (CurrentColumn != null)
                CurrentColumn.CellStyle = null;
            CurrentColumn = dataGrid.CurrentColumn;
            if (CurrentColumn != null)
                CurrentColumn.CellStyle = (Style)dataGrid.Resources["SelectedColumnStyle"];

            try
            {
                DataRowView dataRow = (DataRowView)dbGrid.SelectedItem;
                int index = dbGrid.CurrentCell.Column.DisplayIndex;
                string cellValueSt = dataRow.Row.ItemArray[index].ToString();

                if (index == 1 || index == 2 || index == 3)
                {
                    MessageBox.Show("Выберите id пользователя, для изменения данных!");
                }

                int cellValue = Convert.ToInt32(cellValueSt);

                idUser = cellValue;
            }

            catch { }

        }

        private void EditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (idUser >= 0)
            {
                string elementEndEdit;
                string nameColumn;

                TextBox elem = e.EditingElement as TextBox;
                elementEndEdit = elem.ToString();
                elementEndEdit = elementEndEdit.Replace("System.Windows.Controls.TextBox: ", "");


                DataGridColumn column = e.Column;
                nameColumn = column.Header.ToString();

                AdminConsoleDB admin = new AdminConsoleDB();
                admin.Update(elementEndEdit, nameColumn, idUser);
            }
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.manipulationsBD);
        }
    }
}
