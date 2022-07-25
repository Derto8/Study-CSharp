using MySql.Data.MySqlClient;
using System.Data;

namespace LearningCShap.Classies.WorkWithDB
{
    internal class AuthDB
    {
        public string loginUser;

        public DataTable AuthUser(string login, string password)
        {
            //Объект ранее созданного класса DataBaseConnection
            DataBaseConnection db = new DataBaseConnection();

            //объект таблицы 
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();


            //авторизация пользователя
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `password` = @uP", db.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = password;
            adapter.SelectCommand = command;

            adapter.Fill(table);
            db.CloseConnection();
            return table;
        }

        public string AuthAdmin(string login, string password)
        {
            //Объект ранее созданного класса DataBaseConnection
            DataBaseConnection db = new DataBaseConnection();

            MySqlCommand commandStatus = new MySqlCommand("SELECT `status` FROM `users` WHERE `login` = @uL AND `password` = @uP", db.OpenConnection());
            commandStatus.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
            commandStatus.Parameters.Add("@uP", MySqlDbType.VarChar).Value = password;

            MySqlDataReader reader = commandStatus.ExecuteReader();

            string status = "";

            while (reader.Read())
            {
                status = reader[0].ToString();
            }
            reader.Close();
            db.CloseConnection();
            return status;
        }

        public bool isUserExists(string login)
        {
            DataBaseConnection db = new DataBaseConnection();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", db.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
