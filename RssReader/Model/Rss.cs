using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.Model
{
    public class CData
    {
        public string ActualString { get; set; }
    }

    public class Item
    {
        public CData Title { get; set; }
        public CData Description { get; set; }
        public string Link { get; set; }
        private string pubDate;
        public string PubDate
        {
            get { return pubDate; }
            set
            {
                pubDate = value;
                PublishedDate = DateTime.ParseExact(pubDate, "ddd, dd MMM yyyy HH:mm:ss GMT", CultureInfo.InvariantCulture);
            }
        }

        public DateTime PublishedDate { get; set; }
        public string Creator { get; set; }
    }

    public class Channel
    {
        public List<Item> Items { get; set; }

        public string Link { get; set; }
    }

    public class FinZenBlog
    {
        public Channel Channel { get; set; }
    }
}
