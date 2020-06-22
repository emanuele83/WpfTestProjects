using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RssReader.Model;

namespace RssReader.ViewModel
{
    public class FakeRssHelper : IRssHelper
    {
        public List<Item> GetPosts()
        {
            List<Item> posts = new List<Item>();

            posts.Add(new Item()
            {
                Title = new CData() { ActualString = "Fake" }
            });

            return posts;
        }
    }
}
