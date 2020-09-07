using System.Windows;
using PeopleViewer.Presentation;
using PersonDataReader.CSV;
using PersonDataReader.Decorators;
using PersonDataReader.Service;
using PersonDataReader.SQL;

namespace PeopleViewer
{
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ComposeObjectsForViewer();
        }

        private static void ComposeObjectsForViewer()
        {
           // var reader = new ServiceReader();  //First Data Reader
           //var reader = new CSVReader();    //Second Data Reader
           var sqlReader = new SQLReader();
          var serviceReader = new ServiceReader();

          var reader = new CachingReader(sqlReader);


            var mainviewModel = new PeopleViewModel(reader);
            Application.Current.MainWindow = new PeopleViewerWindow(mainviewModel);
            Application.Current.MainWindow.Title = "Saja Makes the Dependency Injection Happen in WPFPlusASPNetCore 2020";
            Application.Current.MainWindow.Show();
        }
    }
}
