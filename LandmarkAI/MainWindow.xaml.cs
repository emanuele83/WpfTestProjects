using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LandmarkAI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image file (png, jpg)|*.png;*.jpg;*.jpeg|All files|*.*";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (dialog.ShowDialog() == true)
            {
                var fileName = dialog.FileName;
                selectedImage.Source = new BitmapImage(new Uri(fileName));

                MakePredictionAsync(fileName);
            }
        }

        private async void MakePredictionAsync(string fileName)
        {
            string azureUrl = "https://northeurope.api.cognitive.microsoft.com/customvision/v3.0/Prediction/f71133ab-4c38-4c19-8180-3119451cd77e/classify/iterations/Iteration1Landmarks/image";
            string predictionKey = "86126490be46450ebee447ffe219c034";
            string contentType = "application/octet-stream";
            var fileData = File.ReadAllBytes(fileName);


            using (HttpClient client = new HttpClient())
            {
                // for custom headers
                client.DefaultRequestHeaders.Add("Prediction-Key", predictionKey);
                using(var content = new ByteArrayContent(fileData))
                {
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
                    var response = await client.PostAsync(azureUrl, content);
                }
            }
        }
    }
}
