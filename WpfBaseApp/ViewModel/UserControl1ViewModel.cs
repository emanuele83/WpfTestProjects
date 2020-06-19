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
    public class UserControl1ViewModel : BaseViewModel, IPageViewModel
    {
        public string UserControlName { get; set; } = "User control 1";

        private ICommand _goTo2;

        public ICommand GoTo2
        {
            get
            {
                return _goTo2 ?? (_goTo2 = new RelayCommand(x =>
                {
                    Mediator.Notify("GoTo2Screen", "");
                }));
            }
        }
    }
}
