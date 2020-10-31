/*********************************************************************
 * A LINQ Tutorial: WPF Data Binding with LINQ to SQL
 * By: Abby Fichtner, http://www.TheHackerChickBlog.com
 * Article URL: http://www.codeproject.com/KB/linq/linqtutorial3.aspx
 * Licensed under The Code Project Open License (CPOL)
 *********************************************************************/

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using LINQDemo.View;

namespace LINQDemo
{
#pragma warning disable 0169        // disable never used warnings for fields that are being used by LINQ

    [Table( Name = "Authors" )]
    public class Author : IBookCollection, INotifyPropertyChanged
    {
        [Column( IsPrimaryKey = true, IsDbGenerated = true )]
        public int Id { get; set; }

        private string _name;
        [Column] public string Name {
            get { return _name; }
            set {
                _name = value;
                OnPropertyChanged( "Name" );
            }
        }

        private EntitySet<BookAuthor> _bookAuthors = new EntitySet<BookAuthor>( );
        [Association( Name = "FK_BookAuthors_Authors", Storage = "_bookAuthors", OtherKey = "authorId", ThisKey = "Id" )]
        internal ICollection<BookAuthor> BookAuthors {
            get { return _bookAuthors; }
            set { _bookAuthors.Assign( value ); }
        }

        public ICollection<Book> Books {
            get {
                var books = new ObservableCollection<Book>( from ba in BookAuthors select ba.Book );
                books.CollectionChanged += BookCollectionChanged;
                return books;
            }
        }

        private void BookCollectionChanged( object sender, NotifyCollectionChangedEventArgs e ) {
            if( NotifyCollectionChangedAction.Add == e.Action ) {
                foreach( Book addedBook in e.NewItems )
                    OnBookAdded( addedBook );
            }

            if( NotifyCollectionChangedAction.Remove == e.Action ) {
                foreach( Book removedBook in e.OldItems )
                    OnBookRemoved( removedBook );
            }

            // Call OnPropertyChanged() after updating Books
            OnPropertyChanged( "Books" );
        }

        private void OnBookAdded( Book addedBook ) {
            BookAuthor ba = new BookAuthor( ) { Author = this, Book = addedBook };
        }

        private void OnBookRemoved( Book removedBook ) {
            BookAuthor baRecord = BookAuthors.SingleOrDefault( ba => ba.Author == this && ba.Book == removedBook );
            if( baRecord != null ) {
                baRecord.Remove( );
            }
        }

        public bool CanDelete( ) {
            // don't allow delete if there are books by this author
            return Books.Count == 0;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged( string name ) {
            if( PropertyChanged != null ) {
                PropertyChanged( this, new PropertyChangedEventArgs( name ) );
            }
        }
    }
}