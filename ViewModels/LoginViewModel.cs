using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using GameHaven.Models;

namespace GameHaven.ViewModels
{
 
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;

        private readonly GameHavenContext _context;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public ICommand LoginCommand { get; set; }

        public LoginViewModel(GameHavenContext context)
        {
            _context = context;
            LoginCommand = new RelayCommand(Login, CanLogin);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool CanLogin(object parameter)
        {
            // We can log in only if username and password are not empty
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }

        private void Login(object parameter)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == _username);

            if (user == null)
            {
                // Handle user not found scenario
                return;
            }

            bool validPassword = BCrypt.Net.BCrypt.Verify(_password, user.Password);

            if (!validPassword)
            {
                // Handle invalid password scenario
                return;
            }

            // User is logged in successfully, save user in session
            GameHaven.Session.UserSession.CurrentUser = user;
        }
    }

}
