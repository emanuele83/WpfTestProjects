using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ContactApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static readonly string DatabaseName = "Contacts.db";
        static readonly string FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static readonly string DatabasePath = System.IO.Path.Combine(FolderPath, DatabaseName);
    }
}
