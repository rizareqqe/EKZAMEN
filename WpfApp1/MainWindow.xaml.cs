using System.Text;
using System.Linq;
using WpfApp1.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                var db = new kekContext();
                var users = db.Users.ToList();

                userTable.ItemsSource = users;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}");
            }
        }

        private void userTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var db = new kekContext();

            var FullName = SearchBox.Text;

            var users = string.IsNullOrWhiteSpace(FullName) ? db.Users.ToList() : db.Users.Where(u => u.FullName.Contains(FullName)).ToList();
            userTable.ItemsSource = users;
        }
    }

}
