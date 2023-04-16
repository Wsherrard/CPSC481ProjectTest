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
    /// Interaction logic for ResultPage.xaml
    /// </summary>
    public partial class ResultPage : Page
    {
        List<Item> itemsCopy; // This will be used for navigating to the item details page
        Hashtable itemQuantities = new Hashtable();
        string searchQuery = SearchPage.basicSearchQuery;

        public ResultPage()
        {
            InitializeComponent();

            // CHANGE LATER
            // Display the results. This currently displays everything in the database.
            //DisplayResults(Database.items);

            SearchBox.Text = searchQuery;
            //SearchButtonClick(null, null);
            DisplaySearchQueryResults();

            // Auto check 'All Items' under availability
            //AllItemsRadio.IsChecked = true;
        }

        public ResultPage(Item[] items)
        {
            InitializeComponent();

            DisplayResults(items);

            // Auto check 'All Items' under availability
            //AllItemsRadio.IsChecked = true;
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
                string imagePath = item.imagePath;
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
            // Get the TextBlock element the user clicked on
            TextBlock t = sender as TextBlock;

            // Grab the text in the TextBlock
            string itemTitle = t.Text;

            // Get the parent StackPanel
            StackPanel sp = (StackPanel)t.Parent;

            TextBlock yearTextBlock = (TextBlock)sp.Children[3];
            string itemYear = yearTextBlock.Text;

            // Search the global List 'itemsCopy' to get the index of the element
            int index = -1;
            for (int i = 0; i < itemsCopy.Count; i++)
            {
                if (itemsCopy[i].title == itemTitle && itemsCopy[i].yearOfPublication == itemYear)
                {
                    index = i;
                    break;
                }
            }

            MessageBox.Show($"You clicked (index {index}): {itemTitle}");
            MessageBox.Show("Navigating to Item Detail page...");

            DetailPage AP = new DetailPage(itemsCopy.ToArray(), index, false);
            this.NavigationService.Navigate(AP);
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
            // This will keep track of all filtered items
            List<Item> filteredItems = new List<Item>();

            // We start from a broad filter such as 'Item Availability' and narrow our items down from there

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

                    else
                    {
                        // Display a message indicating to the user to only enter numbers
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

                    else
                    {
                        // Display a message indicating to the user to only enter numbers
                    }
                }
            }

            // FILTER BY SEARCH TERMS
            // First get all the StackPanels consisting of the search term parts
            List<StackPanel> terms = new List<StackPanel>();
            int numSearchTerms = SearchTerms.Children.Count;
            string temp = "";
            for (int i = 0; i < numSearchTerms; i++)
            {
                terms.Add((StackPanel)SearchTerms.Children[i]);
            }

            // Then get the selected dropdown options and keyword input from each search term
            // For now, we're storing them in separate lists. Might change this to be a single 2D structure.
            List<string> logicalOperators = new List<string>();
            List<string> fields = new List<string>();
            List<string> patterns = new List<string>();
            List<string> keywords = new List<string>();
            string str = ""; // FOR DEBUGGING (REMOVE LATER)
            for (int i = 0; i < terms.Count; i++)
            {
                // Only grab the search terms from the visible search terms (ignoring any collapsed StackPanels)
                if (terms[i].Visibility == Visibility.Visible)
                {
                    // The TextBox is the last element of the StackPanel
                    TextBox keywordTextBox = (TextBox)terms[i].Children[terms[i].Children.Count - 1];
                    keywords.Add(keywordTextBox.Text);

                    // The wrap panel consists of the ComboBox elements
                    WrapPanel wp = (WrapPanel)terms[i].Children[0];

                    // The first search term doesn't have a logical operator dropdown
                    if (i == 0)
                    {
                        // Get the combo boxes, which are children of the WrapPanel we retrieved above
                        ComboBox fieldComboBox = (ComboBox)wp.Children[wp.Children.Count - 2];
                        ComboBox patternComboBox = (ComboBox)wp.Children[wp.Children.Count - 1];

                        // Get the selected combo box items
                        ComboBoxItem fieldOption = fieldComboBox.SelectedItem as ComboBoxItem;
                        ComboBoxItem patternOption = patternComboBox.SelectedItem as ComboBoxItem;

                        // Extract the selected ComboBoxItems as a string
                        string selectedField = fieldOption.Content.ToString();
                        fields.Add(selectedField);
                        string selectedPattern = patternOption.Content.ToString();
                        patterns.Add(selectedPattern);

                        // DEBUG LINE (REMOVE LATER)
                        str += "(" + selectedField + ", " + selectedPattern + ", " + keywordTextBox.Text + ")\n";
                    }
                    else
                    {
                        // Get the combo boxes, which are children of the WrapPanel we retrieved above
                        ComboBox logicalOperatorComboBox = (ComboBox)wp.Children[wp.Children.Count - 3];
                        ComboBox fieldComboBox = (ComboBox)wp.Children[wp.Children.Count - 2];
                        ComboBox patternComboBox = (ComboBox)wp.Children[wp.Children.Count - 1];

                        // Get the selected combo box items
                        ComboBoxItem logicalOperatorOption = logicalOperatorComboBox.SelectedItem as ComboBoxItem;
                        ComboBoxItem fieldOption = fieldComboBox.SelectedItem as ComboBoxItem;
                        ComboBoxItem patternOption = patternComboBox.SelectedItem as ComboBoxItem;

                        // Extract the selected ComboBoxItems as a string
                        string selectedLogicalOperator = logicalOperatorOption.Content.ToString();
                        logicalOperators.Add(selectedLogicalOperator);
                        string selectedField = fieldOption.Content.ToString();
                        fields.Add(selectedField);
                        string selectedPattern = patternOption.Content.ToString();
                        patterns.Add(selectedPattern);

                        // DEBUG LINE (REMOVE LATER)
                        str += "(" + selectedLogicalOperator + ", " + selectedField + ", " + selectedPattern + ", " + keywordTextBox.Text + ")\n";
                    }
                }
            }
            // DEBUG LINE (REMOVE LATER)
            MessageBox.Show($"Search Terms:\n{str}");

            // Now base all these filters on what's in the search box
            string searchQuery = SearchBox.Text.ToLower().Trim();
            searchQuery = searchQuery.Replace("-", "");
            searchQuery = searchQuery.Replace("--", "");
            searchQuery = searchQuery.Replace(":", "");
            searchQuery = searchQuery.Replace(" ", "");
            for (int i = 0; i < filteredItems.Count; i++)
            {
                string s = filteredItems[i].title.ToLower();
                s = s.Replace("-", "");
                s = s.Replace("--", "");
                s = s.Replace(":", "");
                s = s.Replace(" ", "");
                if (!s.Contains(searchQuery))
                {
                    filteredItems.RemoveAt(i);
                    i--;
                }
            }

            Item[] filteredItemsArray = filteredItems.ToArray();
            DisplayResults(filteredItemsArray);
        }

        private void Keyword_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox keywordBox = sender as TextBox;

            if (keywordBox.Text == "Your keyword")
            {
                keywordBox.Text = "";
            }
        }

        private void Keyword_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox keywordBox = sender as TextBox;

            if (string.IsNullOrWhiteSpace(keywordBox.Text))
            {
                keywordBox.Text = "Your keyword";
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
            for (int i = 0; i < SearchTerms.Children.Count; i++)
            {
                UIElement currentSearchTerm = SearchTerms.Children[i];
                if (currentSearchTerm.Visibility == Visibility.Collapsed)
                {
                    currentSearchTerm.Visibility = Visibility.Visible;
                    break;
                }
            }
        }

        private void RemoveFilterButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = SearchTerms.Children.Count - 1; i >= 0; i--)
            {
                UIElement currentSearchTerm = SearchTerms.Children[i];
                if (currentSearchTerm.Visibility == Visibility.Visible)
                {
                    currentSearchTerm.Visibility = Visibility.Collapsed;
                    break;
                }
            }
        }

        private void MyAccountButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new instance of account page
         //   AccountPage accountPage = new AccountPage();
            // Get the transform coordinates of the current window
           // accountPage.Left = this.Left;
            //accountPage.Top = this.Top;
            // Show the Account Page
           // accountPage.Show();

          //  this.Hide();
        }

        private void SearchButtonClick(object sender, RoutedEventArgs e)
        {
            // Reset the filters when searching by a new search term
            ResetFilterButton_Click(null, null);
            DisplaySearchQueryResults();
        }

        private void DisplaySearchQueryResults()
        {
            // Convert the search query to all lower case
            string searchQuery = SearchBox.Text.ToLower().Trim();
            searchQuery = searchQuery.Replace("-", "");
            searchQuery = searchQuery.Replace("--", "");
            searchQuery = searchQuery.Replace(":", "");
            searchQuery = searchQuery.Replace(" ", "");
            //MessageBox.Show($"Search query: {searchQuery}");

            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                return;
            }

            // This will store the results from the database that contain the search query in the TITLE
            List<Item> results = new List<Item>();
            foreach (Item item in Database.items)
            {
                string itemTitle = item.title.ToLower().Trim();
                itemTitle = itemTitle.Replace("-", "");
                itemTitle = itemTitle.Replace("--", "");
                itemTitle = itemTitle.Replace(":", "");
                itemTitle = itemTitle.Replace(" ", "");
                if (itemTitle.Contains(searchQuery))
                {
                    results.Add(item);
                }
            }

            // DEBUG MESSAGE (REMOVE LATER)
            string resultCount = results.Count.ToString();
            string resultMessage = $"Total results: {resultCount}";
            MessageBox.Show(resultMessage);

            // Sort items based on 'Sort By Drop Down'
            ComboBoxItem selectedItem = SortBy.SelectedItem as ComboBoxItem;

            if (selectedItem.Content.ToString() == "Title")
            {
                results.Sort((r1, r2) => string.Compare(r1.title, r2.title));
            }

            else if (selectedItem.Content.ToString() == "Author")
            {
                results.Sort((r1, r2) => string.Compare(r1.author.ElementAt(0), r2.author.ElementAt(0)));
            }

            else if (selectedItem.Content.ToString() == "Newest First")
            {
                results.Sort((r1, r2) => string.Compare(r2.yearOfPublication, r1.yearOfPublication));
            }

            else if (selectedItem.Content.ToString() == "Oldest First")
            {
                results.Sort((r1, r2) => string.Compare(r1.yearOfPublication, r2.yearOfPublication));
            }

            // Sort by newest by default
            else
            {
                results.Sort((r1, r2) => string.Compare(r2.yearOfPublication, r1.yearOfPublication));
            }

            // Convert result list to an array in order to display them
            Item[] new_results = results.ToArray();

            // Also copy this to the global variable list (used for item detail page)
            itemsCopy = new_results.ToList();

            // Display these results
            DisplayResults(new_results);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

        private void SortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisplaySearchQueryResults();
        }

        public void getBasicSearchQuery()
        {

        }
    }
}
