using NotesApp.ViewModel;
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
using System.Windows.Shapes;

namespace NotesApp.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        LoginViewModel vm;

        public LoginView()
        {
            InitializeComponent();

            vm = new LoginViewModel();
            loginGrid.DataContext = vm;
            vm.HasLoggedIn += Vm_HasLoggedIn;
        }

        private void Vm_HasLoggedIn(object sender, EventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            loginStack.Visibility = Visibility.Collapsed;
            registerStack.Visibility = Visibility.Visible;
            vm.CleanUserData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            loginStack.Visibility = Visibility.Visible;
            registerStack.Visibility = Visibility.Collapsed;
            vm.CleanUserData();
        }
    }
}
