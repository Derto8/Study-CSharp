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
using System.IO;

namespace WpfProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        MainWindow mainWindow;
        public Main(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть приложение?", "Уведомление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                mainWindow.Close();
            }
        }

        private void OpenGenerator(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.generate);
        }

        private void OpenDB(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.database);
        }
    }
}
