using System.Collections.Generic;
using System.Windows;
using LearningCShap.Classies.WorkWithDB;
using MySql.Data.MySqlClient;
using System.Windows.Controls;

namespace LearningCShap.Pages.Tasks.AfterAuth.AdminConsole
{
    public partial class InformationDB : Page
    {
        MainWindow mainWindow;
        public InformationDB(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;

            DataBaseConnection db = new DataBaseConnection();

            MySqlConnection connection = db.GetConnection();

            db.OpenConnection();

            List<string> infConnection = new List<string>
            {
                connection.ConnectionString,
                connection.Database,
                connection.DataSource,
                connection.ServerVersion
            };

            string[] infText = new string[]
            {
                "Строка подключения: ",
                "База данных: ",
                "Сервер: ",
                "Версия сервера: "
            };

            label.Content = "Состояние подключения: " + connection.State;

            int i = 0;

            foreach (string someInf in infConnection)
            {
                lb.Items.Add(infText[i] + someInf);
            }

            db.CloseConnection();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.AdminConsole);
        }
    }
}
