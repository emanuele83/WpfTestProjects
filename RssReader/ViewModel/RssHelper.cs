using RssReader.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RssReader.ViewModel
{

    public class RssHelper : IRssHelper
    {
        public static async Task<List<Item>> GetPostsAsync()
        {
            List<Item> posts = new List<Item>();

            XmlSerializer serializer = new XmlSerializer(typeof(FinZenBlog));
            using(HttpClient client = new HttpClient())
            {
                var feed = await client.GetAsync("https://www.finzen.mx/blog-feed.xml");
                FinZenBlog blog = (FinZenBlog)serializer.Deserialize(await feed.Content.ReadAsStreamAsync());

                posts = blog.Channel.Items;
            }

            return posts;
        }

        // method to copy web resource to local file
        public static async void DownloadToFileAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("uri to download");
                using (var fs = new FileStream("path to file", FileMode.CreateNew))
                {
                    await response.Content.CopyToAsync(fs);
                }
            }
        }

        public List<Item> GetPosts()
        {
            List<Item> posts = new List<Item>();

            posts.Add(new Item()
            {
                Title = new CData() { ActualString = "Real" }
            });

            return posts;
        }
    }
}
