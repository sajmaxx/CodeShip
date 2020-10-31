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

    [Table( Name = "Books" )]
    public class Book : IBookCatalogItem, INotifyPropertyChanged
    {

        [Column( IsPrimaryKey = true, IsDbGenerated = true )] internal int Id { get; set; }

        private string _title;
        [Column] public string Title {
            get { return _title; }
            set {
                _title = value;
                OnPropertyChanged( "Title" );
            }
        }

        private decimal _price;
        [Column] public decimal Price {
            get { return _price; }
            set {
                _price = value;
                OnPropertyChanged( "Price" );
            }
        }

        [Column( Name = "Category" )] private int? categoryId;
        private EntityRef<Category> _category = new EntityRef<Category>( );
        [Association( Name = "FK_Books_BookCategories", IsForeignKey = true, Storage = "_category", ThisKey = "categoryId" )]
        public Category Category {
            get { return _category.Entity; }
            set {
                Category priorCategory = _category.Entity;
                Category newCategory = value;

                if( newCategory != priorCategory ) {

                    // remove this book from our prior category's list of books
                    _category.Entity = null;
                    if( priorCategory != null ) {
                        priorCategory.Books.Remove( this );
                    }

                    // set category to the new value
                    _category.Entity = newCategory;
                    OnPropertyChanged( "Category" );

                    // add this book to the new category's list of books
                    if( newCategory != null ) {
                        newCategory.Books.Add( this );
                    }
                }
            }
        }

        private EntitySet<BookAuthor> _bookAuthors = new EntitySet<BookAuthor>( );
        [Association( Name = "FK_BookAuthors_Books", Storage = "_bookAuthors", OtherKey = "bookId", ThisKey = "Id" )]
        internal ICollection<BookAuthor> BookAuthors {
            get { return _bookAuthors; }
            set { _bookAuthors.Assign( value ); }
        }

        public ICollection<Author> Authors {
            get {
                var authors = new ObservableCollection<Author>( from ba in BookAuthors select ba.Author );
                authors.CollectionChanged += AuthorCollectionChanged;
                return authors;
            }
        }

        private void AuthorCollectionChanged( object sender, NotifyCollectionChangedEventArgs e ) {
            if( NotifyCollectionChangedAction.Add == e.Action ) {
                foreach( Author addedAuthor in e.NewItems )
                    OnAuthorAdded( addedAuthor );
            }

            if( NotifyCollectionChangedAction.Remove == e.Action ) {
                foreach( Author removedAuthor in e.OldItems )
                    OnAuthorRemoved( removedAuthor );
            }

            // Call OnPropertyChanged() after updating Authors
            OnPropertyChanged( "Authors" );
        }

        private void OnAuthorAdded( Author addedAuthor ) {
            BookAuthor ba = new BookAuthor( ) { Author = addedAuthor, Book = this };
        }

        private void OnAuthorRemoved( Author removedAuthor ) {
            BookAuthor baRecord = BookAuthors.SingleOrDefault( ba => ba.Book == this && ba.Author == removedAuthor );
            if( baRecord != null )
                baRecord.Remove( );
        }

        public bool CanDelete(){
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged( string name ) {
            if( PropertyChanged != null ) {
                PropertyChanged( this, new PropertyChangedEventArgs( name ) );
            }
        }
    }
}

