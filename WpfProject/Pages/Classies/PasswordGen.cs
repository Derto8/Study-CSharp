using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject.Pages.Classies
{
    class PasswordGen
    {
        const string sign = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_+№;%:?*-+=[]./|<>{}";

        private int lenght { get; set; }

        public PasswordGen(int lenght)
        {
            this.lenght = lenght;
        }

        public string GeneratePasswords()
        {
            string password = "";
            Random rnd = new Random();

            for(int i = 0; i < lenght; i++)
            {
                    //создаю переменную выборки индекса знака
                    int signIndex = rnd.Next(0, 91);
                    //добавление знака в основную переменную
                    password += sign[signIndex];
            }
            return password;

        }

        public bool CheckPassNum(string pass)
        {
            for (int i = 0; i < pass.Length; i++)
            {
                if (pass[i] >= '0' && pass[i] <= '9')
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckPassAlph(string pass)
        {
            if (pass.Any(x => char.IsUpper(x)))
                return true;
            else
                return false;
        }
    }
}
