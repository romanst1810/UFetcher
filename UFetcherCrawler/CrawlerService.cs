using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Net.Http;
using System.IO;
using UFetcherCore.Interfaces;

namespace UFetcherCrawler
{
    public class CrawlerService : IUFetcherCrawlerServiceInterface
    {
        public string Get(string htmlUrl)
        {
            using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
            {
                string source = client.DownloadString(htmlUrl);
                return source;
            }
        }
    }
}