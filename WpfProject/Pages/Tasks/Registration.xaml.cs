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
using WpfProject.Pages.Classies;

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
                        string status = "User";

                        if(login.Length < 6 || login.Length > 16 )
                        {
                            Rez.Content = "Логин должен быть не менее 6 знаков, и не более 16 знаков";
                            return;
                        }

                        //проверка пароля
                        if(password != passRep)
                        {
                            Rez.Content = "Введенные пароли не совпадают";
                            return;
                        }

                        if(password.Length < 6)
                        {
                            Rez.Content = "Пароль должен быть не менее 6 знаков";
                            return;
                        }

                        Random rd = new Random();
                        
                        PasswordGen pgen = new PasswordGen(rd.Next(6, 12));

                        bool checkNum = pgen.CheckPassNum(password);
                        bool checkAlph = pgen.CheckPassAlph(password);

                        if(!checkNum)
                        {
                            Rez.Content = "Пароль должен содержать цифры!";
                            return;
                        }
                        if (!checkAlph)
                        {
                            Rez.Content = "Пароль должен содержать хотя бы одну заглавную букву!";
                            return;
                        }

                        if (isUserExists())
                            return;





                        //Объект ранее созданного класса DataBaseCL
                        DataBaseConnection db = new DataBaseConnection();


                        //добавление пользователя
                        MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `password`, `status`) VALUES (@regL, @regP, @regS)", db.GetConnection());
                        command.Parameters.Add("@regL", MySqlDbType.VarChar).Value = login;
                        command.Parameters.Add("@regP", MySqlDbType.VarChar).Value = password;
                        command.Parameters.Add("@regS", MySqlDbType.VarChar).Value = status;

                        //
                        db.OpenConnection();
                        if(command.ExecuteNonQuery() == 1)
                        {
                            Rez.Content = "Юзер создан";
                            invisible.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            Rez.Content = "Юзер не создан";
                        }


                        db.CloseConnection();


                    }
                }
            }
        }

        //проверка, на наличие пользователя в бд с таким же логином
        public bool isUserExists()
        {
            string login = tb_log.Text;
            DataBaseConnection db = new DataBaseConnection();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", db.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                Rez.Content = "Пользователь с таким же логином уже существует!";
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
