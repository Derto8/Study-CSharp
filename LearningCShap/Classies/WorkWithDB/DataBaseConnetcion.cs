using MySql.Data.MySqlClient;

namespace LearningCShap.Classies.WorkWithDB
{
    internal class DataBaseConnection
    {
        static readonly string server = "localhost";
        static readonly string port = "3306";
        static readonly string username = "root";
        static readonly string password = "root";
        static readonly string database = "LearningCSharp";

        readonly MySqlConnection connection = new MySqlConnection($"server={server};port={port};username={username};password={password};database={database}");


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
