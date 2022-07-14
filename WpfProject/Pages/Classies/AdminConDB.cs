using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfProject.Pages.Classies
{
    class AdminConDB
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

        ////public void Update(DataGrid dg)
        ////{
        ////    string query = "SELECT * FROM users";

        ////    DataBaseConnection db = new DataBaseConnection();

        ////    MySqlCommand command = new MySqlCommand(query, db.OpenConnection());

        ////    command.ExecuteNonQuery();
        ////    DataTable dt = new DataTable("users");

        ////    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
        ////    //MySqlCommandBuilder buld = new MySqlCommandBuilder(adapter);
        ////    MySqlCommandBuilder build = new MySqlCommandBuilder(adapter);
        ////    adapter.Update(dt);

        ////    adapter.Fill(dt);

        ////    //DataTable dt = new DataTable();
        ////    dt = ((DataView)dg.ItemsSource).ToTable();

        ////    dg.ItemsSource = dt.DefaultView;
        ////    db.CloseConnection();
        ////}

        //static string server = "localhost";
        //static string port = "3306";
        //static string username = "root";
        //static string password = "root";
        //static string database = "LearningCSharp";

        //private string connection = $@"server={server};port={port};username={username};password={password};database={database}";

        //public DataTable UpdateRealEstatesOrNull(DataTable dataTable)
        //{
        //    DataTable resultTable = null;
        //    try
        //    {
        //        using (var cnn = new MySqlConnection(connection))
        //        using (var cmd = cnn.CreateCommand())
        //        using (var adp = new MySqlDataAdapter(cmd))
        //        {
        //            cmd.CommandText = "SELECT * FROM RealEstates";
        //            using (var bld = new MySqlCommandBuilder(adp))
        //            {
        //                int affected = adp.Update(dataTable);
        //                resultTable = dataTable;
        //            }
        //            adp.Fill(dataTable);
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //    }

        //    return resultTable;
        //}



        //public DataTable UpdateTable(DataTable dt)
        //{
        //    DataTable resultTable = null;

        //    string query = "SELECT * FROM users";

        //    DataBaseConnection db = new DataBaseConnection();

        //    MySqlCommand command = new MySqlCommand(query, db.OpenConnection());

        //    //command.ExecuteNonQuery();

        //    MySqlDataAdapter adapter = new MySqlDataAdapter(command);

        //    using (var bld = new MySqlCommandBuilder(adapter))
        //    {
        //        int affected = adapter.Update(dt);
        //        resultTable = dt;
        //    }
        //    //adapter.Fill(dt);
        //    db.CloseConnection();
        //    return dt;
        //}
    }
}
