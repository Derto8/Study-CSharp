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
                    Classies.DataBaseCL db = new Classies.DataBaseCL();
                    DataTable table = new DataTable();

                    MySqlDataAdapter adapter = new MySqlDataAdapter();

                    MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `password` = @uP", db.getConnection());
                    command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
                    command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = password;
                    adapter.SelectCommand = command;
                    adapter.Fill(table);

                    if(table.Rows.Count > 0)
                    {
                        Rez.Content = "Юзер присутствует в бд";
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
            mainWindow.OpenPage(MainWindow.pages.regist);
        }
    }
}
