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

namespace CPSC481ProjectTest
{
    /// <summary>
    /// Interaction logic for LogInPage.xaml
    /// </summary>
    public partial class LogInPage : Page
    {
        public LogInPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UCID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void GoToPage2_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the Page2 window
            //SearchPage window1 = new SearchPage();

            // Navigate to the Page2 window
            //mainFrame.NavigationService.Navigate(window1);
            SearchPage SP = new SearchPage();
            this.NavigationService.Navigate(SP);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Question_MouseEnter(object sender, MouseEventArgs e)
        {
            Visibility = Visibility.Visible;
        }
        private void Question_MouseLeave(object sender, MouseEventArgs e)
        {
            Visibility = Visibility.Hidden;
        }
    }
}

