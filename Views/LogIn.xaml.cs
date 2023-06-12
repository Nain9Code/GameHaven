using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GameHaven.Models;

namespace GameHaven.Views
{
    public partial class Login : Page
    {
        public MainWindow MainWindow { get; set; }

        private readonly GameHavenContext _context;

        public Login(GameHavenContext context)
        {
            _context = context;
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
           
            var username = UsernameTextBox.Text;
            var password = PasswordTextBox.Password;

            var user = _context.Users.SingleOrDefault(u => u.Username == username);

            if (user == null)
            {
                MessageBox.Show("Invalid username or password.");
                return;
            }

            bool validPassword = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (!validPassword)
            {
                MessageBox.Show("Invalid username or password.");
                return;
            }

            MainWindow?.NavigateToMain();
            
            GameHaven.Session.UserSession.CurrentUser = user;
            
            MessageBox.Show($"Welcome back, {username}!");
  
        }
        private void GoHome_Click(object sender, RoutedEventArgs e)
        {
          
            NavigationService.Navigate(new Main());
        }
    }
}
