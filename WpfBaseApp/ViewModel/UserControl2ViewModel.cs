using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfBaseApp.Command;
using WpfBaseApp.Common;
using WpfBaseApp.Interface;

namespace WpfBaseApp.ViewModel
{
    public class UserControl2ViewModel : BaseViewModel, IPageViewModel
    {
        public string UserControlName { get; set; } = "User control 2";

        private ICommand _goTo1;

        public ICommand GoTo1
        {
            get
            {
                return _goTo1 ?? (_goTo1 = new RelayCommand(x =>
                {
                    Mediator.Notify("GoTo1Screen", "");
                }));
            }
        }
    }
}
