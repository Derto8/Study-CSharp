using System.Windows;
using System.Windows.Controls;
using System.Data;

namespace LearningCShap.Pages.Tasks.AfterAuth.AfterAuthUser
{
    public partial class Calculator : Page
    {
        MainWindow mainWindow;
        public Calculator(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;

            foreach (UIElement el in MainRoot.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;
            if (str == "AC")
                Tb.Text = "";
            else if (str == "=")
            {
                string value = new DataTable().Compute(Tb.Text, null).ToString();
                Tb.Text = value;
            }
            else
                Tb.Text += str;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.afterAuth);
        }
    }
}
