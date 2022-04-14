using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject.Pages
{
    class PasswordGen
    {
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
        string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string numbers = "1234567890";
        string specialSymbols = "~`!@#$%^&*()_+№;%:?*-+=[]./|<>{}";

        string password;
        private int Lenght { get; set; }


        public string StartGeneration()
        {
            GeneratePasswords();
            return password;
        }

        public PasswordGen(int a)
        {
            Lenght = a;
        }

        private void GeneratePasswords()
        {
            password = "";
            Random rnd = new Random();
            for (int i = 0; i < Lenght; i++)
            {
                //создаю переменную выборки переменной знаков
                int randomChoosing = rnd.Next(0, 3);
                //присваивает себе переменную со знаками
                string signChoosing;
                //отвечает на индекс знака
                int signIndex;
                if (randomChoosing == 0)
                {
                    signChoosing = alphabet;
                    signIndex = rnd.Next(0, 25);
                }
                else if (randomChoosing == 1)
                {
                    signChoosing = ALPHABET;
                    signIndex = rnd.Next(0, 25);
                }
                else if (randomChoosing == 2)
                {
                    signChoosing = numbers;
                    signIndex = rnd.Next(0, 9);
                }
                else
                {
                    signChoosing = specialSymbols;
                    signIndex = rnd.Next(0, 31);
                }
                //добавление знака в основную переменную
                password += signChoosing[signIndex];

            }
        }
    }
}
