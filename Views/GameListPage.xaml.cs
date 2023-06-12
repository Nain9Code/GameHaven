using GameHaven.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GameHaven.Views
{
    public partial class GameListPage : Page
    {
        private readonly GameHavenContext _context;

        public GameListPage(GameHavenContext context)
        {
            _context = context;
            InitializeComponent();

            LoadGames();
        }

        private void LoadGames()
        {
            var games = _context.Games.ToList();
            GameListView.ItemsSource = games;
        }
        private void GoHomeButton_Click(object sender, RoutedEventArgs e)
        {
     
            NavigationService.Navigate(new Main());
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
        
        }
    }
}
