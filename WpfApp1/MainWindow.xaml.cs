using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Models;

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
            authTextBlock.Text = AppState.CurrentUser!.FullName;
        }

        private void LoadUsers()
        {
            try
            {
                var db = new kekContext();
                var users = db.Users.ToList();
                userTable.ItemsSource = users;

                if (AppState.CurrentUser == null)
                {
                    AppState.CurrentUser = users.FirstOrDefault();
                }
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

            var fullName = SearchBox.Text;

            var users = string.IsNullOrWhiteSpace(fullName) ? db.Users.ToList() : db.Users.Where(u => u.FullName.Contains(fullName)).ToList();
            userTable.ItemsSource = users;
        }
    }

}

