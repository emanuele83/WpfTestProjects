using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;
using WeatherApp.ViewModel.Commands;
using WeatherApp.ViewModel.Helpers;

namespace WeatherApp.ViewModel
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        private string query;

        public string Query
        {
            get { return query; }
            set
            {
                query = value;
                OnPropertyChanged("Query");
            }
        }

        public ObservableCollection<City> Cities { get; set; }

        private CurrentConditions currentConditions;

        public CurrentConditions CurrentConditions
        {
            get { return currentConditions; }
            set
            {
                currentConditions = value;
                OnPropertyChanged("CurrentConditions");
            }
        }

        private City selectedCity;

        public City SelectedCity
        {
            get { return selectedCity; }
            set
            {
                selectedCity = value;
                OnPropertyChanged("City");
                GetCurrentConditionsAsync();
            }
        }

        public SearchCityCommand SearchCityCommand { get; set; }

        public WeatherViewModel()
        {
            //// with this, the evaluation of inner code is used only in design mode, not at run time
            //// useful to evaluate binding and graphics
            //if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            //{
            //    SelectedCity = new City
            //    {
            //        Key = "123456",
            //        LocalizedName = "New York"
            //    };
            //    CurrentConditions = new CurrentConditions
            //    {
            //        WeatherText = "Sunny",
            //        Temperature = new Temperature
            //        {
            //            Metric = new Units
            //            {
            //                Value = "21"
            //            }
            //        }
            //    };
            //}

            SearchCityCommand = new SearchCityCommand(this);
            Cities = new ObservableCollection<City>();
        }

        public async void SearchCityAsync()
        {
            var cities = await AccuWeatherHelper.GetCitiesAsync(Query);

            Cities.Clear();
            cities.ForEach(c => Cities.Add(c));
        }

        private async void GetCurrentConditionsAsync()
        {
            Query = string.Empty;
            CurrentConditions = await AccuWeatherHelper.GetCurrentConditionsAsync(SelectedCity.Key);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
