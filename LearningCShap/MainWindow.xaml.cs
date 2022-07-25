using System.Windows;
using System.Windows.Navigation;

namespace LearningCShap
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OpenPage(pages.ASCIIPicture);
        }

        public enum pages
        {
            main,
            generate,
            auth,
            reg,
            afterAuth,
            AdminConsole,
            infBD,
            calculator,
            manipulationsBD,
            ASCIIPicture
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
                frame.Navigate(new Pages.Tasks.AfterAuth.AfterAuth(this));
            else if (_pages == pages.AdminConsole)
                frame.Navigate(new Pages.Tasks.AfterAuth.AdminConsole.AdminConsole(this));
            else if (_pages == pages.infBD)
                frame.Navigate(new Pages.Tasks.AfterAuth.AdminConsole.InformationDB(this));
            else if (_pages == pages.manipulationsBD)
                frame.Navigate(new Pages.Tasks.AfterAuth.AdminConsole.ManipulationsDB(this));
            else if (_pages == pages.calculator)
                frame.Navigate(new Pages.Tasks.AfterAuth.AfterAuthUser.Calculator(this));
            else if (_pages == pages.ASCIIPicture)
                frame.Navigate(new Pages.Tasks.AfterAuth.AfterAuthUser.ASCIIPicture(this));
        }

        private void frame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
