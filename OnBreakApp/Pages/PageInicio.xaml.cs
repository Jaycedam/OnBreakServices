﻿using ControlzEx.Theming;
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

namespace OnBreakApp.Pages
{
    /// <summary>
    /// Interaction logic for PageInicio.xaml
    /// </summary>
    public partial class PageInicio : Page
    {
        public PageInicio()
        {
            InitializeComponent();
        }
        private void BtnAyuda_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.lipsum.com/");
        }
    }
}
