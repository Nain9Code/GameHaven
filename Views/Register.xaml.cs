using GameHaven.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace GameHaven.Views
{
    public partial class Register : Page
    {
        private readonly GameHavenContext _context;

        public Register(GameHavenContext context)
        {
            _context = context;
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameTextBox.Text;
            var password = PasswordTextBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter a valid username and password.");
                return;
            }

            if (_context.Users.Any(u => u.Username == username))
            {
                MessageBox.Show("This username already exists. Please choose another one.");
                return;
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            var user = new Users
            {
                Username = username,
                Password = hashedPassword,
                RoleId = 1 
            };
            if (!_context.Roles.Any(r => r.RoleID == 1))
            {
                var role = new Roles
                {
                    RoleID = 1,
                    RoleName = "Regular User"
                };

                _context.Roles.Add(role);
                _context.SaveChanges();
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            MessageBox.Show("Registration successful!");
           
            UsernameTextBox.Clear();
            PasswordTextBox.Clear();
        }
        private void GoHome_Click(object sender, RoutedEventArgs e)
        {
           
            NavigationService.Navigate(new Main());
        }
    }
}
