using NotesApp.Model;
using NotesApp.ViewModel.Command;
using NotesApp.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;

namespace NotesApp.ViewModel
{
    public class NoteViewModel : INotifyPropertyChanged
    {
        private bool isEditing;

        public bool IsEditing
        {
            get { return isEditing; }
            set
            {
                isEditing = value;
                OnPropertyChanged("IsEditing");
            }
        }

        public ObservableCollection<Notebook> Notebooks { get; set; }

        private Notebook selectedNotebook;

        public Notebook SelectedNotebook
        {
            get { return selectedNotebook; }
            set
            {
                selectedNotebook = value;
                ReadNotes();
            }
        }

        public ObservableCollection<Note> Notes { get; set; }

        private Note selectedNote;

        public Note SelectedNote
        {
            get { return selectedNote; }
            set
            {
                selectedNote = value;
                //OnPropertyChanged(nameof(selectedNote));
                if (selectedNote != null)
                {
                    NoteChanged(this, new NoteChangedEventArgs(selectedNote.Id));
                    // load doc
                }
            }
        }

        //private TextRange document;

        //public TextRange Document
        //{
        //    get
        //    {
        //        return document;
        //    }
        //    set
        //    {
        //        document = value;
        //    }
        //}


        public NewNotebookCommand NewNotebookCommand { get; set; }
        public NewNoteCommand NewNoteCommand { get; set; }
        public StartEditCommand StartEditCommand { get; set; }
        public StopEditCommand StopEditCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<NoteChangedEventArgs> NoteChanged;

        public NoteViewModel()
        {
            IsEditing = false;

            NewNotebookCommand = new NewNotebookCommand(this);
            NewNoteCommand = new NewNoteCommand(this);
            StartEditCommand = new StartEditCommand(this);
            StopEditCommand = new StopEditCommand(this);

            Notebooks = new ObservableCollection<Notebook>();
            Notes = new ObservableCollection<Note>();

            ReadNotebooks();
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void CreateNotbook()
        {
            Notebook newNotebook = new Notebook()
            {
                Name = "New notebook",
                UserId = App.UserId
            };
            DatabaseHelper.Insert(newNotebook);

            ReadNotebooks();
        }

        public void CreateNote(int notebookId)
        {
            Note newNote = new Note()
            {
                NotebookId = notebookId,
                Title = "New Note",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            DatabaseHelper.Insert(newNote);

            ReadNotes();
        }

        public void ReadNotebooks()
        {
            Notebooks.Clear();
            using(SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
            {
                conn.CreateTable<Notebook>();
                conn.Table<Notebook>().Where(n => n.UserId == App.UserId).ToList().ForEach(n => Notebooks.Add(n));
            }
        }
        public void ReadNotes()
        {
            Notes.Clear();
            if (SelectedNotebook != null)
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
                {
                    conn.CreateTable<Note>();
                    conn.Table<Note>().Where(n => n.NotebookId == SelectedNotebook.Id).ToList().ForEach(n => Notes.Add(n));
                }
            }
        }

        public void StartEditing()
        {
            IsEditing = true;
        }

        public void StopEditing(Notebook notebook)
        {
            if(notebook != null)
            {
                DatabaseHelper.Update(notebook);
                ReadNotebooks();
            }
            IsEditing = false;
        }

        public void UpdateNote()
        {
            if (SelectedNote != null)
                DatabaseHelper.Update(SelectedNote);
        }
    }

    public class NoteChangedEventArgs : EventArgs
    {
        public NoteChangedEventArgs(int noteId)
        {
            NoteId = noteId;
        }

        public int NoteId { get; set; }
    }
}
