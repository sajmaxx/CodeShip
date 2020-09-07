/*********************************************************************
 * LINQ Tutorial, Part 2: Adding/Updating/Deleting Data
 * By: Abby Fichtner, http://www.TheHackerChickBlog.com
 * Article URL: http://www.codeproject.com/KB/linq/linqtutorial2.aspx
 * Licensed under  Code Project Open License (CPOL)
 *********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQDemo
{
    // This class contains the sample queries from A LINQ Tutorial, Part 2 article on The Code Project
    // It writes the results of each query to the console
    // It is not invoked anywhere by default in the application - but you can just put a call to Run() from anywhere in the app to invoke it
    // 
    // TIP: If you get exceptions, try doing a Build Clean to refresh your database.  
    // These methods were constructed to give examples that work with the data that is included in the database for the tutorial
    class LinqTutorialSampleUpdates
    {
        // This method calls each of the sample query methods and write the results to the console
        public static void Run( ) {
            try { UpdateExistingData( ); } catch { } // if we've already updated the data, don't give an error when we run this again
            AddNewData( );
            DeletingData( );
            Mto1Update( );
            AddingDataIn1toMRelationship( );
            MovingDataIn1toMRelationship( );
            RemovingDataIn1toMRelationship( );
            AddingDataInMtoMRelationship( );
            RemovingDataInMtoMRelationship( );
            try { DeletingDataInMtoMRelationship( ); } catch { } // if we've already deleted the data, don't give an error when we run this again
        }

        public static void UpdateExistingData( ) {
            BookCatalog bookCatalog = new BookCatalog( );
            Category category = bookCatalog.Categories.Single( c => c.Name == "Programming Practices" );
            category.Name = "Technical Practices";
            bookCatalog.SubmitChanges( );

            Console.WriteLine( "*** UpdateExistingData: Category name updated to " + category.Name );
        }

        private static void AddNewData( ) {
            Category category = new Category( ) { Name = "Java" };
            BookCatalog bookCatalog = new BookCatalog( );
            bookCatalog.Categories.InsertOnSubmit( category );
            bookCatalog.SubmitChanges( );

            Console.WriteLine( "*** AddNewData: Added " + category.Name + " Category, got Id " + category.Id );
        }

        private static void DeletingData( ) {
            BookCatalog bookCatalog = new BookCatalog( );
            Category category = bookCatalog.Categories.Single( c => c.Name == "Java" );
            bookCatalog.Categories.DeleteOnSubmit( category );
            bookCatalog.SubmitChanges( );

            Console.WriteLine( "*** DeletingData: Removed " + category.Name + "Category" );
        }

        private static void Mto1Update( ) {
            BookCatalog bookCatalog = new BookCatalog( );
            Category csharpCategory = bookCatalog.Categories.Single( cat => cat.Name == "C#" );

            var books = bookCatalog.Books.Where( b => b.Title.Contains( "Pro LINQ: Language Integrated Query in C#" ) );
            foreach( var book in books ) {
                book.Category = csharpCategory;
            }
            bookCatalog.SubmitChanges( );

            Console.WriteLine( "*** Mto1Update: " + csharpCategory.Name + " Category now holds the books:" );
            foreach( var book in csharpCategory.Books ) {
                Console.WriteLine( " ---- " + book.Title );
            }
        }

        private static void AddingDataIn1toMRelationship( ) {
            IEnumerable<Book> books = new List<Book>( ) {
                    new Book( ) {Title = "Essential Windows Presentation Foundation", Price = 44.99m},
                    new Book( ) {Title = "WPF In Action", Price = 40.99m} };

            BookCatalog bookCatalog = new BookCatalog( );
            bookCatalog.Books.InsertAllOnSubmit( books );
            bookCatalog.SubmitChanges( );

            Category category = new Category( ) { Name = "WPF" };
            foreach( var wpfBook in books ) {
                category.Books.Add( wpfBook );
            }
            bookCatalog.Categories.InsertOnSubmit( category );
            try { bookCatalog.SubmitChanges( ); } catch { } // if we've already added this category, don't give an error when we run this method again

            Console.WriteLine( " *** AddingDataIn1toMRelationship: Added books to " + category.Name + ":" );
            foreach( var book in books ) {
                Console.WriteLine( " ---- " + book.Title + " is now in category: " + book.Category.Name );
            }
        }

        private static void MovingDataIn1toMRelationship( ) {
            BookCatalog bookCatalog = new BookCatalog( );
            var books = bookCatalog.Books.Where( b => b.Title.Contains( "Pro LINQ: Language Integrated Query in C#" ) );

            Category linqCategory = bookCatalog.Categories.Single( cat => cat.Name == "LINQ" );
            foreach( var book in books ) {
                linqCategory.Books.Add( book );
            }
            bookCatalog.SubmitChanges( );

            Console.WriteLine( " *** MovingDataIn1toMRelationship: Moved books to " + linqCategory.Name + ":" );
            foreach( var book in books ) {
                Console.WriteLine( " ---- " + book.Title + " is now in category: " + book.Category.Name );
            }
        }

        private static void RemovingDataIn1toMRelationship( ) {
            BookCatalog bookCatalog = new BookCatalog( );
            Book book = bookCatalog.Books.Single( b => b.Title.Contains( "Programming Ruby 1.9" ) );

            Category rubyCategory = bookCatalog.Categories.Single( cat => cat.Name == "Ruby" );
            rubyCategory.Books.Remove( book );
            bookCatalog.SubmitChanges( );

            Console.WriteLine( " *** ReovingDataIn1toMRelationship: Removed books from " + rubyCategory.Name + ":" );
            Console.WriteLine( " ---- " + book.Title + " is now in category: '" + book.Category + "'" );
        }

        private static void AddingDataInMtoMRelationship( ) {
            BookCatalog bookCatalog = new BookCatalog( );
            Author bobMartin = bookCatalog.Authors.Single( author => author.Name == "Bob Martin" );
            Book xpExplained = bookCatalog.Books.Single( book => book.Title.Contains( "Extreme Programming Explained" ) );

            xpExplained.Authors.Add( bobMartin );
            bookCatalog.SubmitChanges( );

            Console.WriteLine( " *** AddingDataInMtoMRelationship: Added " + bobMartin.Name + " to " + xpExplained.Title );
            Console.WriteLine( "     " + xpExplained.Title + " now has these authors:" );
            foreach( var author in xpExplained.Authors ) {
                Console.WriteLine( " ---- " + author.Name );
            }
            Console.WriteLine( "     " + bobMartin.Name + " now has these books:" );
            foreach( var book in bobMartin.Books ) {
                Console.WriteLine( " ---- " + book.Title );
            }
        }

        private static void RemovingDataInMtoMRelationship( ) {
            BookCatalog bookCatalog = new BookCatalog( );
            Author bobMartin = bookCatalog.Authors.Single( author => author.Name == "Bob Martin" );
            Book xpExplained = bookCatalog.Books.Single( book => book.Title.Contains( "Extreme Programming Explained" ) );

            bobMartin.Books.Remove( xpExplained );
            bookCatalog.SubmitChanges( );

            Console.WriteLine( " *** RemovingDataInMtoMRelationship: Removed " + xpExplained.Title + " from " + bobMartin.Name );
            Console.WriteLine( "     " + xpExplained.Title + " now has these authors:" );
            foreach( var author in xpExplained.Authors ) {
                Console.WriteLine( " ---- " + author.Name );
            }
            Console.WriteLine( "     " + bobMartin.Name + " now has these books:" );
            foreach( var book in bobMartin.Books ) {
                Console.WriteLine( " ---- " + book.Title );
            }
        }

        private static void DeletingDataInMtoMRelationship( ) {
            BookCatalog bookCatalog = new BookCatalog( );
            Book rubyBook = bookCatalog.Books.Single( book => book.Title.Contains( "Programming Ruby 1.9" ) );
            bookCatalog.Books.DeleteOnSubmit( rubyBook );
            bookCatalog.SubmitChanges( );

            Console.WriteLine( " *** DeletingDataInMtoMRelationship: Deleted " + rubyBook.Title );
        }
    }
}
