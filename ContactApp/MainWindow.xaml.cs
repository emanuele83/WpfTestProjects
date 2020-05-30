using ContactApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;
        public MainWindow()
        {
            InitializeComponent();

            contacts = new List<Contact>();

            ReadContacts();
        }

        private void NewContactButton_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContact = new NewContactWindow();
            newContact.ShowDialog();

            ReadContacts();
        }

        void ReadContacts()
        {
            using(SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Contact>();
                contacts = connection.Table<Contact>().OrderBy(c => c.Name).ToList();
            }
            contactsListView.ItemsSource = contacts;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox search = sender as TextBox;

            var filtered = contacts.Where(c => c.Name.ToLower().Contains(search.Text.ToLower())).ToList();

            contactsListView.ItemsSource = filtered;
        }

        private void ContactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact contact = contactsListView.SelectedItem as Contact;

            if (contact != null)
            {
                ContactDetails newContact = new ContactDetails(contact);
                newContact.ShowDialog();

                ReadContacts();
            }
        }
    }
}
