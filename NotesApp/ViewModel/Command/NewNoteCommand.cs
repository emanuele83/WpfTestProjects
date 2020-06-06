using NotesApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotesApp.ViewModel.Command
{
    public class NewNoteCommand : ICommand
    {
        public NoteViewModel NoteViewModel { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public NewNoteCommand(NoteViewModel viewModel)
        {
            NoteViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            Notebook notebook = parameter as Notebook;
            return notebook != null;
        }

        public void Execute(object parameter)
        {
            Notebook notebook = parameter as Notebook;
            NoteViewModel.CreateNote(notebook.Id);
        }
    }
}
