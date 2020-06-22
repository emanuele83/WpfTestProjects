using RssReader.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RssReader
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DependencyInjector.Register<IRssHelper, RssHelper>();
            // the main window contains a property with the [Dependency] attribute which requires a IRssHelper type
            MainWindow = DependencyInjector.Retrieve<MainWindow>();
            MainWindow.Show();
        }
    }
}
