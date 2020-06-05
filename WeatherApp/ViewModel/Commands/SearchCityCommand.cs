using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherApp.ViewModel.Commands
{
    public class SearchCityCommand : ICommand
    {
        WeatherViewModel VM;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public SearchCityCommand(WeatherViewModel vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            string queryString = parameter as string;
            return !string.IsNullOrWhiteSpace(queryString);
        }

        public void Execute(object parameter)
        {
            VM.SearchCityAsync();
        }
    }
}
