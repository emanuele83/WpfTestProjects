using NotesApp.Model;
using NotesApp.ViewModel.Command;
using NotesApp.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace NotesApp.ViewModel
{
    public class NoteViewModel
    {
        public bool IsEditing { get; set; }

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
            set { selectedNote = value; }
        }
        
        public NewNotebookCommand NewNotebookCommand { get; set; }
        public NewNoteCommand NewNoteCommand { get; set; }

        public NoteViewModel()
        {
            IsEditing = false;

            NewNotebookCommand = new NewNotebookCommand(this);
            NewNoteCommand = new NewNoteCommand(this);

            Notebooks = new ObservableCollection<Notebook>();
            Notes = new ObservableCollection<Note>();

            ReadNotebooks();
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
    }
}
