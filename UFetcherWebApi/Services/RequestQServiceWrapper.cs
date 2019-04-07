using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UFetcherCore.Interfaces;
using UFetcherCore.Models;
using UFetcherQService;

namespace UFetcherWebApi.Services
{
    public class RequestQServiceWrapper
    {
        IUFetcherQServiceInterface Service { get; set; }
        public RequestQServiceWrapper()
        {
            Service = new QService();
        }
        
        public void Send(UrlContentModel model)
        {
            Service.Send(model);
        }
    }
}