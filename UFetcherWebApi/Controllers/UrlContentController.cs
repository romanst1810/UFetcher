using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UFetcherCore.Interfaces;
using UFetcherCore.Models;
using UFetcherQService;
using UFetcherWebApi.Handlers;

namespace UFetcherWebApi.Controllers
{
    public class UrlContentController : ApiController
    {
        public HttpResponseMessage GetUrlContent(UrlContentRequestModel request)
        {
            if(string.IsNullOrEmpty(request.HtmlUrl) && string.IsNullOrEmpty(request.WebhookUrl))
            {
                var message = string.Format("request values can't be null or empty : WebhookHtml={0} , HtmlUrl={1}", request.WebhookUrl ,request.HtmlUrl);
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }

            UrlContentModel item = UrlContentHandler.PrepareNewItemContentModel(request.HtmlUrl, request.WebhookUrl);
            // save new item
            Services.DataServiceWrapper ds = new Services.DataServiceWrapper();
            ds.Set(item);
            // Send message to MSMQ
            Services.RequestQServiceWrapper rs = new Services.RequestQServiceWrapper();
            item.QPath = @".\Private$\RequestQ";
            item.QMessage = item.Id + "," + item.HtmlUrl;
            rs.Send(item);

            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }
    }
}
