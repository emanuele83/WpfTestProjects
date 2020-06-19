using Microsoft.WindowsAzure.MobileServices;
using NotesApp.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NotesApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string UserId = string.Empty;
        public static MobileServiceClient MobileServiceClient = new MobileServiceClient("https://emsaevernotecloneapp.azurewebsites.net");

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //if (App.UserId == 0)
            //{
            //    LoginView loginView = new LoginView();
            //    loginView.ShowDialog();
            //}
        }
    }
}
