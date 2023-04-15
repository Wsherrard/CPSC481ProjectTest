using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        private void Cancel21Clicked(object sender, RoutedEventArgs e)
        {
            FilterTwo.Visibility = Visibility.Collapsed;
        }

        private void Cancel31Clicked(object sender, RoutedEventArgs e)
        {
            FilterThree.Visibility = Visibility.Collapsed;
        }

        private void Cancel12Clicked(object sender, RoutedEventArgs e)
        {
            FilterOne2.Visibility = Visibility.Collapsed;
        }

        private void Cancel22Clicked(object sender, RoutedEventArgs e)
        {
        ///    Panel parent = VisualTreeHelper.GetParent(FilterTwo2) as Panel;
        ///    parent.Children.Remove(FilterTwo2);
        }

        private void Cancel32Clicked(object sender, RoutedEventArgs e)
        {
         ///   Panel parent = VisualTreeHelper.GetParent(FilterThree2) as Panel;
        ///    parent.Children.Remove(FilterThree2);
        }

        private void AndOr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Field_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Contain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddFilterClicked(object sender, RoutedEventArgs e)
        {
            AddedFilters.Visibility = Visibility.Visible;
            // Get the parent container element
            var container = (Grid)VisualTreeHelper.GetParent(ThreeFilters2);

            // Clone the stack panel
            StackPanel newStackPanel = new StackPanel();
            foreach (UIElement child in ThreeFilters2.Children)
            {
                // Clone each child element
                UIElement newChild = CloneUIElement(child);
                newStackPanel.Children.Add(newChild);
            }

            // Set the top margin of the cloned StackPanel
            newStackPanel.Margin = new Thickness(0, ThreeFilters.ActualHeight, 0, 0);

            // Add the cloned stack panel to the parent container
            container.Children.Add(newStackPanel);
        }

        private UIElement CloneUIElement(UIElement element)
        {
            // Create a XAML string from the UI element
            string xaml = XamlWriter.Save(element);

            // Use a XAML reader to create a new UI element from the XAML string
            StringReader stringReader = new StringReader(xaml);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            UIElement newElement = (UIElement)XamlReader.Load(xmlReader);

            return newElement;
        }

        private void DeleteSearchTerms(object sender, RoutedEventArgs e)
        {
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
            if (AddedFilters.Visibility == Visibility.Visible)
            {
                AddedFilters.Visibility = Visibility.Collapsed;
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
        private void EnhanceQuestion_MouseEnter(object sender, MouseEventArgs e)
        {
            EnhanceQuestion.Visibility = Visibility.Visible;
        }
        private void EnhanceQuestion_MouseLeave(object sender, MouseEventArgs e)
        {
            EnhanceQuestion.Visibility = Visibility.Hidden;
        }

        private void SearchTerm_MouseEnter(object sender, MouseEventArgs e)
        {
            SearchTermQuestion.Visibility = Visibility.Visible;
        }
        private void SearchTerm_MouseLeave(object sender, MouseEventArgs e)
        {
            SearchTermQuestion.Visibility = Visibility.Hidden;
        }
        private void MyAccount(object sender, RoutedEventArgs e)
        {
            AccountPage AP = new AccountPage();
            this.NavigationService.Navigate(AP);
        }
    }

}

