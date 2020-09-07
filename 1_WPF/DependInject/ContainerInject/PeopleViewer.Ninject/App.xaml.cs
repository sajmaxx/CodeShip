using System.ComponentModel;
using System.Windows;
using Ninject;
using PeopleViewer.Common;
using PersonDataReader.CSV;
using PersonDataReader.Service;
using PersonDataReader.SQL;

namespace PeopleViewer.Ninject
{
    public partial class App : Application
    {
        IKernel Container = new StandardKernel();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Application.Current.MainWindow.Title = "With Dependency Injection - Ninject";
            Application.Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        { 
            //Container.Bind<IPersonReader>().To<ServiceReader>();
            //Container.Bind<IPersonReader>().To<CSVReader>();
            Container.Bind<IPersonReader>().To<SQLReader>();
        }

        private void ComposeObjects()
        {
            Application.Current.MainWindow = Container.Get<PeopleViewerWindow> ();
            
        }
    }
}
