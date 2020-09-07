/*********************************************************************
 * A LINQ Tutorial: WPF Data Binding with LINQ to SQL
 * By: Abby Fichtner, http://www.TheHackerChickBlog.com
 * Article URL: http://www.codeproject.com/KB/linq/linqtutorial3.aspx
 * Licensed under The Code Project Open License (CPOL)
 *********************************************************************/

using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace LINQDemo.View
{
    public partial class AddBooks : UserControl
    {
        private readonly CollectionViewSource availableBooks;
        private IBookCollection bookCollection;
        private EditDetails parentForm;

        public AddBooks( ) {
            InitializeComponent( );
            availableBooks = (CollectionViewSource)FindResource( "availableBooks" );
        }

        public void Display( EditDetails parentForm, IBookCollection bookCollection ) {
            this.parentForm = parentForm;
            this.bookCollection = bookCollection;
            availableBooks.Source = GetAvailableBooks( );
            Visibility = Visibility.Visible;
        }

        public void Hide( ) {
            Visibility = Visibility.Collapsed;
            availableBooks.ClearValue( CollectionViewSource.SourceProperty );
        }

        private ObservableCollection<Book> GetAvailableBooks( ) {
            var availableBooks = new ObservableCollection<Book>( );
            foreach( var book in ( from bk in parentForm.BookCatalog.Books orderby bk.Title select bk ) ) {
                if( !bookCollection.Books.Contains( book ) ) {
                    availableBooks.Add( book );
                }
            }
            return availableBooks;
        }

        private void AddBook( object sender, RoutedEventArgs args ) {
            Book book = ( sender as Button ).CommandParameter as Book;
            if( book != null ) {
                bookCollection.Books.Add( book );
                ( (ObservableCollection<Book>)availableBooks.Source ).Remove( book );
            }
        }

        public void RemoveBook( Book book ) {
            if( book != null ) {
                bookCollection.Books.Remove( book );
                if( !(bookCollection is Author )){
                    ( (ObservableCollection<Book>)availableBooks.Source ).Add( book );
                }
                // If we're editing an Author, don't re-add the Book to available books
                // because if you delete & then re-add a M:M join relationship within the same 
                // "transaction" you'll get a DuplicateKeyException
            }
        }
    }
}