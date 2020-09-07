/*********************************************************************
 * A LINQ Tutorial: WPF Data Binding with LINQ to SQL
 * By: Abby Fichtner, http://www.TheHackerChickBlog.com
 * Article URL: http://www.codeproject.com/KB/linq/linqtutorial3.aspx
 * Licensed under The Code Project Open License (CPOL)
 *********************************************************************/

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace LINQDemo.View
{
    public partial class BookCatalogBrowser : Window
    {
        private ItemType currentView;
        private string statusMessage = null;
        private IBookCollection viewingBooksForAttribute = null;

        public BookCatalogBrowser( ) {
            InitializeComponent( );
            DisplayAllBooks( );
        }

        private void DisplayAllAuthors( object sender, RoutedEventArgs e ) {
            DisplayAllAuthors( );
        }
        private void DisplayAllAuthors( ) {
            currentView = ItemType.Author;
            DisplayList( from author in new BookCatalog( ).Authors orderby author.Name select author );
            AuthorButton.IsEnabled = false;
        }

        private void DisplayAllBooks( object sender, RoutedEventArgs e ) {
            DisplayAllBooks( );
        }
        private void DisplayAllBooks( ) {
            DisplayBooks( from book in new BookCatalog( ).Books orderby book.Title select book );
            BookButton.IsEnabled = false;
        }
        private void DisplayBooks( IEnumerable<Book> books ) {
            currentView = ItemType.Book;
            DisplayList( from book in books orderby book.Title select book );
        }

        private void DisplayAllCategories( object sender, RoutedEventArgs e ) {
            DisplayAllCategories( );
        }
        private void DisplayAllCategories( ) {
            currentView = ItemType.Category;
            DisplayList( from category in new BookCatalog( ).Categories orderby category.Name select category );
            CategoryButton.IsEnabled = false;
        }

        private void DisplayList( IEnumerable dataToList ) {
            ResetDisplay( );
            Listing.DataContext = dataToList;
        }

        private void LoadBooksForAttribute( object sender, RoutedEventArgs e ) {
            if( sender == null || !( sender is Hyperlink ) ) { return; }
            IBookCollection bookHolder = ( ( sender as Hyperlink ).CommandParameter ) as IBookCollection;
            if( bookHolder == null ) { return; }

            bool alreadyDisplaying = isAlreadyDisplaying( bookHolder );
            if( alreadyDisplaying ) {
                System.Media.SystemSounds.Exclamation.Play( );
            }

            statusMessage = ( alreadyDisplaying ? "Already displaying" : "Displaying" ) + " books for " + bookHolder.Name;
            DisplayBooks( bookHolder.Books );
            viewingBooksForAttribute = bookHolder;
            e.Handled = true;
        }

        private bool isAlreadyDisplaying( IBookCollection bookHolder ) {
            if( viewingBooksForAttribute == null ) { return false; }
            return bookHolder == viewingBooksForAttribute;
        }

        private void LoadIndividualBook( object sender, RoutedEventArgs e ) {
            if( sender == null || !( sender is Hyperlink ) ) { return; }
            Book book = ( ( sender as Hyperlink ).CommandParameter ) as Book;
            if( book == null ) { return; }

            statusMessage = "Displaying book details";
            DisplayBooks( new List<Book>( ) { book } );
            e.Handled = true;
        }

        private void ResetDisplay( ) {
            viewingBooksForAttribute = null;
            AuthorButton.IsEnabled = true;
            BookButton.IsEnabled = true;
            CategoryButton.IsEnabled = true;

            if( statusMessage == null ) {
                if( currentView == ItemType.Author ) { statusMessage = "Displaying Authors"; }
                if( currentView == ItemType.Book ) { statusMessage = "Displaying Books"; }
                if( currentView == ItemType.Category ) { statusMessage = "Displaying Categories"; }
            }

            StatusText.Content = statusMessage;
            statusMessage = null;
        }

        public static RoutedCommand DeleteDataCommand = new RoutedCommand( );
        private void CanDeleteData( object sender, CanExecuteRoutedEventArgs args ) {
            var data = args.Parameter as IBookCatalogItem;
            if( data == null ) { return; }

            args.CanExecute = data.CanDelete( );
            args.ContinueRouting = false;
            args.Handled = true;
        }


        private void AddData( object sender, RoutedEventArgs e ) {
            EditDetailsDialog.ShowDialog( ModalDialogParent, currentView, null, OnUpdate );
        }

        private void DeleteData( object sender, ExecutedRoutedEventArgs args ) {
            var data = args.Parameter as IBookCatalogItem;
            if( data == null ) { return; }

            Catalog.DeleteItem( data );
            OnUpdate( true );
        }

        private void EditData( object sender, RoutedEventArgs args ) {
            var data = (sender as Button).CommandParameter as IBookCatalogItem;
            if( data == null ) { return; }

            EditDetailsDialog.ShowDialog( ModalDialogParent, currentView, data, OnUpdate );
        }

        private void OnUpdate( bool commitUpdate ) {
            if( !commitUpdate ) {
                statusMessage += "Update canceled";
            }

            switch( currentView ) {
                case ItemType.Author:
                    DisplayAllAuthors( );
                    break;

                case ItemType.Category:
                    DisplayAllCategories( );
                    break;

                case ItemType.Book:
                default:
                    if( viewingBooksForAttribute != null ) {
                        // refresh this item from the datacontext
                        viewingBooksForAttribute = Catalog.GetExistingItem( viewingBooksForAttribute ) as IBookCollection;
                    }

                    if( viewingBooksForAttribute != null ) {
                        DisplayBooks( viewingBooksForAttribute.Books );
                    } else {
                        DisplayAllBooks( );
                    }
                    break;
            }
        }
    }
}