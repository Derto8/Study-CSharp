using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProject.Pages.Classies;
using System.Windows.Controls;

namespace WpfProject.Pages.Classies
{
    class DataBaseConnection
    {
        static string server = "localhost";
        static string port = "3306";
        static string username = "root";
        static string password = "root";
        static string database = "LearningCSharp";

        MySqlConnection connection = new MySqlConnection($"server={server};port={port};username={username};password={password};database={database}");
        

        //возвращение соединения с бд
        public MySqlConnection GetConnection()
        {
            return connection;
        }

        //открыть соединение с бд
        public MySqlConnection OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
            return connection;
        }

        //разъеденить соединение с бд
        public MySqlConnection CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
            return connection;
        }

    }
}
