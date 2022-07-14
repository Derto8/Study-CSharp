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
using WpfProject.Pages.Classies;
using MySql.Data.MySqlClient;
using System.Data;

namespace WpfProject.Pages.Tasks.After_auth
{
    /// <summary>
    /// Логика взаимодействия для AdminConsole.xaml
    /// </summary>
    public partial class AdminConsole : Page
    {
        MainWindow mainWindow;

        private readonly AdminConDB adminCon;
        public AdminConsole(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            AdminConDB admin = new AdminConDB();
            admin.SelectAllUsers(dbGrid);
            if(dbGrid == null)
            {
                MessageBox.Show("Не удалось получить данные из бд");
            }

            adminCon = new AdminConDB();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.main);
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            ///

        }


        //DataTable dt = new DataTable();
        //dt = ((DataView)dbGrid.ItemsSource).ToTable();

        ////var oldTable = (DataTable)dbGrid.ItemsSource;
        //var newTable = adminCon.UpdateRealEstatesOrNull(dt);


        //if (newTable != null)
        //{
        //    dbGrid.ItemsSource = newTable.DefaultView;
        //}
        //public DataTable SelectTable(DataSet ds, string tableName)
        //{
        //    return ds.Tables[tableName];
        //}

        //AdminConDB admin = new AdminConDB();
        //DataTable dt = new DataTable();
        //admin.UpdateTable(dt);
        //dbGrid.ItemsSource = dt.DefaultView;

        //DataTable dt = new DataTable();

        //string query = "SELECT * FROM users";

        //DataBaseConnection db = new DataBaseConnection();

        //MySqlCommand command = new MySqlCommand(query, db.OpenConnection());

        //command.ExecuteNonQuery();

        //MySqlDataAdapter adapter = new MySqlDataAdapter(command);

        ////using (var bld = new MySqlCommandBuilder(adapter))
        ////{
        ////    adapter.Update(dt);
        ////}

        //var bld = new MySqlCommandBuilder(adapter);
        //adapter.Update(dt);
        //adapter.Fill(dt);

        //dbGrid.ItemsSource = dt.DefaultView;
    }
}
