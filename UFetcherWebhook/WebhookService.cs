using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFetcherCore.Models;
using System.Net.Http;
using UFetcherCore.Interfaces;

namespace UFetcherWebhook
{
    public class WebhookService : UIFetcherWebhookUrlInterface
    {
        public async void SetResultToWebhookUrl(UrlContentModel model)
        {
            HttpClient client = new HttpClient();
            var values = new Dictionary<string, string>
            {
               { "content", model.ResultHtml }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync(model.WebhookUrl, content);

            var responseString = await response.Content.ReadAsStringAsync();
        }

    }
}
