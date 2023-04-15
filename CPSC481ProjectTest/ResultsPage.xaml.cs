using System;
using System.Collections;
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
    /// Interaction logic for ResultsPage.xaml
    /// </summary>
    public partial class ResultsPage : Page
    {
        public HashSet<string> appliedFilters = new HashSet<string>();
     
        public ResultsPage()
        {
            InitializeComponent();
            // CHANGE LATER
            // Display the results. This currently displays everything in the database.
            DisplayResults(Database.items);

            // Auto check 'All Items' under availability
            AllItemsRadio.IsChecked = true;

        }
        // This is looping through the database and displaying everything
        private void DisplayResults(Item[] items)
        {
            // Initially set the grid to have no rows
            ResultGrid.RowDefinitions.Clear();
            ResultGrid.Children.Clear();

            // Display item quantities
            DisplayItemQuantities(items);

            // Filling the result grid with sample data
            foreach (Item item in items)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(150); // This will be the height of each row in the results grid
                ResultGrid.RowDefinitions.Add(row);

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
                Grid.SetRow(itemPreview, ResultGrid.RowDefinitions.Count - 1);
                Grid.SetColumn(itemPreview, 0);
                ResultGrid.Children.Add(itemPreview);

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

                // ADDING UI ELEMENTS TO STACK PANEL
                // Year of Publication of item
                TextBlock yearTextBlock = new TextBlock();
                yearTextBlock.Text = item.yearOfPublication;

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

                Grid.SetRow(stackPanel, ResultGrid.RowDefinitions.Count - 1);
                Grid.SetColumn(stackPanel, 1);

                ResultGrid.Children.Add(stackPanel);

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

                Grid.SetRow(stackPanel2, ResultGrid.RowDefinitions.Count - 1);
                Grid.SetColumn(stackPanel2, 2);
                ResultGrid.Children.Add(stackPanel2);
            }

            string rowCount = ResultGrid.RowDefinitions.Count.ToString();
            MessageBox.Show($"Number of rows: {rowCount}");
        }

        // This is for displaying the quantity of items of each type
        private void DisplayItemQuantities(Item[] items)
        {
            int numBooks = 0;
            int numJournals = 0;
            int numPapers = 0;
            int numArticles = 0;

            foreach (Item item in items)
            {
                if (item.type == ItemType.Book)
                {
                    numBooks++;
                    continue;
                }

                if (item.type == ItemType.Journal)
                {
                    numJournals++;
                    continue;
                }

                if (item.type == ItemType.Paper)
                {
                    numPapers++;
                    continue;
                }

                if (item.type == ItemType.Article)
                {
                    numArticles++;
                    continue;
                }
            }

            BookQuantity.Text = numBooks.ToString();
            JournalQuantity.Text = numJournals.ToString();
            PaperQuantity.Text = numPapers.ToString();
            ArticleQuantity.Text = numArticles.ToString();
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

        private void StartYear_GotFocus(object sender, RoutedEventArgs e)
        {
            if (StartYear.Text == "Start Year")
            {
                StartYear.Text = "";
            }
        }

        private void EndYear_GotFocus(object sender, RoutedEventArgs e)
        {
            if (EndYear.Text == "End Year")
            {
                EndYear.Text = "";
            }
        }

        // This function deals with the filters in the filter section.
        // It mimics live updates without the need to hit an "Apply' button to apply filters
        private void FilterApplied(object sender, RoutedEventArgs e)
        {
            List<Item> filteredItems = new List<Item>();

            // Check if the user filtered by 'All Items'
            if (AllItemsRadio.IsChecked == true)
            {
                Item[] arr = new Item[Database.items.Length];
                Array.Copy(Database.items, arr, Database.items.Length);
                filteredItems = arr.ToList();
            }

            // Check if the user filtered by 'Only Available Items'
            else
            {
                foreach (Item item in Database.items)
                {
                    if (item.isAvailable)
                        filteredItems.Add(item);
                }
            }

            bool defaultState = false;
            // If all checkboxes are unchecked, that means we display all item types
            if (BooksCheckbox.IsChecked == false && JournalsCheckbox.IsChecked == false && PapersCheckbox.IsChecked == false && ArticlesCheckbox.IsChecked == false)
            {
                defaultState = true;
            }

            // Check the item type filter
            if (!defaultState)
            {
                HashSet<ItemType> allItemTypes = new HashSet<ItemType>();
                if (BooksCheckbox.IsChecked == true)
                    allItemTypes.Add(ItemType.Book);
                if (JournalsCheckbox.IsChecked == true)
                    allItemTypes.Add(ItemType.Journal);
                if (PapersCheckbox.IsChecked == true)
                    allItemTypes.Add(ItemType.Paper);
                if (ArticlesCheckbox.IsChecked == true)
                    allItemTypes.Add(ItemType.Article);

                for (int i = 0; i < filteredItems.Count; i++)
                {
                    if (!allItemTypes.Contains(filteredItems[i].type))
                    {
                        filteredItems.RemoveAt(i);
                        i--;
                    }
                }

                string s = "";
                foreach (ItemType t in allItemTypes)
                {
                    if (t == ItemType.Book)
                        s += "Book, ";
                    else if (t == ItemType.Journal)
                        s += "Journal, ";
                    else if (t == ItemType.Paper)
                        s += "Paper, ";
                    else
                        s += "Article, ";
                }
                MessageBox.Show($"All Item Types: {s}"); // DEBUG LINE (REMOVE LATER)
            }

            // Error check user input for 'Start Year' and 'End Year'
            if (string.IsNullOrWhiteSpace(StartYear.Text))
            {
                StartYear.Text = "Start Year";
            }
            else if (string.IsNullOrWhiteSpace(EndYear.Text))
            {
                EndYear.Text = "End Year";
            }

            else
            {
                if (StartYear.Text.Length == 4)
                {
                    // Check if the user input for 'Start Year' can be parsed as in integer
                    int parsedResult;
                    if (int.TryParse(StartYear.Text, out parsedResult) == true)
                    {
                        // Remove all items whose publication year is less than the enter Start Year
                        filteredItems.RemoveAll(item => int.Parse(item.yearOfPublication.Substring(0, 4)) < parsedResult);
                    }
                }

                if (EndYear.Text.Length == 4)
                {
                    // Check if the user input for 'End Year' can be parsed as in integer
                    int parsedResult;
                    if (int.TryParse(EndYear.Text, out parsedResult) == true)
                    {
                        // Remove all items whose publication year is greater than the entered End Year
                        filteredItems.RemoveAll(item => int.Parse(item.yearOfPublication.Substring(0, 4)) > parsedResult);
                    }
                }
            }

            Item[] filteredItemsArray = filteredItems.ToArray();
            DisplayResults(filteredItemsArray);
        }

        private void Keyword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (KeywordBox1.Text != "")
            {
                KeywordBox1.Text = "";
            }
        }

        private void Keyword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(KeywordBox1.Text))
            {
                KeywordBox1.Text = "Your keyword";
            }
        }

        private void ResetFilterButton_Click(object? sender, RoutedEventArgs? e)
        {
            // Uncheck all checkboxes on item type
            BooksCheckbox.IsChecked = false;
            JournalsCheckbox.IsChecked = false;
            PapersCheckbox.IsChecked = false;
            ArticlesCheckbox.IsChecked = false;

            // Check the radio button for "All Items" under availability
            AllItemsRadio.IsChecked = true;

            // Clear the start year and end year input fields
            StartYear.Text = "Start Year";
            EndYear.Text = "End Year";

            // Display the search query results without any filters being applied.
            // This is to properly show that all the filter options were reset.
            string searchQuery = SearchBox.Text;
            if (searchQuery == "" || searchQuery == "Search...")
            {
                Item[] emptyResults = { };
                DisplayResults(emptyResults);
            }
            else
            {
                DisplaySearchQueryResults();
            }
        }

        private void AddNewFilterButton_Click(object sender, RoutedEventArgs e)
        {
            // create a new WrapPanel
            WrapPanel wrapPanel = new WrapPanel();

            // create the RemoveFilterButton
            Button removeFilterButton = new Button();
            removeFilterButton.Margin = new Thickness(10, 0, 0, 0);
            removeFilterButton.Height = 19;
            removeFilterButton.Width = 16;
            removeFilterButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFAEDCD"));
            removeFilterButton.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFAEDCD"));
            removeFilterButton.Click += RemoveFilterButton_Click;

            // create the Image for the RemoveFilterButton
            Image image = new Image();
            image.Source = new BitmapImage(new Uri("/images/cancelicon.png", UriKind.Relative));
            removeFilterButton.Content = image;

            // add the RemoveFilterButton to the WrapPanel
            wrapPanel.Children.Add(removeFilterButton);

            // create the first TextBox
            TextBox textBox1 = new TextBox();
            textBox1.Margin = new Thickness(0, 10, 0, 10);
            textBox1.FontStyle = FontStyles.Italic;
            textBox1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB8B4B4"));
            textBox1.Text = "And";

            // add the first TextBox to the WrapPanel
            wrapPanel.Children.Add(textBox1);

            // create the first ComboBox
            ComboBox comboBox1 = new ComboBox();
            comboBox1.Width = 14;
            comboBox1.Height = 19;

            // create the ComboBoxItems for the first ComboBox
            ComboBoxItem comboBoxItem1 = new ComboBoxItem();
            comboBoxItem1.Content = "And";
            ComboBoxItem comboBoxItem2 = new ComboBoxItem();
            comboBoxItem2.Content = "Or";
            ComboBoxItem comboBoxItem3 = new ComboBoxItem();
            comboBoxItem3.Content = "Not";

            // add the ComboBoxItems to the first ComboBox
            comboBox1.Items.Add(comboBoxItem1);
            comboBox1.Items.Add(comboBoxItem2);
            comboBox1.Items.Add(comboBoxItem3);

            // add the first ComboBox to the WrapPanel
            wrapPanel.Children.Add(comboBox1);

            // create the second TextBox
            TextBox textBox2 = new TextBox();
            textBox2.Margin = new Thickness(5, 10, 0, 10);
            textBox2.FontStyle = FontStyles.Italic;
            textBox2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB8B4B4"));
            textBox2.Text = "Field";

            // add the second TextBox to the WrapPanel
            wrapPanel.Children.Add(textBox2);

            // create the second ComboBox
            ComboBox comboBox2 = new ComboBox();
            comboBox2.Width = 14;
            comboBox2.Height = 19;

            // create the ComboBoxItems for the second ComboBox
            ComboBoxItem comboBoxItem4 = new ComboBoxItem();
            comboBoxItem4.Content = "Title";
            ComboBoxItem comboBoxItem5 = new ComboBoxItem();
            comboBoxItem5.Content = "Author";
            ComboBoxItem comboBoxItem6 = new ComboBoxItem();
            comboBoxItem6.Content = "Subject";

            // add the ComboBoxItems to the second ComboBox
            comboBox2.Items.Add(comboBoxItem4);
            comboBox2.Items.Add(comboBoxItem5);
            comboBox2.Items.Add(comboBoxItem6);

            // add the second ComboBox to the WrapPanel
            wrapPanel.Children.Add(comboBox2);

            // create the third TextBox
            TextBox textBox3 = new TextBox();
            textBox3.Margin = new Thickness(5, 10, 0, 10);
            textBox3.FontStyle = FontStyles.Italic;
            textBox3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB8B4B4"));
            textBox3.Text = "Contains";

            // add the third TextBox to the WrapPanel
            wrapPanel.Children.Add(textBox3);

            // create the third ComboBox
            ComboBox comboBox3 = new ComboBox();
            comboBox3.Width = 14;
            comboBox3.Height = 19;
            comboBox3.Items.Add("Contains");
            comboBox3.Items.Add("Is exactly");
            comboBox3.Items.Add("Starts with");
            //WrapPanel.SetMargin(comboBox3, new Thickness(0, 10, 0, 10));
            comboBox3.ItemContainerStyle = new Style(typeof(ComboBoxItem));
            comboBox3.ItemContainerStyle.Setters.Add(new Setter(MinWidthProperty, 100d));
            wrapPanel.Children.Add(comboBox3);

            TextBox keywordBox = new TextBox();
            keywordBox.Margin = new Thickness(0, 0, 0, 10);
            keywordBox.FontStyle = FontStyles.Italic;
            keywordBox.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xB5, 0xAE, 0xAE));
            keywordBox.Width = 147;
            keywordBox.Text = "Your keyword";

            SearchTerms.Children.Add(wrapPanel);
            SearchTerms.Children.Add(keywordBox);
        }

        private void RemoveFilterButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the last added child element of the StackPanel
            UIElement lastChild = SearchTerms.Children[SearchTerms.Children.Count - 1];
            UIElement secondLastChild = SearchTerms.Children[SearchTerms.Children.Count - 2];

            // Check if the last child element is a WrapPanel
            if (lastChild is TextBox && secondLastChild is WrapPanel)
            {
                // Remove the last child element from the StackPanel
                SearchTerms.Children.Remove(lastChild);
                SearchTerms.Children.Remove(secondLastChild);
            }
        }

        private void MyAccountButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchButtonClick(object sender, RoutedEventArgs e)
        {
            // Reset the filter when searching by a new search term
            ResetFilterButton_Click(null, null);
            DisplaySearchQueryResults();
        }

        private void DisplaySearchQueryResults()
        {
            // Convert the search query to all lower case
            string searchQuery = SearchBox.Text.ToLower();
            //MessageBox.Show($"Search query: {searchQuery}");

            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                return;
            }

            // This will store the results from the database that contain the search query in the TITLE
            List<Item> results = new List<Item>();
            foreach (Item item in Database.items)
            {
                if (item.title.ToLower().Contains(searchQuery))
                {
                    results.Add(item);
                }
            }

            // DEBUG MESSAGE (REMOVE LATER)
            string resultCount = results.Count.ToString();
            string resultMessage = $"Total results: {resultCount}";
            MessageBox.Show(resultMessage);

            // Convert result list to an array in order to display them
            Item[] new_results = results.ToArray();
            DisplayResults(new_results);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}

