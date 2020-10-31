/*********************************************************************
 * A LINQ Tutorial: WPF Data Binding with LINQ to SQL
 * By: Abby Fichtner, http://www.TheHackerChickBlog.com
 * Article URL: http://www.codeproject.com/KB/linq/linqtutorial3.aspx
 * Licensed under The Code Project Open License (CPOL)
 *********************************************************************/

using System.Collections.Generic;

namespace LINQDemo.View
{
    public interface IBookCollection : IBookCatalogItem
    {
        string Name { get; set; }
        ICollection<Book> Books { get; }
    }
}