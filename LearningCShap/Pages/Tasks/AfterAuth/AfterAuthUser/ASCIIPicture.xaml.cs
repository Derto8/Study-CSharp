using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using LearningCShap.Classies.ASCII;
using Microsoft.Win32;

namespace LearningCShap.Pages.Tasks.AfterAuth.AfterAuthUser
{
    public partial class ASCIIPicture : Page
    {
        private const double widthOFFSET = 1.5;
        private const int maxWidth = 350;
        MainWindow mainWindow;
        public ASCIIPicture(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.afterAuth);
        }

        private void AddFile(object sender, RoutedEventArgs e)
        {
            lb.Items.Clear();
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF, *.TXT)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf, *.txt";

            try
            {
                if (openDialog.ShowDialog() != true)
                {
                    buttonAddUser.Content = "Не удалось открыть фотографию";
                    return;
                }
            }
            catch { }

            var bitmap = new Bitmap(openDialog.FileName);
            bitmap = ResizeBitmap(bitmap);
            bitmap.ToGrayscale();

            var converter = new BitmapToASCIIConventer(bitmap);
            var rowsBlack = converter.ConvertForBlackBackground();


            string symbols = "";

            foreach (var row in rowsBlack)
            {
                lb.Items.Add(symbols);
                symbols = "";
                foreach (var r in row)
                {
                    symbols += r;
                }
            }

            var rowsWhite = converter.ConvertForWhiteBackground();

            string filePath = tb.Text;

            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Создайте файл по указанному адресу!");
                }
            }

            catch { }


            File.WriteAllLines(filePath, rowsWhite.Select(r => new string(r)));
        }

        private static Bitmap ResizeBitmap(Bitmap bitmap)
        {
            var maxWidth = ASCIIPicture.maxWidth;
            var newHeight = bitmap.Height / widthOFFSET * maxWidth / bitmap.Width;
            if (bitmap.Width > maxWidth || bitmap.Height > newHeight)
                bitmap = new Bitmap(bitmap, new System.Drawing.Size(maxWidth, (int)newHeight));
            return bitmap;
        }
    }
}
