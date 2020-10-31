/*********************************************************************
 * A LINQ Tutorial: WPF Data Binding with LINQ to SQL
 * By: Abby Fichtner, http://www.TheHackerChickBlog.com
 * Article URL: http://www.codeproject.com/KB/linq/linqtutorial3.aspx
 * Licensed under The Code Project Open License (CPOL)
 *********************************************************************/

using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace LINQDemo
{
#pragma warning disable 0169, 0649        // disable never used/assigned warnings for fields that are being used by LINQ

    [Database]
    public class BookCatalog : DataContext
    {
        private static DataContext contextForRemovedRecords = null;

        public BookCatalog( ) : base( "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\BookCatalog.mdf;Integrated Security=True;User Instance=True" ) { }

        public Table<Author> Authors;
        public Table<Book> Books;
        public Table<Category> Categories;

        public static void RemoveRecord<T>( T recordToRemove ) where T : class {
            if( contextForRemovedRecords == null )
                contextForRemovedRecords = new BookCatalog( );

            Table<T> tableData = contextForRemovedRecords.GetTable<T>( );
            var deleteRecord = tableData.SingleOrDefault( record => record == recordToRemove );
            if( deleteRecord != null ) {
                tableData.DeleteOnSubmit( deleteRecord );
            }
        }

        public void CancelChanges( ) {
            if( contextForRemovedRecords != null ) {
                contextForRemovedRecords = null;
            }
        }

        public new void SubmitChanges( ) {
            if( contextForRemovedRecords != null ) {
                contextForRemovedRecords.SubmitChanges( );
            }
            base.SubmitChanges( );
        }
    }
}
