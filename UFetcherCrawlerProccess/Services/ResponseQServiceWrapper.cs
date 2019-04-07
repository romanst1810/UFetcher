using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using UFetcherCore.Interfaces;
using UFetcherCore.Models;
using UFetcherQService;

namespace UFetcherCrawlerProccess.Services
{
    public class ResponseQServiceWrapper
    {
        IUFetcherQServiceInterface Service { get; set; }
        public ResponseQServiceWrapper()
        {
            Service = new QService();
        }

        public void Send(UrlContentModel model)
        {
            Service.Send(model);
        }

        public string Recieve(UrlContentModel model)
        {
            return Service.Recieve(model);
        }
    }
}