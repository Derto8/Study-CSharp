using System.Windows;
using System.Windows.Controls;

namespace LearningCShap.Pages
{
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

        private void OpenAuth(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.auth);
        }

        private void OpenReg(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.reg);
        }
    }
}
