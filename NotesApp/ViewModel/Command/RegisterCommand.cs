using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotesApp.ViewModel.Command
{
    public class RegisterCommand : ICommand
    {
        public LoginViewModel LoginViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public RegisterCommand(LoginViewModel viewModel)
        {
            LoginViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // TODO
        }
    }
}
