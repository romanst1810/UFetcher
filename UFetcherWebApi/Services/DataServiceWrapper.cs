using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UFetcherCore.Interfaces;
using UFetcherCore.Models;
using UFetcherDataAccess;

namespace UFetcherWebApi.Services
{
    public class DataServiceWrapper
    {
        IUFetcherDataInterface DBService { get; set; }
        public DataServiceWrapper()
        {
            DBService = new DataAccessService();
        }

        public IEnumerable<UrlContentModel> Get()
        {
            return DBService.Get();
        }

        public UrlContentModel Get(Guid id)
        {
            return DBService.Get(id);
        }

        public void Set(UrlContentModel item)
        {
            DBService.Set(item);
        }

        public void Update(UrlContentModel item)
        {
            DBService.Update(item);
        }
    }
}