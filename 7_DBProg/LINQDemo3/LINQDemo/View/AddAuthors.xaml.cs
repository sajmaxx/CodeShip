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
    public partial class AddAuthors : UserControl
    {
        private readonly CollectionViewSource availableAuthors;
        private Book book;
        private EditDetails parentForm;

        public AddAuthors( ) {
            InitializeComponent( );
            availableAuthors = (CollectionViewSource)FindResource( "availableAuthors" );
        }

        public void Display( EditDetails parentForm, Book book ) {
            this.parentForm = parentForm;
            this.book = book;
            availableAuthors.Source = GetAvailableAuthors(  );
            Visibility = Visibility.Visible;
        }

        private ObservableCollection<Author> GetAvailableAuthors( ) {
            var availableAuthors = new ObservableCollection<Author>( );
            foreach( var author in ( from au in parentForm.BookCatalog.Authors orderby au.Name select au ) ) {
                if( !book.Authors.Contains( author ) ) {
                    availableAuthors.Add( author );
                }
            }
            return availableAuthors;
        }

        public void Hide( ){
            Visibility = Visibility.Collapsed;
            availableAuthors.ClearValue( CollectionViewSource.SourceProperty );
        }

        public void AddAuthor( object sender, RoutedEventArgs e ) {
            Author author = ( sender as Button ).CommandParameter as Author;
            if( author != null ) {
                book.Authors.Add( author );
                ( (ObservableCollection<Author>)availableAuthors.Source ).Remove( author );
            }
        }

        public void RemoveAuthor( Author author ) {
            if( author != null ) {
                book.Authors.Remove( author );
                // Don't re-add the Author to available authors
                // because if you delete & then re-add a M:M join relationship within the same 
                // "transaction" you'll get a DuplicateKeyException
            }
        }
    }
}