using System;

namespace UFetcherCore.Models
{
    public class UrlContentModel
    {
        public Guid Id { get; set; }
        public string HtmlUrl { get; set; }
        public string WebhookUrl { get; set; }
        public string ResultHtml { get; set; }
        public DateTime? CreateDate { get; set; }
        public UrlContentStatus UrlContentStatus { get; set; }
        public string QPath { get; set; }
        public string QMessage { get; set; }

        public UrlContentModel()
        {
            UrlContentStatus = UrlContentStatus.Pending;
        }
    }
    public enum UrlContentStatus
    {
        Pending,
        Start,
        InProcess,
        Exception,
        Success
    }

}
