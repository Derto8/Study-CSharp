using System.Windows;
using System.Windows.Controls;
using LearningCShap.Classies.WorkWithDB;

namespace LearningCShap.Pages.Tasks
{
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
                if (pass.Password != "")
                {
                    string login = tb_log.Text;
                    string password = pass.Password;

                    AuthDB auth = new AuthDB();

                    if (auth.AuthAdmin(login, password) == "Administrator")
                    {
                        mainWindow.OpenPage(MainWindow.pages.AdminConsole);
                    }
                    else if (auth.AuthUser(login, password).Rows.Count > 0)
                    {
                        auth.loginUser = login;
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

