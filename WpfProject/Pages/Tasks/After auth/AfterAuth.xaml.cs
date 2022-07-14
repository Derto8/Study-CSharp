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
using WpfProject.Pages.Classies;

namespace WpfProject.Pages.Tasks.After_auth
{
    /// <summary>
    /// Логика взаимодействия для AfterAuth.xaml
    /// </summary>
    public partial class AfterAuth : Page
    {
        MainWindow mainWindow;
        public AfterAuth(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.main);
        }
    }
}
