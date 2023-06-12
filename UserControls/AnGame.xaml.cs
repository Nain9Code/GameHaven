using MiscUtil;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GameHaven.UserControls
{
    public partial class AnGame : UserControl
    {
        public string FreeGameName;
        public ImageSource GameImageSource;

        public delegate void OnGameClicked(AnGame sender, RoutedEventArgs e);
        public event OnGameClicked GameClicked;
 
        public AnGame()
        {
            InitializeComponent();
            List<string> filepaths = Directory.GetFiles(Environment.CurrentDirectory + @"\..\..\Images", "*.png").ToList<string>();
            FileInfo myRandomFile = new FileInfo(filepaths[StaticRandom.Next(filepaths.Count)]);
            ProductImage.Source = new BitmapImage(new Uri(myRandomFile.FullName, UriKind.RelativeOrAbsolute));
            GameNameText.Text = (new CultureInfo("en-US", false).TextInfo).ToTitleCase(myRandomFile.FullName.Split('\\').Last().Split('-').Last().Split('.').First());
            FreeGameName = GameNameText.Text.ToString();
            GameImageSource = ProductImage.Source;
        }
        public AnGame(string inAppName, ImageSource inImageSource)
        {
            InitializeComponent();
            ProductImage.Source = inImageSource;
            GameNameText.Text = inAppName;
            FreeGameName = inAppName;
            GameImageSource = inImageSource;
        }
        private void ProductImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            GameClicked(this, e);
        }
    }
}
