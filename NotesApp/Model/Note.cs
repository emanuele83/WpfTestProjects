using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Model
{
    public class Note : INotifyPropertyChanged
    {
        private int id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private int notebookId;
        [Indexed]
        public int NotebookId
        {
            get { return notebookId; }
            set
            {
                notebookId = value;
                OnPropertyChanged("NotebookId");
            }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        private DateTime createdAt;

        public DateTime CreatedAt
        {
            get { return createdAt; }
            set
            {
                createdAt = value;
                OnPropertyChanged("CreatedAt");
            }
        }

        private DateTime updatedAt;

        public DateTime UpdatedAt
        {
            get { return updatedAt; }
            set
            {
                updatedAt = value;
                OnPropertyChanged("UpdatedAt");
            }
        }

        private string fileLocation;

        public string FileLocation
        {
            get { return fileLocation; }
            set
            {
                fileLocation = value;
                OnPropertyChanged("FileLocation");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
