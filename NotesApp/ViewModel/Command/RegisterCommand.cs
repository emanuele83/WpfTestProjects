﻿using NotesApp.Model;
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

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RegisterCommand(LoginViewModel viewModel)
        {
            LoginViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            Users user = parameter as Users;
            if (user != null)
            {
                if (string.IsNullOrEmpty(user.Name))
                    return false;
                if (string.IsNullOrEmpty(user.LastName))
                    return false;
                if (string.IsNullOrEmpty(user.Email))
                    return false;
                if (string.IsNullOrEmpty(user.Password))
                    return false;
                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            LoginViewModel.RegisterAsync();
        }
    }
}
