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
using System.Data;
using MySql.Data.MySqlClient;
using WpfProject.Pages.Classies;


namespace WpfProject.Pages.Tasks
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        MainWindow mainWindow;
        public Authorization(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }


        private void Back(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.main);
        }

        private void Auth(object sender, RoutedEventArgs e)
        {
            if (tb_log.Text != "")
            {
                if(pass.Password != "")
                {
                    string login = tb_log.Text;
                    string password = pass.Password;
                    //Объект ранее созданного класса DataBaseCL
                    DataBaseConnection db = new DataBaseConnection();

                    //объект таблицы 
                    DataTable table = new DataTable();

                    MySqlDataAdapter adapter = new MySqlDataAdapter();


                    //авторизация пользователя
                    MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `password` = @uP", db.GetConnection());
                    command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
                    command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = password;
                    adapter.SelectCommand = command;

                    adapter.Fill(table);

                    
                    //авторизация администратора
                    MySqlCommand commandStatus = new MySqlCommand("SELECT `status` FROM `users` WHERE `login` = @uL AND `password` = @uP", db.OpenConnection());
                    commandStatus.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
                    commandStatus.Parameters.Add("@uP", MySqlDbType.VarChar).Value = password;

                    MySqlDataReader reader = commandStatus.ExecuteReader();

                    string status = "";

                    while (reader.Read())
                    {
                        status = reader[0].ToString();
                    }
                    reader.Close();
                    db.CloseConnection();

                    if(status == "Administrator")
                    {
                        mainWindow.OpenPage(MainWindow.pages.AdminConsole);
                    }
                    else if(table.Rows.Count > 0)
                    {
                        mainWindow.OpenPage(MainWindow.pages.afterAuth);
                    }
                    else
                    {
                        Rez.Content = "Неправильный логин или пароль";
                    }
                }
            }
        }

        private void Regist(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.reg);
        }
    }
}
