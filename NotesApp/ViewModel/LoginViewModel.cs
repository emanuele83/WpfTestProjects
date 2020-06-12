using NotesApp.Model;
using NotesApp.ViewModel.Command;
using NotesApp.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.ViewModel
{
    public class LoginViewModel
    {
        public Users User { get; set; } = new Users();

        public RegisterCommand RegisterCommand { get; set; }
        public LoginCommand LoginCommand { get; set; }

        public event EventHandler HasLoggedIn;

        public LoginViewModel()
        {
            RegisterCommand = new RegisterCommand(this);
            LoginCommand = new LoginCommand(this);
        }

        public void CleanUserData()
        {
            User.Email = string.Empty;
            User.Password = string.Empty;
            User.Name = string.Empty;
            User.LastName = string.Empty;
        }

        public void Login()
        {
            using(SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
            {
                conn.CreateTable<Users>();
                var user = conn.Table<Users>().Where(u => u.Email == User.Email).FirstOrDefault();
                if(user != null && user.Password == User.Password)
                {
                    App.UserId = user.Id;
                    HasLoggedIn?.Invoke(this, new EventArgs());
                }
            }
        }

        public void Register()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
            {
                conn.CreateTable<Users>();
                try
                {
                    var res = DatabaseHelper.Insert(User);
                    if (res)
                    {
                        App.UserId = User.Id;
                        HasLoggedIn?.Invoke(this, new EventArgs());
                    }
                }catch(Exception e)
                {
                    // manage, for example, registering same email...
                    // add password recovery...
                    App.UserId = 0;
                }
            }
        }
    }
}
