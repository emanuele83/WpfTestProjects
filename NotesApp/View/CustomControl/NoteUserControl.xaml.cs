using NotesApp.Model;
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

namespace NotesApp.View.CustomControl
{
    /// <summary>
    /// Interaction logic for NoteUserControl.xaml
    /// </summary>
    public partial class NoteUserControl : UserControl
    {
        public Note Note
        {
            get { return (Note)GetValue(NoteProperty); }
            set { SetValue(NoteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Note.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NoteProperty =
            DependencyProperty.Register("Note", typeof(Note), typeof(NoteUserControl), new PropertyMetadata(null, SetValue));

        private static void SetValue(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NoteUserControl uc = d as NoteUserControl;
            if (uc != null)
            {
                uc.TitleTextBlock.Text = (e.NewValue as Note).Title;
                uc.DateTextBlock.Text = (e.NewValue as Note).UpdatedAt.ToShortDateString();
                uc.ContentTextBlock.Text = (e.NewValue as Note).Title;
            }
        }
        public NoteUserControl()
        {
            InitializeComponent();
        }
    }
}
