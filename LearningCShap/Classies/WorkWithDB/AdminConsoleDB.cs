using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Controls;
using System.Windows;

namespace LearningCShap.Classies.WorkWithDB
{
    internal class AdminConsoleDB
    {
        public void SelectAllUsers(DataGrid dg)
        {
            string query = "SELECT * FROM users";

            DataBaseConnection db = new DataBaseConnection();

            MySqlCommand command = new MySqlCommand(query, db.OpenConnection());

            command.ExecuteNonQuery();

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable dt = new DataTable("users");

            adapter.Fill(dt);

            dg.ItemsSource = dt.DefaultView;
            db.CloseConnection();
        }

        public int CountUsers()
        {
            string query = "SELECT Count(*) FROM users";
            DataBaseConnection db = new DataBaseConnection();

            MySqlCommand command = new MySqlCommand(query, db.OpenConnection());

            object count = command.ExecuteScalar();

            return Convert.ToInt32(count);
        }



        public void Update(string element, string nameColumn, int id)
        {
            AuthDB checkUserExists = new AuthDB();
            if (checkUserExists.isUserExists(element))
            {
                MessageBox.Show("Пользователь с таким логином уже существует!");
            }
            string query = $"UPDATE users SET {nameColumn} = '{element}' WHERE id = {id}";

            DataBaseConnection db = new DataBaseConnection();

            MySqlCommand command = new MySqlCommand(query, db.OpenConnection());

            command.ExecuteNonQuery();

            db.CloseConnection();
        }

        public void DeleteUser(int id)
        {
            string query = $"DELETE FROM users WHERE id = {id}";
            DataBaseConnection db = new DataBaseConnection();

            MySqlCommand command = new MySqlCommand(query, db.OpenConnection());

            command.ExecuteNonQuery();

            db.CloseConnection();
        }

        public void AddUser(string login, string password, string status, Label lb)
        {
            string text;
            AuthDB checkUserExists = new AuthDB();
            if (checkUserExists.isUserExists(login))
            {
                text = "Пользователь с таким же логином уже существует!";
                lb.Content = text;
                return;
            }

            string query = $"INSERT INTO users(login, password, status) VALUES('{login}', '{password}', '{status}')";
            DataBaseConnection db = new DataBaseConnection();

            MySqlCommand command = new MySqlCommand(query, db.OpenConnection());

            command.ExecuteNonQuery();

            db.CloseConnection();

            text = "Пользователь создан!";
            lb.Content = text;
            return;
        }
    }
}
