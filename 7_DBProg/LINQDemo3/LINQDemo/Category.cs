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
using LINQDemo.View;

namespace LINQDemo
{
#pragma warning disable 0169        // disable never used warnings for fields that are being used by LINQ

    [Table( Name = "BookCategories" )]
    public class Category : IBookCollection, INotifyPropertyChanged
    {
        [Column( IsPrimaryKey = true, IsDbGenerated = true )]
        public int Id { get; set; }

        private string _name;
        [Column]
        public string Name {
            get { return _name; }
            set {
                _name = value;
                OnPropertyChanged( "Name" );
            }
        }

        private EntitySet<Book> _books = new EntitySet<Book>( );
        [Association( Name = "FK_Books_BookCategories", Storage = "_books", OtherKey = "categoryId", ThisKey = "Id" )]
        public ICollection<Book> Books {
            get {
                var books = new ObservableCollection<Book>( _books );
                books.CollectionChanged += BookCollectionChanged;
                return books;
            }
            set {
                _books.Assign( value );
                OnPropertyChanged( "Books" );
            }
        }

        private void BookCollectionChanged( object sender, NotifyCollectionChangedEventArgs e ) {
            if( NotifyCollectionChangedAction.Add == e.Action ) {
                foreach( Book addedBook in e.NewItems ) {
                    OnBookAdded( addedBook );
                }
            }

            if( NotifyCollectionChangedAction.Remove == e.Action ) {
                foreach( Book removedBook in e.OldItems ) {
                    OnBookRemoved( removedBook );
                }
            }
            OnPropertyChanged( "Books" );
        }

        private void OnBookAdded( Book addedBook ) {
            _books.Add( addedBook );
            addedBook.Category = this;
        }

        private void OnBookRemoved( Book removedBook ) {
            _books.Remove( removedBook );
            removedBook.Category = null;
        }

        public bool CanDelete( ) {
            // don't allow delete if there are books in this category
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
