/*********************************************************************
 * A LINQ Tutorial: WPF Data Binding with LINQ to SQL
 * By: Abby Fichtner, http://www.TheHackerChickBlog.com
 * Article URL: http://www.codeproject.com/KB/linq/linqtutorial3.aspx
 * Licensed under The Code Project Open License (CPOL)
 *********************************************************************/

using System;
using System.Linq;
using LINQDemo.View;

namespace LINQDemo
{
    // Helper methods to make it easy to to do transactions on any of the book catalog data types (Book, Author, Category)
    // Obviously these would be better split out into seperate classes for each type
    // But just trying to reduce the amount of code for people to go through for the example
    public static class Catalog
    {
        public static IBookCatalogItem AddNewItem( BookCatalog bookCatalog, ItemType type ) {
            IBookCatalogItem dataItem = null;

            if( type == ItemType.Author ) {
                dataItem = new Author( );
                bookCatalog.Authors.InsertOnSubmit( dataItem as Author );
            }

            if( type == ItemType.Book ) {
                dataItem = new Book( );
                bookCatalog.Books.InsertOnSubmit( dataItem as Book );
            }

            if( type == ItemType.Category ) {
                dataItem = new Category( );
                bookCatalog.Categories.InsertOnSubmit( dataItem as Category );
            }

            return dataItem;
        }

        public static void DeleteItem( IBookCatalogItem itemToDelete ) {
            BookCatalog bookCatalog = new BookCatalog( );
            DeleteItem( bookCatalog, itemToDelete );
            bookCatalog.SubmitChanges( );
        }

        public static void DeleteItem( BookCatalog bookCatalog, IBookCatalogItem itemToDelete ) {
            if( !itemToDelete.CanDelete( ) ) { return; }
            IBookCatalogItem dataItem = GetExistingItem( bookCatalog, itemToDelete );

            if( dataItem is Author ) bookCatalog.Authors.DeleteOnSubmit( dataItem as Author );
            if( dataItem is Book ) bookCatalog.Books.DeleteOnSubmit( dataItem as Book );
            if( dataItem is Category ) bookCatalog.Categories.DeleteOnSubmit( dataItem as Category );
        }

        public static IBookCatalogItem GetExistingItem( IBookCatalogItem dataItem ) {
            return GetExistingItem( new BookCatalog( ), dataItem );
        }

        public static IBookCatalogItem GetExistingItem( BookCatalog bookCatalog, IBookCatalogItem dataItem ) {
            if( dataItem is Author ) return bookCatalog.Authors.Single( author => author == dataItem as Author );
            if( dataItem is Book ) return bookCatalog.Books.Single( book => book == dataItem as Book );
            if( dataItem is Category ) return bookCatalog.Categories.Single( category => category == dataItem as Category );

            throw new Exception( "Unknown data type" );
        }
    }
}
