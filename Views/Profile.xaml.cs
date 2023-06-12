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
using GameHaven.Models;
using GameHaven.Session;

namespace GameHaven.Views
{
    public partial class Profile : Page
    {
        public Profile()
        {
            InitializeComponent();
            this.DataContext = GameHaven.Session.UserSession.CurrentUser;


        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            
            GameHaven.Session.UserSession.CurrentUser = null;

           
            var context = new GameHavenContext();

            
            NavigationService.Navigate(new Login(context));
        }

        private void GoHomeButton_Click(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new Main());
        }


    }
}

