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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CPSC481ProjectTest
{
    /// <summary>
    /// Interaction logic for AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        public AccountPage()
        {
            InitializeComponent();
        }
        private void ScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void MyAccountButton(object sender, RoutedEventArgs e)
        {
            AccountPage AP = new AccountPage();
            this.NavigationService.Navigate(AP);
        }
        private void HomeButton(object sender, RoutedEventArgs e)
        {
            SearchPage AP = new SearchPage();
            this.NavigationService.Navigate(AP);
        }
        private void LogoutButton(object sender, RoutedEventArgs e)
        {
            LogInPage AP = new LogInPage();
            this.NavigationService.Navigate(AP);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}


