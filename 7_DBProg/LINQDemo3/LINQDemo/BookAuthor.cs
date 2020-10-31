/*********************************************************************
 * A LINQ Tutorial: WPF Data Binding with LINQ to SQL
 * By: Abby Fichtner, http://www.TheHackerChickBlog.com
 * Article URL: http://www.codeproject.com/KB/linq/linqtutorial3.aspx
 * Licensed under The Code Project Open License (CPOL)
 *********************************************************************/

using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace LINQDemo
{
#pragma warning disable 0169        // disable never used warnings for fields that are being used by LINQ

    [Table( Name = "BookAuthors" )]
    internal class BookAuthor
    {
        [Column( IsPrimaryKey = true, Name = "Author" )] private int authorId;
        private EntityRef<Author> _author = new EntityRef<Author>( );
        [Association( Name = "FK_BookAuthors_Authors", IsForeignKey = true, Storage = "_author", ThisKey = "authorId" )]
        public Author Author {
            get { return _author.Entity; }
            set {
                Author priorAuthor = _author.Entity;
                Author newAuthor = value;

                if( newAuthor != priorAuthor ) {
                    _author.Entity = null;
                    if( priorAuthor != null )
                        priorAuthor.BookAuthors.Remove( this );

                    _author.Entity = newAuthor;
                    newAuthor.BookAuthors.Add( this );
                }
            }
        }

        [Column( IsPrimaryKey = true, Name = "Book" )] private int bookId;
        private EntityRef<Book> _book = new EntityRef<Book>( );
        [Association( Name = "FK_BookAuthors_Books", IsForeignKey = true, Storage = "_book", ThisKey = "bookId" )]
        public Book Book {
            get { return _book.Entity; }
            set {
                Book priorBook = _book.Entity;
                Book newBook = value;

                if( newBook != priorBook ) {
                    _book.Entity = null;
                    if( priorBook != null )
                        priorBook.BookAuthors.Remove( this );

                    _book.Entity = newBook;
                    newBook.BookAuthors.Add( this );
                }
            }
        }

        public void Remove( ) {
            BookCatalog.RemoveRecord( this );

            Author priorAuthor = Author;
            priorAuthor.BookAuthors.Remove( this );

            Book priorBook = Book;
            priorBook.BookAuthors.Remove( this );
        }
    }
}
