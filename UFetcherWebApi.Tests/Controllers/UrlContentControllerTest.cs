using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UFetcherWebApi;
using UFetcherWebApi.Controllers;
using UFetcherCore;
using UFetcherCore.Models;

namespace UFetcherWebApi.Tests.Controllers
{
    [TestClass]
    public class UrlContentControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            UrlContentController controller = new UrlContentController();
            
            var req = new UrlContentRequestModel()
            {
                HtmlUrl = "https://translate.google.ru/",
                WebhookUrl = "https://translate.google.ru/"
            };
            // Act
            var result = controller.GetUrlContent(req);

            Assert.AreEqual(true, result.IsSuccessStatusCode);
        }
    }
}
