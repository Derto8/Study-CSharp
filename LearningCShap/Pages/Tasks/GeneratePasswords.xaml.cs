using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using LearningCShap.Classies.PasswordGenerate;

namespace LearningCShap.Pages.Tasks
{
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

                        int amRez = amount;

                        while (amount != 0)
                        {
                            // записываю текст в поток
                            output.Write($"{j} - Пароль: {pgen.GeneratePasswords()} \n");
                            j++;
                            amount--;
                        }
                        output.Close();

                        if (amRez > 1)
                        {
                            Rez.Content = "Пароли были сгенерированы";
                        }
                        else
                        {
                            Rez.Content = "Пароль был сгенерирован";
                        }
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
