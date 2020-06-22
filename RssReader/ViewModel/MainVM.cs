using RssReader.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.ViewModel
{
    public class MainVM
    {
        public IRssHelper RssHelper { get; set; }
        public ObservableCollection<Item> Items { get; set; }

        public MainVM(IRssHelper rssHelper)
        {
            RssHelper = rssHelper;

            ReadRss();
        }

        private void ReadRss()
        {
            Items.Clear();
            RssHelper.GetPosts().ForEach(p => Items.Add(p));
        }
    }
}
