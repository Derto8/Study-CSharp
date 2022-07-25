using System;
using System.Linq;

namespace LearningCShap.Classies.PasswordGenerate
{
    internal class PasswordGen
    {
        const string sign = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_+№;%:?*-+=[]./|<>{}";

        private int lenght { get; set; }

        Random rnd = new Random();


        public PasswordGen(int lenght)
        {
            this.lenght = lenght;
        }

        public string GeneratePasswords()
        {
            string password = "";
            string signChoosing = "";

            for (int i = 0; i < lenght; i++)
            {
                int signIndex = rnd.Next(0, 91);
                signChoosing += sign[signIndex];
            }

            password += signChoosing;
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
            {
                return false;
            }
        }
    }
}
