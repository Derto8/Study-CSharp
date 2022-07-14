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

namespace WpfProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OpenPage(pages.main);
        }

        public enum pages
        {
            main,
            generate,
            auth,
            reg,
            afterAuth,
            AdminConsole
        }

        public void OpenPage(pages _pages)
        {
            if (_pages == pages.main)
                frame.Navigate(new Pages.Main(this));
            else if (_pages == pages.generate)
                frame.Navigate(new Pages.Tasks.GeneratePasswords(this));
            else if (_pages == pages.auth)
                frame.Navigate(new Pages.Tasks.Authorization(this));
            else if (_pages == pages.reg)
                frame.Navigate(new Pages.Tasks.Registration(this));
            else if (_pages == pages.afterAuth)
                frame.Navigate(new Pages.Tasks.After_auth.AfterAuth(this));
            else if (_pages == pages.AdminConsole)
                frame.Navigate(new Pages.Tasks.After_auth.AdminConsole(this));
        }
    }
}
