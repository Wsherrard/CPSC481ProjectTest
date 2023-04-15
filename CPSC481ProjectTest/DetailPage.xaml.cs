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
    /// Interaction logic for DetailPage.xaml
    /// </summary>
    public partial class DetailPage : Page
    {
 
            Item[] resultsList;
            int currentIndex;
            bool isHeld;
            bool isSaved;

            public DetailPage(Item[] items, int index, bool zoomedMap)
            {
                InitializeComponent();

                this.resultsList = items;
                currentIndex = index;

                DisplayResults(items, index, zoomedMap);
            }

            public DetailPage()
            {
                InitializeComponent();

                this.resultsList = Database.items;
                currentIndex = 0;

                DisplayResults(Database.items, 0, false);
            }

            private void DisplayResults(Item[] items, int index, bool isZoomed)
            {
                Item item = items[index];

                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                string imagePath = "..\\..\\" + item.imagePath;
                bitmapImage.UriSource = new Uri(imagePath, UriKind.Relative);
                bitmapImage.EndInit();
                coverImage.Source = bitmapImage;

                coverTitle.Text = item.title;
                coverAuthor.Text = item.author[0];
                detailsAuthor.Text = item.author[0];
                for (int i = 1; i < item.author.Count; i++)
                {
                    coverAuthor.Text += ":" + item.author[i];
                    detailsAuthor.Text += ";" + item.author[i];
                }
                coverDate.Text = item.yearOfPublication;
                if (item.isPeerReviewed == true)
                {
                    coverPeerReviewed.Visibility = Visibility.Hidden;
                }
                else
                {
                    citedSearchButton.Visibility = Visibility.Visible;
                }
                coverTags.Text = "Tags not implemented in database";
                itemLocation.Content = "Location N/A";
                if (item.isAvailable == true)
                {
                    itemAvailability.Content = "Available";
                    itemAvailability.Foreground = Brushes.Green;
                }
                else
                {
                    itemAvailability.Content = "Not Available";
                    itemAvailability.Foreground = Brushes.Red;
                }
                itemSummary.Text = "Item Summary not implemented in database";
                detailsTitle.Text = item.title;

                detailsDate.Text = item.yearOfPublication;
                detailsPublisher.Text = "publisher not implemented in database";
                detailsItemType.Text = item.type.ToString();
                detailsSubject.Text = "subject not implemented in database";



                if (index == 0)
                {
                    prevItemButton.IsEnabled = false;
                    nextItemButton.IsEnabled = true;
                }
                else if (index == items.Length - 1)
                {
                    prevItemButton.IsEnabled = true;
                    nextItemButton.IsEnabled = false;
                }
                else
                {
                    prevItemButton.IsEnabled = true;
                    nextItemButton.IsEnabled = true;
                }

                itemCounter.Text = "Item " + (index + 1) + " of " + items.Length;

                if (isZoomed)
                {
                    Overlay.Visibility = Visibility.Visible;
                }
                else
                {
                    Overlay.Visibility = Visibility.Collapsed;
                }

                //check for held/saved items in account and update buttons and flags as necessary
                isHeld = false;
                isSaved = false;

            }

            private void SearchButtonClick(object sender, RoutedEventArgs e)
            {
                //not used on this page
            }

            private void MyAccountButton_Click(object sender, RoutedEventArgs e)
            {

            }

            private void LogOutButtonClick(object sender, RoutedEventArgs e)
            {

            }

            private void HomeButtonClick(object sender, RoutedEventArgs e)
            {

            }

            private void PrevItemButtonClick(object sender, RoutedEventArgs e)
            {
                currentIndex--;
                DisplayResults(resultsList, currentIndex, false);
            }

            private void ReturnToResultsButtonClick(object sender, RoutedEventArgs e)
            {
                //load results page with this.resultsList
            }

            private void NextItemButtonClick(object sender, RoutedEventArgs e)
            {
                currentIndex++;
                DisplayResults(resultsList, currentIndex, false);
            }

            private void PrintMapButtonClick(object sender, RoutedEventArgs e)
            {
                MessageBox.Show("Printing map...");
            }

            private void EmailMapButtonClick(object sender, RoutedEventArgs e)
            {
                MessageBox.Show("Map sent to your email address");
            }

            private void HoldItemButtonClick(Object sender, RoutedEventArgs e)
            {

                if (isHeld)
                {
                    MessageBox.Show("Hold removed on item");
                    isHeld = false;
                    holdItemButton.Content = "Hold Item";
                }
                else
                {
                    MessageBox.Show("Hold placed on item");
                    isHeld = true;
                    holdItemButton.Content = "Remove Hold";

                    //save item to account somehow
                    //probably a global list or something

                }
            }

            private void SaveItemButtonClick(object sender, RoutedEventArgs e)
            {

                if (isSaved)
                {
                    MessageBox.Show("Item removed from your account");
                    isSaved = false;
                    saveItemButton.Content = "Save for Later";
                }
                else
                {
                    MessageBox.Show("Item saved to your account");
                    isSaved = true;
                    saveItemButton.Content = "Remove Item";

                    //save item to account somehow
                    //probably a global list or something
                }

            }

            private void SearchCitedButtonClick(object sender, RoutedEventArgs e)
            {
                //display list of cited works- preexisting list in database?

            }

            private void SearchCitingButtonClick(object sender, RoutedEventArgs e)
            {
                //display list of citing works- preexisting list in database?
            }

            private void MapClick(object sender, RoutedEventArgs e)
            {
                Overlay.Visibility = Visibility.Visible;
            }

            private void closeZoomedMapButtonClick(Object sender, RoutedEventArgs e)
            {
                Overlay.Visibility = Visibility.Collapsed;
            }

        }
    }


