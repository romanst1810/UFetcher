using System;
using System.Collections.Generic;
using System.Linq;
using UFetcherCore.Interfaces;
using UFetcherCore.Models;

namespace UFetcherDataAccess
{
    public class DataAccessService : IUFetcherDataInterface
    {
        public IEnumerable<UrlContentModel> Get()
        {
            using (UFetcherDBEntities entities = new UFetcherDBEntities())
            {
                List<UrlContentModel> resultItems = new List<UrlContentModel>();
                foreach (var item in entities.TB_UrlContent.ToList())
                {
                    UrlContentModel resultItem = ConvertFromDB(item);
                    resultItems.Add(resultItem);
                }
                return resultItems;
            }
        }

        public UrlContentModel Get(Guid id)
        {
            using (UFetcherDBEntities entities = new UFetcherDBEntities())
            {
                return ConvertFromDB(entities.TB_UrlContent.FirstOrDefault(x => x.Id == id));
            }
        }

        public void Set(UrlContentModel item)
        {
            using (UFetcherDBEntities entities = new UFetcherDBEntities())
            {
                TB_UrlContent entity = ConvertToDB(item);
                entity.CreateDate = DateTime.UtcNow;
                entities.TB_UrlContent.Add(entity);
                entities.SaveChanges();
            }
        }

        public void Update(UrlContentModel item)
        {
            using (UFetcherDBEntities entities = new UFetcherDBEntities())
            {
                TB_UrlContent entity = ConvertToDB(item, entities.TB_UrlContent.Where(x => x.Id == item.Id).FirstOrDefault());
                entities.TB_UrlContent.Add(entity);
                entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();
            }
        }

        #region Mappers

        private TB_UrlContent ConvertToDB(UrlContentModel item)
        {
            TB_UrlContent result = new TB_UrlContent();
            result.Id = item.Id;
            result.HtmlUrl = item.HtmlUrl;
            result.ResultHtml = item.ResultHtml;
            result.UrlContentStatus = item.UrlContentStatus.ToString();
            result.WebhookUrl = item.WebhookUrl;
            return result;
        }

        private TB_UrlContent ConvertToDB(UrlContentModel item, TB_UrlContent result)
        {
            result.Id = item.Id;
            result.HtmlUrl = item.HtmlUrl;
            result.ResultHtml = item.ResultHtml;
            result.UrlContentStatus = item.UrlContentStatus.ToString();
            result.WebhookUrl = item.WebhookUrl;
            return result;
        }
        private UrlContentModel ConvertFromDB(TB_UrlContent item)
        {
            UrlContentModel result = new UrlContentModel();
            result.Id = item.Id;
            result.HtmlUrl = item.HtmlUrl;
            result.ResultHtml = item.ResultHtml;
            result.UrlContentStatus = (UrlContentStatus)Enum.Parse(typeof(UrlContentStatus), item.UrlContentStatus); 
            result.WebhookUrl = item.WebhookUrl;
            return result;
        }
        #endregion
    }
}

