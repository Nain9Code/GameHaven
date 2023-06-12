using MiscUtil;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

    public partial class HamguerMenuApp : UserControl
    {
        public List<string> GameNames;
        public List<string> GameTypes;
        public string FreeGameName;
        public DateTime Purchased;
        public string Type;
        public HamguerMenuApp()
        {
            InitializeComponent();
            GameTypes = new List<string>()
            {
                "Games",
                "Game Types",
                "Free Games",
                "Assets",
            };
            List<string> filepaths = Directory.GetFiles(Environment.CurrentDirectory + @"\..\..\Images\MiniIcons", "*.png").ToList<string>();
            FileInfo myRandomFile = new FileInfo(filepaths[StaticRandom.Next(filepaths.Count)]);
            GameImage.Source = new BitmapImage(new Uri(myRandomFile.FullName, UriKind.RelativeOrAbsolute));
            AppNameLabel.Content = (new CultureInfo("en-US", false).TextInfo).ToTitleCase
            (
                GameImage.Source.ToString().Split('/').Last().Split('.').First().Split('-').Last().Split('.').First()
            );

            FreeGameName = AppNameLabel.Content.ToString();
            Type = GameTypes[StaticRandom.Next(GameTypes.Count)];
            Purchased = new DateTime(2023, 1, StaticRandom.Next(1, DateTime.Now.Day + 1));
            PurchasedLabel.Content = "Purchased " + Purchased.ToString("d");
        }
    }
}
