﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotesApp.ViewModel.Command
{
    public class NewNotebookCommand : ICommand
    {
        public NoteViewModel NoteViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public NewNotebookCommand(NoteViewModel viewModel)
        {
            NoteViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            NoteViewModel.CreateNotbook();
        }
    }
}
