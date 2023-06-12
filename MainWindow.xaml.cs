using MahApps.Metro.Controls;
using System.Windows;
using GameHaven.Views;
using GameHaven.UserControls;
using GameHaven.Window;
using GameHaven.Models;
using System.Web.UI.WebControls;


namespace GameHaven
{
    public partial class MainWindow : MetroWindow
    {
        private Main MainWindowContentPage;
        private TopGamesWrapped MyTopGamesWrappedPage;
        private DownloadsAndUpdates DownloadsAndUpdatesPage;
        private MetroWindow accentThemeTestWindow;

        public MainWindow()
        {
            InitializeComponent();
            
            MainWindowContentPage = new Main();
            MainWindowContentPage.TopGameButtonClicked += MainWindowContentPage_TopAppButtonClicked;
            MainWindowContentPage.GameClicked += MainWindowContentPage_AppClicked;
            MainWindowContentPage.DownloadsAndUpdatesClicked += MainWindowContentPage_DownloadsAndUpdatesClicked;
            MyTopGamesWrappedPage = new TopGamesWrapped();
            MyTopGamesWrappedPage.AnAppClicked += MainWindowContentPage_AppClicked;
            MyTopGamesWrappedPage.BackButtonClicked += BackButtonClicked;
            DownloadsAndUpdatesPage = new DownloadsAndUpdates();
            DownloadsAndUpdatesPage.BackButtonClicked += BackButtonClicked;
        }

        private void MainWindowContentPage_DownloadsAndUpdatesClicked()
        {
            MainWindowFrame.Content = DownloadsAndUpdatesPage;
        }

        private void MainWindowContentPage_TopAppButtonClicked(object sender, RoutedEventArgs e)
        {
            MainWindowFrame.Content = MyTopGamesWrappedPage;
        }

        private void MainWindowContentPage_AppClicked(AnGame sender, RoutedEventArgs e)
        {
            GameDetails myAppDetails = new GameDetails(sender);
            myAppDetails.GameClicked += MainWindowContentPage_AppClicked;
            myAppDetails.BackButtonClicked += BackButtonClicked;
            MainWindowFrame.Content = myAppDetails;
        }
        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            if (MainWindowFrame.NavigationService.CanGoBack)
                MainWindowFrame.NavigationService.GoBack();
        }
        private void MainWindowFrame_Loaded(object sender, RoutedEventArgs e)
        {
            //MainWindowFrame.Content = MainWindowContentPage;
        }
        public void NavigateToMain()
        {
            MainWindowFrame.Content = MainWindowContentPage;
        }
        public void ShowLogin()
        {
            var dbContext = new GameHavenContext();
            var login = new GameHaven.Views.Login(dbContext) { MainWindow = this };
            MainWindowFrame.Content = login;
        }


        private void ChangeAppStyleButtonClick(object sender, RoutedEventArgs e)
        {
             
            if (accentThemeTestWindow != null)
            {
                accentThemeTestWindow.Activate();
                return;
            }
            accentThemeTestWindow = new AccentStyleWindow();
            accentThemeTestWindow.Owner = this;
            accentThemeTestWindow.Closed += (o, args) => accentThemeTestWindow = null;
            accentThemeTestWindow.Left = this.Left + this.ActualWidth / 2.0;
            accentThemeTestWindow.Top = this.Top + this.ActualHeight / 2.0;
            accentThemeTestWindow.Show();
        }

    }
}
