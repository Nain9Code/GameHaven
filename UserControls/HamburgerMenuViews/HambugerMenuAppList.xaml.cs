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

namespace GameHaven.UserControls.HamburgerMenuViews
{

    public partial class HambugerMenuAppList : UserControl
    {
        public List<HamguerMenuApp> AllGames;
        public List<HamguerMenuApp> GamesOnFilter;
        public HambugerMenuAppList()
        {
            AllGames = new List<HamguerMenuApp>();
            GamesOnFilter = new List<HamguerMenuApp>();
            InitializeComponent();
            for (int i = 0; i < 15; i++)
            {
                AddNewHamApp();
            }
        }
        private void AddNewHamApp()
        {
            HamguerMenuApp anGame = new HamguerMenuApp();
            MainStackPanel.Children.Add(anGame);
            AllGames.Add(anGame);
        }

        public void FilterByType(string inFilter)
        {
            GamesOnFilter = AllGames.Where(p => p.Type == inFilter).ToList<HamguerMenuApp>();
            AddToMainStackPanel(GamesOnFilter);
        }

        public void AddAll()
        {
            GamesOnFilter = new List<HamguerMenuApp>();
            AddToMainStackPanel(AllGames);
        }

        public void SortByName()
        {
            List<HamguerMenuApp> AllAppsSorted = new List<HamguerMenuApp>();
            if (GamesOnFilter.Count < 1)
            {
                AllAppsSorted = AllGames.OrderBy(p => p.FreeGameName).ToList<HamguerMenuApp>();
            }
            else
            {
                AllAppsSorted = GamesOnFilter.OrderBy(p => p.FreeGameName).ToList<HamguerMenuApp>();
            }
            AddToMainStackPanel(AllAppsSorted);
        }

        public void SortByDate()
        {
            List<HamguerMenuApp> AllAppsSorted = new List<HamguerMenuApp>();
            if (GamesOnFilter.Count < 1)
            {
                AllAppsSorted = AllGames.OrderByDescending(p => p.Purchased).ToList<HamguerMenuApp>();
            }
            else
            {
                AllAppsSorted = GamesOnFilter.OrderByDescending(p => p.Purchased).ToList<HamguerMenuApp>();
            }
            AddToMainStackPanel(AllAppsSorted);
        }

        private void AddToMainStackPanel(List<HamguerMenuApp> inList)
        {
            MainStackPanel.Children.Clear();
            foreach (HamguerMenuApp item in inList)
            {
                MainStackPanel.Children.Add(item);
            }
        }
    }
}