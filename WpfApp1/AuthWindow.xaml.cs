using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.Models;
using static WpfApp1.AppStateInternal;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void authButton_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTextBox.Text.Trim(); 
            string password = passwordTextBox.Text.Trim();


            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            string hash = Convert.ToHexString(bytes).ToLower(); 

            var db = new kekContext();
            var user = db.Users.FirstOrDefault(x => x.Login == login);
            if (user == null)
            {

                MessageBox.Show("Неверный логин"); 
                return;
            }

            if (hash != user.Password)
            {
                MessageBox.Show("Неверный логин/пароль");
                return;
            }

            AppState.CurrentUser =  user; 

            var mainWindow = new MainWindow();
            mainWindow.Show();

            Close(); 
        }
    }

    internal class AppStateInternal
    {
        public static class AppState
        {
            public static WpfApp1.Models.User? CurrentUser { get; set; }
        }
    }
}
