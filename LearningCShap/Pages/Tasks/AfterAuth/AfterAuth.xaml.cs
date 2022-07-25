using System.Windows;
using System.Windows.Controls;

namespace LearningCShap.Pages.Tasks.AfterAuth
{
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

        private void Calculator(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.calculator);
        }

        private void ASCIIPictire(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.ASCIIPicture);
        }
    }
}
