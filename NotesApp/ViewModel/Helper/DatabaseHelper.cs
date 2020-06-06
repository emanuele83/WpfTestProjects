using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.ViewModel.Helper
{
    public class DatabaseHelper
    {
        private static readonly string dbFile = Path.Combine(Environment.CurrentDirectory, "notesDb.db3");

        public static bool Insert<T>(T item)
        {
            using(SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(dbFile))
            {
                conn.CreateTable<T>();
                return conn.Insert(item) > 0;
            }
        }
        public static bool Update<T>(T item)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(dbFile))
            {
                conn.CreateTable<T>();
                return conn.Update(item) > 0;
            }
        }
        public static bool Delete<T>(T item)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(dbFile))
            {
                conn.CreateTable<T>();
                return conn.Delete(item) > 0;
            }
        }
    }
}
