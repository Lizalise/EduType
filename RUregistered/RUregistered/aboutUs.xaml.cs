﻿using System;
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
using System.Windows.Shapes;

namespace RUregistered
{
    /// <summary>
    /// Interaction logic for aboutUs.xaml
    /// </summary>
    public partial class aboutUs : Window
    {
        public aboutUs()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Intro X = new Intro();
            X.ShowDialog();
        }
    }
}
