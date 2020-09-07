/*********************************************************************
 * A LINQ Tutorial: WPF Data Binding with LINQ to SQL
 * By: Abby Fichtner, http://www.TheHackerChickBlog.com
 * Article URL: http://www.codeproject.com/KB/linq/linqtutorial3.aspx
 * Licensed under The Code Project Open License (CPOL)
 *********************************************************************/

using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Binding = System.Windows.Data.Binding;
using UserControl = System.Windows.Controls.UserControl;

namespace LINQDemo.View
{
    public partial class EditDetails : UserControl
    {
        private IBookCatalogItem dataItem;
        internal BookCatalog BookCatalog { get; private set; }
        private readonly CollectionViewSource categoryList;
        private Action<bool> completeAction = null;
        private UIElement parentDetails;

        public EditDetails( ) {
            InitializeComponent( );
            categoryList = (CollectionViewSource)FindResource( "categoryList" );
            Visibility = Visibility.Hidden;
        }

        public void ShowDialog( UIElement parent, ItemType type, IBookCatalogItem dataToEdit, Action<bool> completed ) {
            BookCatalog = new BookCatalog( );
            parentDetails = parent;
            completeAction = completed;

            SetupData( type, dataToEdit );
            parentDetails.IsEnabled = false;
            Visibility = Visibility.Visible;
        }

        private void SetupData( ItemType type, IBookCatalogItem dataToEdit ) {
            if( dataToEdit == null ) {
                dataItem = Catalog.AddNewItem(BookCatalog, type );
            } else {
                dataItem = Catalog.GetExistingItem(BookCatalog, dataToEdit );
            }

            BindDataToEditForm( );
            LoadAssociatedLists( );
        }

        private void BindDataToEditForm( ) {
            Binding binding = new Binding( );
            binding.Source = dataItem;
            binding.Mode = BindingMode.OneWay;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            EditForm.SetBinding( DataContextProperty, binding );
        }

        private void LoadAssociatedLists( ) {
            if( dataItem is Book ) {
                categoryList.Source = from cat in BookCatalog.Categories orderby cat.Name select cat;
            }

            if( dataItem is IBookCollection ) {
                AddBooksControl.Display( this, (IBookCollection)dataItem );
                AddAuthorsControl.Hide( );
            } else {
                AddAuthorsControl.Display( this, (Book)dataItem );
                AddBooksControl.Hide( );
            }
        }

        private void SaveDetails( object sender, RoutedEventArgs e ) {
            BookCatalog.SubmitChanges( );
            CloseDialog( true );
        }
        private void CancelUpdate( object sender, RoutedEventArgs e ){
            BookCatalog.CancelChanges( );
            CloseDialog( false );
        }

        private void CloseDialog( bool result ) {
            EditForm.ClearValue( DataContextProperty );
            BookCatalog = null;

            Visibility = Visibility.Hidden;
            parentDetails.IsEnabled = true;

            if( completeAction != null ) {
                completeAction.Invoke( result );
            }
        }

        private void DeleteAuthor( object sender, RoutedEventArgs args ) {
            AddAuthorsControl.RemoveAuthor( (sender as Button).CommandParameter as Author );
        }

        private void DeleteBook( object sender, RoutedEventArgs args ) {
            AddBooksControl.RemoveBook( ( sender as Button ).CommandParameter as Book );
        }
    }
}