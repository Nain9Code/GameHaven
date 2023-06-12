using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GameHaven.Models;
using GameHaven.Session;
using GameHaven.UserControls;

namespace GameHaven.Views
{

    public partial class Main : Page
    {
        public delegate void OnGameClicked(AnGame sender, RoutedEventArgs e);
        public event OnGameClicked GameClicked;

        public delegate void OnTopGameButtonClicked(object sender, RoutedEventArgs e);
        public event OnTopGameButtonClicked TopGameButtonClicked;

        public delegate void OnDownloadsAndUpdatesClicked();
        public event OnDownloadsAndUpdatesClicked DownloadsAndUpdatesClicked;

        public delegate void OnLoginClicked(object sender, RoutedEventArgs e);
        public event OnLoginClicked LoginClicked;

        public delegate void OnRegisterClicked(object sender, RoutedEventArgs e);
        public event OnRegisterClicked RegisterClicked;

        public delegate void OnProfileClicked(object sender, RoutedEventArgs e);
        public event OnProfileClicked ProfileClicked;

        public Main()
        {
            InitializeComponent();
            #region Deals Tab Events

            DealsAppsViewer.GameClicked += AnAppClicked;

            #endregion

            #region Productivity Tab Events

            SalesTopGames.GameClicked += AnAppClicked;
            ProductivityAppsL1.GameClicked += AnAppClicked;
            ProductivityAppsL2.GameClicked += AnAppClicked;
            ProductivityAppsL3.GameClicked += AnAppClicked;

            #endregion

            #region Entertainment Tab Events

            EntertainmentAppsViewer.GameClicked += AnAppClicked;

            #endregion

            #region Gaming Tab Events

            GamingAppsViewer.GameClicked += AnAppClicked;

            #endregion

            #region Home Tab Events

            TopGames.GameClicked += AnAppClicked;
            TopGames.TopGameButtonClicked += TopApps_TopAppButtonClicked;
            FeaturesAppsViewer.GameClicked += AnAppClicked;
            MostPopularAppsViewer.GameClicked += AnAppClicked;
            TopFreeAppsViewer.GameClicked += AnAppClicked;
            TopFreeGamesAppsViewer.GameClicked += AnAppClicked;

            #endregion

            #region Right Button Command Events

            RightHeaderButtons.HeaderRightButtonsDownloadButtonClick += RightHeaderButtons_HeaderRightButtonsDownloadButtonClick;

            #endregion

            #region

            RightHeaderButtons.LogInClickEvent += LogIn_Clicked;

            RightHeaderButtons.RegisterClickEvent += Register_Clicked;

            RightHeaderButtons.ProfileClickEvent += Profile_Clicked;

            #endregion
        }

        private void RightHeaderButtons_HeaderRightButtonsDownloadButtonClick(object sender, RoutedEventArgs e)
        {
            DownloadsAndUpdatesClicked?.Invoke();
        }

        private void TopApps_TopAppButtonClicked(object sender, RoutedEventArgs e)
        {
            TopGameButtonClicked(sender, e);
        }

        private void AnAppClicked(AnGame sender, RoutedEventArgs e)
        {
            GameClicked?.Invoke(sender, e);
        }


        private void Page_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            RightHeaderButtons.MouseDown_OutsideOfHeaderRightButtons();
        }
        private void LogIn_Clicked(object sender, RoutedEventArgs e)
        {
            
            var context = new GameHavenContext();
            
            NavigationService.Navigate(new Login(context));
        }
        private void Register_Clicked(object sender, RoutedEventArgs e)
        {
            
            var context = new GameHavenContext();
            
            NavigationService.Navigate(new Register(context));
        }
        private void Profile_Clicked(object sender, RoutedEventArgs e)
        {
            
            if (GameHaven.Session.UserSession.CurrentUser != null)
            {
                NavigationService.Navigate(new Profile());
            }
            else
            {
                
            }
        }

        private Users GetLoggedInUser()
        {
            return GameHaven.Session.UserSession.CurrentUser;
        }



    }
}
