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
using MySql.Data.MySqlClient;
using System.Data;

namespace WpfProject.Pages.Tasks
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        MainWindow mainWindow;
        public Registration(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }


        private void Back(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.main);
        }

        private void Regist(object sender, RoutedEventArgs e)
        {
            if(tb_log.Text != "")
            {
                if(pass.Password != "")
                {
                    if(passRepeat.Password != "")
                    {
                        string login = tb_log.Text;
                        string password = pass.Password;
                        string passRep = passRepeat.Password;
                        if(password != passRep)
                        {
                            Rez.Content = "Введенные пароли не совпадают";
                            return;
                        }
                        if (isUserExists())
                            return;

                        Classies.DataBaseCL db = new Classies.DataBaseCL();

                        MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `password`) VALUES (@regL, @regP)", db.getConnection());
                        command.Parameters.Add("@regL", MySqlDbType.VarChar).Value = login;
                        command.Parameters.Add("@regP", MySqlDbType.VarChar).Value = password;

                        db.openConnection();
                        if(command.ExecuteNonQuery() == 1)
                        {
                            Rez.Content = "Юзер создан";
                            invisible.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            Rez.Content = "Юзер не создан";
                        }


                        db.closeConnection();


                    }
                }
            }
        }

        public Boolean isUserExists()
        {
            string login = tb_log.Text;
            Classies.DataBaseCL db = new Classies.DataBaseCL();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                Rez.Content = "Пользователь с таким же логином уже существует";
                return true;
            }
            else
            {
                return false;
            }
        }


        private void Auth(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.auth);

        }
    }
}
