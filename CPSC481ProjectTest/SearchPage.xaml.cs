using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace CPSC481ProjectTest
{
    /// <summary>
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        public static string basicSearchQuery;

        public SearchPage()
        {
            InitializeComponent();
        }
        private void BasicButton_Click(object sender, RoutedEventArgs e)
        {
            Color color = (Color)ColorConverter.ConvertFromString("#FAEDCD"); //Convert the color from string to Color object
            BasicButton.Background = new SolidColorBrush(color); //Change the background color of the button to the new color

            Color color1 = (Color)ColorConverter.ConvertFromString("#E4DCCF"); //Convert the color from string to Color object
            AdvancedButton.Background = new SolidColorBrush(color1); //Change the background color of the button to the new color

            if (BasicStack.Visibility == Visibility.Collapsed)
            {
                BasicStack.Visibility = Visibility.Visible;

                AdvancedStack.Visibility = Visibility.Collapsed;
            }
            else
            {
                BasicStack.Visibility = Visibility.Collapsed;
                AdvancedStack.Visibility = Visibility.Visible;
            }
        }

        private void AdvancedButton_Click(object sender, RoutedEventArgs e)
        {
            Color color = (Color)ColorConverter.ConvertFromString("#FAEDCD"); //Convert the color from string to Color object
            AdvancedButton.Background = new SolidColorBrush(color); //Change the background color of the button to the new color

            Color color1 = (Color)ColorConverter.ConvertFromString("#E4DCCF"); //Convert the color from string to Color object
            BasicButton.Background = new SolidColorBrush(color1); //Change the background color of the button to the new color

            if (AdvancedStack.Visibility == Visibility.Collapsed)
            {
                AdvancedStack.Visibility = Visibility.Visible;
                BasicStack.Visibility = Visibility.Collapsed;
            }
            else
            {
                AdvancedStack.Visibility = Visibility.Collapsed;
                BasicStack.Visibility = Visibility.Visible;
            }
        }

        public void Cancel1Clicked(object sender, RoutedEventArgs e)
        {
            Filter1.Visibility = Visibility.Collapsed;
        }

        public void Cancel2Clicked(object sender, RoutedEventArgs e)
        {
            Filter2.Visibility = Visibility.Collapsed;
        }

        public void Cancel3Clicked(object sender, RoutedEventArgs e)
        {
            Filter3.Visibility = Visibility.Collapsed;
        }

        public void Cancel4Clicked(object sender, RoutedEventArgs e)
        {
            Filter4.Visibility = Visibility.Collapsed;
        }

        public void Cancel5Clicked(object sender, RoutedEventArgs e)
        {
            Filter5.Visibility = Visibility.Collapsed;
        }

        public void Cancel6Clicked(object sender, RoutedEventArgs e)
        {
            Filter6.Visibility = Visibility.Collapsed;
        }

        public void Cancel7Clicked(object sender, RoutedEventArgs e)
        {
            Filter7.Visibility = Visibility.Collapsed;
        }

        public void Cancel8Clicked(object sender, RoutedEventArgs e)
        {
            Filter8.Visibility = Visibility.Collapsed;
        }

        public void Cancel9Clicked(object sender, RoutedEventArgs e)
        {
            Filter9.Visibility = Visibility.Collapsed;
        }

        public void Cancel10Clicked(object sender, RoutedEventArgs e)
        {
            Filter10.Visibility = Visibility.Collapsed;
        }

        public void Cancel11Clicked(object sender, RoutedEventArgs e)
        {
            Filter11.Visibility = Visibility.Collapsed;
        }

        public void Cancel12Clicked(object sender, RoutedEventArgs e)
        {
            Filter12.Visibility = Visibility.Collapsed;
        }

        public void Cancel13Clicked(object sender, RoutedEventArgs e)
        {
            Filter13.Visibility = Visibility.Collapsed;
        }

        public void Cancel14Clicked(object sender, RoutedEventArgs e)
        {
            Filter14.Visibility = Visibility.Collapsed;
        }

        public void Cancel15Clicked(object sender, RoutedEventArgs e)
        {
            Filter15.Visibility = Visibility.Collapsed;
        }

        public void Cancel16Clicked(object sender, RoutedEventArgs e)
        {
            Filter16.Visibility = Visibility.Collapsed;
        }

        public void Cancel17Clicked(object sender, RoutedEventArgs e)
        {
            Filter17.Visibility = Visibility.Collapsed;
        }

        public void Cancel18Clicked(object sender, RoutedEventArgs e)
        {
            Filter18.Visibility = Visibility.Collapsed;
        }

        private void AddFilterClicked(object sender, RoutedEventArgs e)
        {
            if ((Filter4.Visibility == Visibility.Collapsed) && (Filter5.Visibility == Visibility.Collapsed) && (Filter6.Visibility == Visibility.Collapsed))
            {
                Cancel1.Visibility = Visibility.Visible;
                Filter4.Visibility = Visibility.Visible;
                Filter5.Visibility = Visibility.Visible;
                Filter6.Visibility = Visibility.Visible;
            }
            else if ((Filter7.Visibility == Visibility.Collapsed) && (Filter8.Visibility == Visibility.Collapsed) && (Filter9.Visibility == Visibility.Collapsed))
            {
                Filter7.Visibility = Visibility.Visible;
                Filter8.Visibility = Visibility.Visible;
                Filter9.Visibility = Visibility.Visible;
            }
            else if ((Filter10.Visibility == Visibility.Collapsed) && (Filter11.Visibility == Visibility.Collapsed) && (Filter12.Visibility == Visibility.Collapsed))
            {
                Filter10.Visibility = Visibility.Visible;
                Filter11.Visibility = Visibility.Visible;
                Filter12.Visibility = Visibility.Visible;
            }
            else if ((Filter13.Visibility == Visibility.Collapsed) && (Filter14.Visibility == Visibility.Collapsed) && (Filter15.Visibility == Visibility.Collapsed))
            {
                Filter13.Visibility = Visibility.Visible;
                Filter14.Visibility = Visibility.Visible;
                Filter15.Visibility = Visibility.Visible;
            }
            else if ((Filter16.Visibility == Visibility.Collapsed) && (Filter17.Visibility == Visibility.Collapsed) && (Filter18.Visibility == Visibility.Collapsed))
            {
                Filter16.Visibility = Visibility.Visible;
                Filter17.Visibility = Visibility.Visible;
                Filter18.Visibility = Visibility.Visible;
            }
        }



        private void DeleteSearchTerms(object sender, RoutedEventArgs e)
        {
            EnhanceButton.Visibility = Visibility.Visible;
            EnhanceQuestion.Visibility = Visibility.Visible;
            UnenhanceButton.Visibility = Visibility.Collapsed;
            UnenhanceQuestion.Visibility = Visibility.Collapsed;

            Cancel1.Visibility = Visibility.Collapsed;
            AndOr1.SelectedIndex = 0;
            AndOr2.SelectedIndex = 0;
            AndOr3.SelectedIndex = 0;
            Field1.SelectedIndex = 0;
            Field2.SelectedIndex = 0;
            Field3.SelectedIndex = 0;
            Contain1.SelectedIndex = 0;
            Contain2.SelectedIndex = 0;
            Contain3.SelectedIndex = 0;
            Input1.Text = "Your search term";
            Input2.Text = "Your search term";
            Input3.Text = "Your search term";

            AndOr4.SelectedIndex = 0;
            AndOr5.SelectedIndex = 0;
            AndOr6.SelectedIndex = 0;
            Field4.SelectedIndex = 0;
            Field5.SelectedIndex = 0;
            Field6.SelectedIndex = 0;
            Contain4.SelectedIndex = 0;
            Contain5.SelectedIndex = 0;
            Contain6.SelectedIndex = 0;
            Input4.Text = "Your search term";
            Input5.Text = "Your search term";
            Input6.Text = "Your search term";

            AndOr7.SelectedIndex = 0;
            AndOr8.SelectedIndex = 0;
            AndOr9.SelectedIndex = 0;
            Field7.SelectedIndex = 0;
            Field8.SelectedIndex = 0;
            Field9.SelectedIndex = 0;
            Contain7.SelectedIndex = 0;
            Contain8.SelectedIndex = 0;
            Contain9.SelectedIndex = 0;
            Input7.Text = "Your search term";
            Input8.Text = "Your search term";
            Input9.Text = "Your search term";

            AndOr10.SelectedIndex = 0;
            AndOr11.SelectedIndex = 0;
            AndOr12.SelectedIndex = 0;
            Field10.SelectedIndex = 0;
            Field11.SelectedIndex = 0;
            Field12.SelectedIndex = 0;
            Contain10.SelectedIndex = 0;
            Contain11.SelectedIndex = 0;
            Contain12.SelectedIndex = 0;
            Input10.Text = "Your search term";
            Input11.Text = "Your search term";
            Input12.Text = "Your search term";

            AndOr13.SelectedIndex = 0;
            AndOr14.SelectedIndex = 0;
            AndOr15.SelectedIndex = 0;
            Field13.SelectedIndex = 0;
            Field14.SelectedIndex = 0;
            Field15.SelectedIndex = 0;
            Contain13.SelectedIndex = 0;
            Contain14.SelectedIndex = 0;
            Contain15.SelectedIndex = 0;
            Input13.Text = "Your search term";
            Input14.Text = "Your search term";
            Input15.Text = "Your search term";

            AndOr16.SelectedIndex = 0;
            AndOr17.SelectedIndex = 0;
            AndOr18.SelectedIndex = 0;
            Field16.SelectedIndex = 0;
            Field17.SelectedIndex = 0;
            Field18.SelectedIndex = 0;
            Contain16.SelectedIndex = 0;
            Contain17.SelectedIndex = 0;
            Contain18.SelectedIndex = 0;
            Input16.Text = "Your search term";
            Input17.Text = "Your search term";
            Input18.Text = "Your search term";

            Filter4.Visibility = Visibility.Collapsed;
            Filter5.Visibility = Visibility.Collapsed;
            Filter6.Visibility = Visibility.Collapsed;
            Filter7.Visibility = Visibility.Collapsed;
            Filter8.Visibility = Visibility.Collapsed;
            Filter9.Visibility = Visibility.Collapsed;
            Filter10.Visibility = Visibility.Collapsed;
            Filter11.Visibility = Visibility.Collapsed;
            Filter12.Visibility = Visibility.Collapsed;
            Filter13.Visibility = Visibility.Collapsed;
            Filter14.Visibility = Visibility.Collapsed;
            Filter15.Visibility = Visibility.Collapsed;
            Filter16.Visibility = Visibility.Collapsed;
            Filter17.Visibility = Visibility.Collapsed;
            Filter18.Visibility = Visibility.Collapsed;
        }

        private void DeleteAll(object sender, RoutedEventArgs e)
        {
            EnhanceButton.Visibility = Visibility.Visible;
            EnhanceQuestion.Visibility = Visibility.Visible;
            UnenhanceButton.Visibility = Visibility.Collapsed;
            UnenhanceQuestion.Visibility = Visibility.Collapsed;

            Cancel1.Visibility = Visibility.Collapsed;
            AndOr1.SelectedIndex = 0;
            AndOr2.SelectedIndex = 0;
            AndOr3.SelectedIndex = 0;
            Field1.SelectedIndex = 0;
            Field2.SelectedIndex = 0;
            Field3.SelectedIndex = 0;
            Contain1.SelectedIndex = 0;
            Contain2.SelectedIndex = 0;
            Contain3.SelectedIndex = 0;
            Input1.Text = "Your search term";
            Input2.Text = "Your search term";
            Input3.Text = "Your search term";

            AndOr4.SelectedIndex = 0;
            AndOr5.SelectedIndex = 0;
            AndOr6.SelectedIndex = 0;
            Field4.SelectedIndex = 0;
            Field5.SelectedIndex = 0;
            Field6.SelectedIndex = 0;
            Contain4.SelectedIndex = 0;
            Contain5.SelectedIndex = 0;
            Contain6.SelectedIndex = 0;
            Input4.Text = "Your search term";
            Input5.Text = "Your search term";
            Input6.Text = "Your search term";

            AndOr7.SelectedIndex = 0;
            AndOr8.SelectedIndex = 0;
            AndOr9.SelectedIndex = 0;
            Field7.SelectedIndex = 0;
            Field8.SelectedIndex = 0;
            Field9.SelectedIndex = 0;
            Contain7.SelectedIndex = 0;
            Contain8.SelectedIndex = 0;
            Contain9.SelectedIndex = 0;
            Input7.Text = "Your search term";
            Input8.Text = "Your search term";
            Input9.Text = "Your search term";

            AndOr10.SelectedIndex = 0;
            AndOr11.SelectedIndex = 0;
            AndOr12.SelectedIndex = 0;
            Field10.SelectedIndex = 0;
            Field11.SelectedIndex = 0;
            Field12.SelectedIndex = 0;
            Contain10.SelectedIndex = 0;
            Contain11.SelectedIndex = 0;
            Contain12.SelectedIndex = 0;
            Input10.Text = "Your search term";
            Input11.Text = "Your search term";
            Input12.Text = "Your search term";

            AndOr13.SelectedIndex = 0;
            AndOr14.SelectedIndex = 0;
            AndOr15.SelectedIndex = 0;
            Field13.SelectedIndex = 0;
            Field14.SelectedIndex = 0;
            Field15.SelectedIndex = 0;
            Contain13.SelectedIndex = 0;
            Contain14.SelectedIndex = 0;
            Contain15.SelectedIndex = 0;
            Input13.Text = "Your search term";
            Input14.Text = "Your search term";
            Input15.Text = "Your search term";

            AndOr16.SelectedIndex = 0;
            AndOr17.SelectedIndex = 0;
            AndOr18.SelectedIndex = 0;
            Field16.SelectedIndex = 0;
            Field17.SelectedIndex = 0;
            Field18.SelectedIndex = 0;
            Contain16.SelectedIndex = 0;
            Contain17.SelectedIndex = 0;
            Contain18.SelectedIndex = 0;
            Input16.Text = "Your search term";
            Input17.Text = "Your search term";
            Input18.Text = "Your search term";

            Books.IsChecked = false;
            Articles.IsChecked = false;
            Journals.IsChecked = false;
            Papers.IsChecked = false;
            AllItems.IsChecked = true;
            OnlyAvail.IsChecked = false;
            StartYear.Text = "Start year";
            EndYear.Text = "End year";

            Filter4.Visibility = Visibility.Collapsed;
            Filter5.Visibility = Visibility.Collapsed;
            Filter6.Visibility = Visibility.Collapsed;
            Filter7.Visibility = Visibility.Collapsed;
            Filter8.Visibility = Visibility.Collapsed;
            Filter9.Visibility = Visibility.Collapsed;
            Filter10.Visibility = Visibility.Collapsed;
            Filter11.Visibility = Visibility.Collapsed;
            Filter12.Visibility = Visibility.Collapsed;
            Filter13.Visibility = Visibility.Collapsed;
            Filter14.Visibility = Visibility.Collapsed;
            Filter15.Visibility = Visibility.Collapsed;
            Filter16.Visibility = Visibility.Collapsed;
            Filter17.Visibility = Visibility.Collapsed;
            Filter18.Visibility = Visibility.Collapsed;
        }

        private void EnhanceSearch(object sender, RoutedEventArgs e)
        {
            EnhanceButton.Visibility = Visibility.Collapsed;
            EnhanceQuestion.Visibility = Visibility.Collapsed;
            UnenhanceButton.Visibility = Visibility.Visible;
            UnenhanceQuestion.Visibility = Visibility.Visible;

            if (Input1.Text == "cryptography")
            {
                Filter2.Visibility = Visibility.Visible;
                Filter3.Visibility = Visibility.Visible;

                AndOr2.SelectedIndex = 1;
                AndOr3.SelectedIndex = 1;

                Field2.SelectedIndex = Field1.SelectedIndex;
                Field3.SelectedIndex = Field1.SelectedIndex;

                Contain2.SelectedIndex = Contain1.SelectedIndex;
                Contain3.SelectedIndex = Contain1.SelectedIndex;

                Input2.Text = "cryptology";
                Input3.Text = "cryptanalysis";
            }
            else if (Input1.Text == "artificial intelligence" && Input2.Text == "Max Tegmark")
            {
                Filter2.Visibility = Visibility.Visible;
                Filter3.Visibility = Visibility.Visible;

                AndOr3.SelectedIndex = AndOr2.SelectedIndex;
                AndOr2.SelectedIndex = 1;

                Field3.SelectedIndex = Field2.SelectedIndex;
                Field2.SelectedIndex = Field1.SelectedIndex;

                Contain3.SelectedIndex = Contain2.SelectedIndex;
                Contain2.SelectedIndex = Contain1.SelectedIndex;               

                Input2.Text = "AI";
                Input3.Text = "Max Tegmark"; 
            }
            else if (Input1.Text == "men" && Input2.Text == "stereotype" && Input3.Text == "USA" && Input4.Text == "advertisement")
            {
                Filter5.Visibility = Visibility.Visible;
                Filter6.Visibility = Visibility.Visible;
                Filter7.Visibility = Visibility.Visible;
                Filter8.Visibility = Visibility.Visible;
                Filter9.Visibility = Visibility.Visible;
                Filter10.Visibility = Visibility.Visible;
                Filter11.Visibility = Visibility.Visible;
                Filter12.Visibility = Visibility.Visible;

                AndOr4.SelectedIndex = AndOr2.SelectedIndex;
                AndOr7.SelectedIndex = AndOr3.SelectedIndex;
                AndOr10.SelectedIndex = AndOr4.SelectedIndex;
                AndOr2.SelectedIndex = 1;
                AndOr3.SelectedIndex = 1;
                AndOr5.SelectedIndex = 1;
                AndOr6.SelectedIndex = 1;
                AndOr8.SelectedIndex = 1;
                AndOr9.SelectedIndex = 1;
                AndOr11.SelectedIndex = 1;
                AndOr12.SelectedIndex = 1;

                Field4.SelectedIndex = Field2.SelectedIndex;
                Field7.SelectedIndex = Field3.SelectedIndex;
                Field10.SelectedIndex = Field4.SelectedIndex;
                Field2.SelectedIndex = Field1.SelectedIndex;
                Field3.SelectedIndex = Field1.SelectedIndex;
                Field5.SelectedIndex = Field4.SelectedIndex;
                Field6.SelectedIndex = Field4.SelectedIndex;
                Field8.SelectedIndex = Field7.SelectedIndex;
                Field9.SelectedIndex = Field7.SelectedIndex;
                Field11.SelectedIndex = Field10.SelectedIndex;
                Field12.SelectedIndex = Field10.SelectedIndex;

                Contain4.SelectedIndex = Contain2.SelectedIndex;
                Contain7.SelectedIndex = Contain3.SelectedIndex;
                Contain10.SelectedIndex = Contain4.SelectedIndex;
                Contain2.SelectedIndex = Contain1.SelectedIndex;
                Contain3.SelectedIndex = Contain1.SelectedIndex;
                Contain5.SelectedIndex = Contain4.SelectedIndex;
                Contain6.SelectedIndex = Contain4.SelectedIndex;
                Contain8.SelectedIndex = Contain7.SelectedIndex;
                Contain9.SelectedIndex = Contain7.SelectedIndex;
                Contain11.SelectedIndex = Contain10.SelectedIndex;
                Contain12.SelectedIndex = Contain10.SelectedIndex;

                Input2.Text = "male";
                Input3.Text = "masculin";
                Input4.Text = "stereotype";
                Input5.Text = "typecase";
                Input6.Text = "pigeonhole";
                Input7.Text = "USA";
                Input8.Text = "U.S.A.";
                Input9.Text = "America";
                Input10.Text = "advertisement";
                Input11.Text = "commercial";
                Input12.Text = "endorsement";
            }

            else if (Input1.Text == "machine learning" && Input2.Text == "practical applications" && Input3.Text == "detect" && Input4.Text == "emotion")
            {
                Filter5.Visibility = Visibility.Visible;
                Filter6.Visibility = Visibility.Visible;
                Filter7.Visibility = Visibility.Visible;
                Filter8.Visibility = Visibility.Visible;
                Filter9.Visibility = Visibility.Visible;
                Filter10.Visibility = Visibility.Visible;
                Filter11.Visibility = Visibility.Visible;

                AndOr3.SelectedIndex = AndOr2.SelectedIndex;
                AndOr6.SelectedIndex = AndOr3.SelectedIndex;
                AndOr9.SelectedIndex = AndOr4.SelectedIndex;
                AndOr2.SelectedIndex = 1;
                AndOr4.SelectedIndex = 1;
                AndOr5.SelectedIndex = 1;
                AndOr7.SelectedIndex = 1;
                AndOr8.SelectedIndex = 1;
                AndOr10.SelectedIndex = 1;
                AndOr11.SelectedIndex = 1;

                Field3.SelectedIndex = Field2.SelectedIndex;
                Field6.SelectedIndex = Field3.SelectedIndex;
                Field9.SelectedIndex = Field4.SelectedIndex;
                Field2.SelectedIndex = Field1.SelectedIndex;
                Field4.SelectedIndex = Field3.SelectedIndex;
                Field5.SelectedIndex = Field3.SelectedIndex;
                Field7.SelectedIndex = Field6.SelectedIndex;
                Field8.SelectedIndex = Field6.SelectedIndex;
                Field10.SelectedIndex = Field9.SelectedIndex;
                Field11.SelectedIndex = Field9.SelectedIndex;

                Contain3.SelectedIndex = Contain2.SelectedIndex;
                Contain6.SelectedIndex = Contain3.SelectedIndex;
                Contain9.SelectedIndex = Contain4.SelectedIndex;
                Contain2.SelectedIndex = Contain1.SelectedIndex;
                Contain4.SelectedIndex = Contain3.SelectedIndex;
                Contain5.SelectedIndex = Contain3.SelectedIndex;
                Contain7.SelectedIndex = Contain6.SelectedIndex;
                Contain8.SelectedIndex = Contain6.SelectedIndex;
                Contain10.SelectedIndex = Contain9.SelectedIndex;
                Contain11.SelectedIndex = Contain9.SelectedIndex;
                
                Input2.Text = "deep learning";
                Input3.Text = "practical applications";
                Input4.Text = "practicality";
                Input5.Text = "utilization";
                Input6.Text = "detect";
                Input7.Text = "identify";
                Input8.Text = "distinguish";
                Input9.Text = "emotion";
                Input10.Text = "feeling";
                Input11.Text = "reaction";
            }
        }

        private void UnenhanceSearch(object sender, RoutedEventArgs e)
        {
            EnhanceButton.Visibility = Visibility.Visible;
            EnhanceQuestion.Visibility = Visibility.Visible;
            UnenhanceButton.Visibility = Visibility.Collapsed;
            UnenhanceQuestion.Visibility = Visibility.Collapsed;

            if (Input1.Text == "cryptography" && Input2.Text == "cryptology" && Input3.Text == "cryptanalysis")
            {
                Filter2.Visibility = Visibility.Visible;
                Filter3.Visibility = Visibility.Visible;

                AndOr2.SelectedIndex = 0;
                AndOr3.SelectedIndex = 0;

                Field2.SelectedIndex = 0;
                Field3.SelectedIndex = 0;

                Contain2.SelectedIndex = 0;
                Contain3.SelectedIndex = 0;

                Input2.Text = "Your keyword";
                Input3.Text = "Your keyword";
            }
            else if (Input1.Text == "artificial intelligence" && Input2.Text == "AI" && Input3.Text == "Max Tegmark")
            {
                Filter2.Visibility = Visibility.Visible;
                Filter3.Visibility = Visibility.Visible;

                AndOr2.SelectedIndex = AndOr3.SelectedIndex;
                AndOr3.SelectedIndex = 0;

                Field2.SelectedIndex = Field3.SelectedIndex;
                Field3.SelectedIndex = 0;

                Contain2.SelectedIndex = Contain3.SelectedIndex;
                Contain3.SelectedIndex = 0;

                Input2.Text = "Max Tegmark";
                Input3.Text = "Your keyword";
            }

            else if (Input1.Text == "men" && Input4.Text == "stereotype" && Input7.Text == "USA" && Input10.Text == "advertisement")
            {
                Filter5.Visibility = Visibility.Visible;
                Filter6.Visibility = Visibility.Visible;
                Filter7.Visibility = Visibility.Collapsed;
                Filter8.Visibility = Visibility.Collapsed;
                Filter9.Visibility = Visibility.Collapsed;
                Filter10.Visibility = Visibility.Collapsed;
                Filter11.Visibility = Visibility.Collapsed;
                Filter12.Visibility = Visibility.Collapsed;

                AndOr2.SelectedIndex = AndOr4.SelectedIndex;
                AndOr3.SelectedIndex = AndOr7.SelectedIndex;
                AndOr4.SelectedIndex = AndOr10.SelectedIndex;
                AndOr5.SelectedIndex = 0;
                AndOr6.SelectedIndex = 0;

                Field2.SelectedIndex = Field4.SelectedIndex;
                Field3.SelectedIndex = Field7.SelectedIndex;
                Field4.SelectedIndex = Field10.SelectedIndex;
                Field5.SelectedIndex = 0;
                Field6.SelectedIndex = 0;

                Contain2.SelectedIndex = Contain4.SelectedIndex;
                Contain3.SelectedIndex = Contain7.SelectedIndex;
                Contain4.SelectedIndex = Contain10.SelectedIndex;
                Contain5.SelectedIndex = 0;
                Contain6.SelectedIndex = 0;

                Input2.Text = "stereotype";
                Input3.Text = "USA";
                Input4.Text = "advertisement";
                Input5.Text = "Your keyword";
                Input6.Text = "Your keyword";
            }

            else if (Input1.Text == "machine learning" && Input3.Text == "practical applications" && Input6.Text == "detect" && Input9.Text == "emotion")
            {
                Filter5.Visibility = Visibility.Visible;
                Filter6.Visibility = Visibility.Visible;
                Filter7.Visibility = Visibility.Collapsed;
                Filter8.Visibility = Visibility.Collapsed;
                Filter9.Visibility = Visibility.Collapsed;
                Filter10.Visibility = Visibility.Collapsed;
                Filter11.Visibility = Visibility.Collapsed;
                Filter12.Visibility = Visibility.Collapsed;

                AndOr2.SelectedIndex = AndOr3.SelectedIndex;
                AndOr3.SelectedIndex = AndOr6.SelectedIndex;
                AndOr4.SelectedIndex = AndOr9.SelectedIndex;
                AndOr5.SelectedIndex = 0;
                AndOr6.SelectedIndex = 0;

                Field2.SelectedIndex = Field3.SelectedIndex;
                Field3.SelectedIndex = Field6.SelectedIndex;
                Field4.SelectedIndex = Field9.SelectedIndex;
                Field5.SelectedIndex = 0;
                Field6.SelectedIndex = 0;

                Contain2.SelectedIndex = Contain3.SelectedIndex;
                Contain3.SelectedIndex = Contain6.SelectedIndex;
                Contain4.SelectedIndex = Contain9.SelectedIndex;
                Contain5.SelectedIndex = 0;
                Contain6.SelectedIndex = 0;

                Input2.Text = "practical applications";
                Input3.Text = "detect";
                Input4.Text = "emotion";
                Input5.Text = "Your keyword";
                Input6.Text = "Your keyword";
            }
        }

        private void SearchGotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == "Search by title or author...")
            {
                textBox.Text = "";
            }
        }

        private void SearchTermGotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == "Your search term")
            {
                textBox.Text = "";
            }
        }
        private void StartYearGotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == "Start year")
            {
                textBox.Text = "";
            }
        }
        private void EndYearGotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == "End year")
            {
                textBox.Text = "";
            }
        }

        private void GoToPage3_Click(object sender, RoutedEventArgs e)
        {
            ResultPage RP = new ResultPage();
            this.NavigationService.Navigate(RP);
        }

        private void GoToLogIn_Click(object sender, RoutedEventArgs e)
        {
            LogInPage LI = new LogInPage();
            this.NavigationService.Navigate(LI);
        }

        private void GoToAccount_Click(object sender, RoutedEventArgs e)
        {
            AccountPage AP = new AccountPage();
            this.NavigationService.Navigate(AP);
        }

        private void BasicSearch_ButtonClick(object sender, RoutedEventArgs e)
        {
            basicSearchQuery = BasicSearchBox.Text;
            if (basicSearchQuery == "Search by title or author..." || string.IsNullOrWhiteSpace(basicSearchQuery))
            {
                MessageBox.Show("Invalid search! Please enter a title or author.");
                return;
            }

            GoToPage3_Click(null, null);
        }

        private void AdvancedSearchButtonClick(object sender, RoutedEventArgs e)
        {
            GoToPage3_Click(null, null);
        }
    }

}

