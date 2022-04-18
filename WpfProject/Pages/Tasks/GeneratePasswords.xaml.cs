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

namespace WpfProject.Pages.Tasks
{
    /// <summary>
    /// Логика взаимодействия для GeneratePasswords.xaml
    /// </summary>
    public partial class GeneratePasswords : Page
    {
        MainWindow mainWindow;
        public GeneratePasswords(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }


        private void Generate(object sender, RoutedEventArgs e)
        {
            if (tb_lenght.Text != "")
            {
                if (tb_amount.Text != "")
                {
                    if (tb_path.Text != "")
                    {

                        int lenght = Convert.ToInt32(tb_lenght.Text);
                        int amount = Convert.ToInt32(tb_amount.Text);
                        string filePath = tb_path.Text;

                        //Объявление объекта типа PasswordGen.
                        PasswordGen pgen = new PasswordGen(lenght);
                        FileStream fileStream = null;
                        // проверяю существует ли файл
                        if (!File.Exists(filePath))
                            fileStream = File.Create(filePath); // создаю файл
                        else
                            fileStream = File.Open(filePath, FileMode.Append); // открываю файл и в конец будут добавлены данные

                        // получаю поток
                        StreamWriter output = new StreamWriter(fileStream);

                        int j = 1;
                        output.Write("\n" + "Генерация нового списка паролей: " + "\n");
                        while (amount != 0)
                        {
                            // записываю текст в поток
                            output.Write($"{j} - Пароль: {pgen.StartGeneration()} \n");
                            j++;
                            amount--;
                        }
                        output.Close();
                        Rez.Content = "Пароли записаны в ваш файл";
                    }
                }
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.main);
        }
    }
}
