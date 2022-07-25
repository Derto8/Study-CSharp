using System;
using LearningCShap.Classies.WorkWithDB;
using System.Windows;
using System.Windows.Controls;
using LearningCShap.Classies.PasswordGenerate;
using System.Windows.Media;
using MySql.Data.MySqlClient;

namespace LearningCShap.Pages.Tasks
{
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
            if (tb_log.Text != "")
            {
                if (pass.Password != "")
                {
                    if (passRepeat.Password != "")
                    {
                        string login = tb_log.Text;
                        string password = pass.Password;
                        string passRep = passRepeat.Password;
                        string status = "User";

                        if (login.Length < 4 || login.Length > 16)
                        {
                            Rez.Content = "Логин должен быть не менее 6 знаков, и не более 16 знаков";
                            tb_log.Background = Brushes.Gray;
                            return;
                        }

                        //проверка пароля
                        if (password != passRep)
                        {
                            Rez.Content = "Введенные пароли не совпадают";
                            pass.Background = Brushes.Gray;
                            return;
                        }

                        if (password.Length < 6)
                        {
                            Rez.Content = "Пароль должен быть не менее 6 знаков";
                            pass.Background = Brushes.Gray;
                            return;
                        }

                        Random rd = new Random();

                        PasswordGen pgen = new PasswordGen(rd.Next(6, 12));

                        bool checkNum = pgen.CheckPassNum(password);
                        bool checkAlph = pgen.CheckPassAlph(password);

                        if (!checkNum)
                        {
                            Rez.Content = "Пароль должен содержать цифры!";
                            pass.Background = Brushes.Gray;

                            return;
                        }
                        if (!checkAlph)
                        {
                            Rez.Content = "Пароль должен содержать хотя бы одну заглавную букву!";
                            pass.Background = Brushes.Gray;
                            return;
                        }

                        AuthDB checkUserExists = new AuthDB();

                        if (checkUserExists.isUserExists(login))
                        {
                            string text = "Пользователь с таким же логином уже существует!";
                            Rez.Content = text;
                            return;
                        }




                        //Объект ранее созданного класса DataBaseCL
                        DataBaseConnection db = new DataBaseConnection();


                        //добавление пользователя
                        MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `password`, `status`) VALUES (@regL, @regP, @regS)", db.GetConnection());
                        command.Parameters.Add("@regL", MySqlDbType.VarChar).Value = login;
                        command.Parameters.Add("@regP", MySqlDbType.VarChar).Value = password;
                        command.Parameters.Add("@regS", MySqlDbType.VarChar).Value = status;

                        //
                        db.OpenConnection();
                        if (command.ExecuteNonQuery() == 1)
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


        private void Auth(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.auth);
        }
    }
}
