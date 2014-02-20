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
            cnn.ConnectionString = "Data Source=C:\\Users\\Andrew\\Documents\\LocalBooru\\tagdb.db";
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
            string searchString = searchBox.Text;
            List<String> tags = new List<String>();
            foreach (string tag in searchString.Split(new Char[] { ',' }))
            {
                tags.Add(tag.Trim());
            }
            testGetDB(tags);
        }

        void testGetDB(List<String> searchTags)
        {
            DbDataReader reader;
            DbCommand command1 = cnn.CreateCommand();
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("SELECT c.*");
            sqlCommand.AppendLine("FROM Tagmap tm, Content c, Tags t");
            sqlCommand.AppendLine("WHERE tm.tag_id = t.tag_id");
            sqlCommand.Append("AND (t.name IN (");
            foreach (string tag in searchTags)
            {
                sqlCommand.Append("'" + tag + "', ");
            }
            sqlCommand.Remove(sqlCommand.Length - 2, 2);
            sqlCommand.AppendLine("))");
            sqlCommand.AppendLine("AND c.id = tm.content_id");
            sqlCommand.AppendLine("GROUP BY c.id");
            sqlCommand.AppendLine("HAVING COUNT( c.id ) = 3;");
            cnn.BeginTransaction();
            command1.CommandText = sqlCommand.ToString();
            reader = command1.ExecuteReader();
            
            cnn.Close();
        }
    }
}
