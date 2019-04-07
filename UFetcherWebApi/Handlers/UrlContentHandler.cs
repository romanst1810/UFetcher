using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UFetcherCore.Models;

namespace UFetcherWebApi.Handlers
{
    public class UrlContentHandler
    {
        public static UrlContentModel PrepareNewItemContentModel(string htmlUrl, string webHookUrl)
        {
            UrlContentModel item = new UrlContentModel();
            item.Id = Guid.NewGuid();
            item.HtmlUrl = htmlUrl;
            item.WebhookUrl = webHookUrl;
            item.ResultHtml = string.Empty;
            item.CreateDate = DateTime.UtcNow;
            item.UrlContentStatus = UrlContentStatus.Pending;
            return item;
        }
    }
}