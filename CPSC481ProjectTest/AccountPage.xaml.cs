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
    /// Interaction logic for AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        public AccountPage()
        {
            InitializeComponent();
            DisplayHold();
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
        private void DisplayResults(Item[] items)
        {

            // Initially set the grid to have no rows
            HoldGrid.RowDefinitions.Clear();
            HoldGrid.Children.Clear();

            // Filling the result grid with sample data
            foreach (Item item in items)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(150); // This will be the height of each row in the results grid
                HoldGrid.RowDefinitions.Add(row);

                // Grab the image from the 'databaseImages' folder
                Image itemPreview = new Image();
                itemPreview.Height = 100;
                itemPreview.Width = 100;
                itemPreview.Margin = new Thickness(0, 0, 0, 40);
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                string imagePath = "..\\..\\" + item.imagePath;
                bitmapImage.UriSource = new Uri(imagePath, UriKind.Relative);
                bitmapImage.EndInit();
                itemPreview.Source = bitmapImage;

                // Add the image to the grid
                Grid.SetRow(itemPreview, HoldGrid.RowDefinitions.Count - 1);
                Grid.SetColumn(itemPreview, 0);
                HoldGrid.Children.Add(itemPreview);

                // This stack panel will consist of the item type, title, author, and year
                StackPanel stackPanel = new StackPanel();

                // Check the item type
                string typeOfItem = "";
                if (item.type == ItemType.Book)
                {
                    typeOfItem = "Book";
                }
                else if (item.type == ItemType.Journal)
                {
                    typeOfItem = "Journal";
                }
                else if (item.type == ItemType.Paper)
                {
                    typeOfItem = "Paper";
                }
                else if (item.type == ItemType.Article)
                {
                    typeOfItem = "Article";
                }
                else
                {
                    typeOfItem = "UNKNOWN ITEM TYPE"; // For debugging
                }

                // Type of item
                TextBlock itemTypeTextBlock = new TextBlock();
                itemTypeTextBlock.Text = typeOfItem;
                itemTypeTextBlock.FontStyle = FontStyles.Italic;

                // Title of item
                TextBlock titleTextBlock = new TextBlock();
                titleTextBlock.Text = item.title;
                titleTextBlock.FontWeight = FontWeights.Bold;
                titleTextBlock.Foreground = Brushes.MediumBlue;
                titleTextBlock.MouseDown += TitleClick; // Add a left click event handler on the title

                // Author(s) of item
                List<TextBlock> allAuthors = new List<TextBlock>();
                foreach (string a in item.author)
                {
                    TextBlock authorTextBlock = new TextBlock();
                    authorTextBlock.Text = a;
                    allAuthors.Add(authorTextBlock);
                }

                // Year of Publication of item
                TextBlock yearTextBlock = new TextBlock();
                yearTextBlock.Text = item.yearOfPublication;

                // ADDING UI ELEMENTS TO STACK PANEL
                // First add the type of item
                stackPanel.Children.Add(itemTypeTextBlock);

                // Then add the title
                stackPanel.Children.Add(titleTextBlock);

                // Then add the authors
                WrapPanel wrapPanel = new WrapPanel();
                int i = 0;
                foreach (TextBlock a in allAuthors)
                {
                    if (i != allAuthors.Count - 1)
                        a.Text += "; ";
                    wrapPanel.Children.Add(a);
                    i++;
                }
                stackPanel.Children.Add(wrapPanel);

                // Then add the publication year
                stackPanel.Children.Add(yearTextBlock);

                // Finally, display 'Peer Reviewed' if necessary
                // Peer Reviewed
                if (item.isPeerReviewed)
                {
                    TextBlock empty = new TextBlock();
                    TextBlock peerReviewedTextBlock = new TextBlock();
                    peerReviewedTextBlock.Text = "Peer Reviewed";
                    peerReviewedTextBlock.Foreground = Brushes.Purple;
                    peerReviewedTextBlock.FontStyle = FontStyles.Italic;
                    stackPanel.Children.Add(empty);
                    stackPanel.Children.Add(peerReviewedTextBlock);
                }

                Grid.SetRow(stackPanel, HoldGrid.RowDefinitions.Count - 1);
                Grid.SetColumn(stackPanel, 1);

                HoldGrid.Children.Add(stackPanel);

                // THIS WILL BE FOR THE ITEM LOCATION AND AVAILABILITY
                StackPanel stackPanel2 = new StackPanel();

                // Get the availability
                TextBlock availabilityTextBlock = new TextBlock();
                availabilityTextBlock.FontWeight = FontWeights.Bold;
                if (item.isAvailable)
                {
                    availabilityTextBlock.Text = "Available";
                    availabilityTextBlock.Foreground = Brushes.Green;
                }
                else
                {
                    availabilityTextBlock.Text = "Not Available";
                    availabilityTextBlock.Foreground = Brushes.Red;
                }
                // Get the item's location from the database
                TextBlock locationTextBlock = new TextBlock();
                locationTextBlock.Text = "Location: " + item.location;
                locationTextBlock.FontWeight = FontWeights.Bold;

                // Empty TextBlock
                TextBlock emptyTextBlock = new TextBlock();

                // Find Location on Map (will navigate to item information page later)
                TextBlock mapTextBlock = new TextBlock();
                mapTextBlock.Text = "Find Location on Map";
                mapTextBlock.FontWeight = FontWeights.Bold;
                mapTextBlock.TextDecorations = TextDecorations.Underline;
                string hexColor = "#FF35599C"; // red color in hexadecimal format
                Color color = (Color)ColorConverter.ConvertFromString(hexColor);
                mapTextBlock.Foreground = new SolidColorBrush(color);
                mapTextBlock.MouseDown += MapClick; // Add a left click event handler on the map

                // Add these elements to the stack panel
                stackPanel2.Children.Add(availabilityTextBlock);
                stackPanel2.Children.Add(emptyTextBlock);
                // Only display Item location info if item is available
                if (item.isAvailable)
                {
                    stackPanel2.Children.Add(locationTextBlock);
                    stackPanel2.Children.Add(mapTextBlock);
                }

                Grid.SetRow(stackPanel2, HoldGrid.RowDefinitions.Count - 1);
                Grid.SetColumn(stackPanel2, 2);
                HoldGrid.Children.Add(stackPanel2);
            }

            string rowCount = HoldGrid.RowDefinitions.Count.ToString();
            MessageBox.Show($"Number of rows: {rowCount}");
        }
        private void TitleClick(object sender, MouseButtonEventArgs e)
        {
            // TODO: implement window switch to item detail page
            MessageBox.Show("Navigating to Item Detail page...");
        }

        private void MapClick(object sender, MouseButtonEventArgs e)
        {
            // TODO: implement window switch to item detail page
            MessageBox.Show("Navigating to map on Item Detail page...");
        }
        private void DisplayHold()
        {
            List<Item> results = new List<Item>();
            foreach (Item item in HoldDatabase.hold)
            {
                string itemTitle = item.title.ToLower();
                itemTitle = itemTitle.Replace("-", "");
                itemTitle = itemTitle.Replace("--", "");
                itemTitle = itemTitle.Replace(":", "");
                itemTitle = itemTitle.Replace(" ", "");
            }

          // Convert result list to an array in order to display them
            Item[] new_results = results.ToArray();
            DisplayResults(new_results);
        }
    }
}


