using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CuttingToolManager.Models;

namespace CuttingToolManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string DataBaseFolder =  Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string DatabaseName = "CuttingTools.db";
        public static string DatabasePath = System.IO.Path.Combine(DataBaseFolder,DatabaseName);

        public static  List<CuttingTool> toolList;

    }
}
