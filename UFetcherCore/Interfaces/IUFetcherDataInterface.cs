using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFetcherCore.Models;

namespace UFetcherCore.Interfaces
{
    public interface IUFetcherDataInterface
    {
        IEnumerable<UrlContentModel> Get();

        UrlContentModel Get(Guid id);

        void Set(UrlContentModel item);

        void Update(UrlContentModel item);
    }
}
