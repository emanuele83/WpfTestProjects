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
    /// Interaction logic for NotebookUserControl.xaml
    /// </summary>
    public partial class NotebookUserControl : UserControl
    {
        public Notebook Notebook
        {
            get { return (Notebook)GetValue(NotebookProperty); }
            set { SetValue(NotebookProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Note.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NotebookProperty =
            DependencyProperty.Register("Notebook", typeof(Notebook), typeof(NotebookUserControl), new PropertyMetadata(null, SetValue));

        private static void SetValue(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NotebookUserControl uc = d as NotebookUserControl;
            if (uc != null)
            {
                uc.NameTextBlock.Text = (e.NewValue as Notebook).Name;
            }
        }

        public NotebookUserControl()
        {
            InitializeComponent();
        }
    }
}
