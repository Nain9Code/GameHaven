﻿using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace GameHaven.UserControls
{

    public partial class SalesTopGames : UserControl
    {
        public delegate void OnAnGameClicked(AnGame sender, RoutedEventArgs e);
        public event OnAnGameClicked GameClicked;

        public SalesTopGames()
        {
            InitializeComponent();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            string appName = (new CultureInfo("en-US", false).TextInfo).ToTitleCase
            (
                (sender as Image).Source.ToString().Split('/').Last().Split('.').First().Split('-').Last().Split('.').First()
            );
            GameClicked(new AnGame(appName, (sender as Image).Source), e);
        }
    }
}
