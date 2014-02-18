using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
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

namespace LocalBooru
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool defaultTextErased;
        DbProviderFactory fact;
        DbDataAdapter thingy;
        DbConnection cnn;
        public MainWindow()
        {
            InitializeComponent();
            defaultTextErased = false;
            fact = DbProviderFactories.GetFactory("System.Data.SQLite");
            cnn = fact.CreateConnection();
            cnn.ConnectionString = "Data Source=C:\\Users\\Andrew\\Documents\\LocalBooru\\test.db";
            cnn.Open();
            Console.WriteLine(cnn.State);
            thingy = fact.CreateDataAdapter();
        }

        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EraseDefaultText(object sender, RoutedEventArgs e)
        {
            if (!defaultTextErased && sender == searchBox)
            {
                defaultTextErased = true;
                searchBox.Text = "";
                searchBox.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
        }

        private void InitiateSearch(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Search initiated");
            testGetDB();
        }

        void testGetDB()
        {
            DbDataReader thingy2;
            DbCommand command1 = cnn.CreateCommand();
            cnn.BeginTransaction();
            command1.CommandText = "select * from test1";
            thingy2 = command1.ExecuteReader();
            thingy2.Read();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(thingy2.GetString(0) + " " + thingy2.GetString(1) + " is " + thingy2.GetInt64(2).ToString() + " years old.");
                thingy2.Read();
            }
        }
    }
}
