using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RssReader.Model
{
    public class CData
    {
        public string ActualString { get; set; }
    }

    [XmlRoot(ElementName = "item")]
    public class Item
    {
        [XmlElement(ElementName = "title")]
        public CData Title { get; set; }
        [XmlElement(ElementName = "description")]
        public CData Description { get; set; }
        [XmlElement(ElementName = "link")]
        public string Link { get; set; }
        private string pubDate;
        [XmlElement(ElementName = "pubdate")]
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
        // to specify a node with a specific ns (es. vm:viewModel)
        [XmlElement(ElementName = "creator", Namespace = "http://...")]
        public string Creator { get; set; }
    }

    [XmlRoot(ElementName = "channel")]
    public class Channel
    {
        [XmlElement(ElementName = "item")]
        public List<Item> Items { get; set; }

        [XmlElement(ElementName = "link")]
        public string Link { get; set; }
    }

    [XmlRoot(ElementName = "rss")]
    public class FinZenBlog
    {
        [XmlElement(ElementName = "channel")]
        public Channel Channel { get; set; }
    }
}
