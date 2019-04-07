using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFetcherCore.Models;

namespace UFetcherCore.Interfaces
{
    public interface IUFetcherQServiceInterface
    {
        void Send(UrlContentModel model);

        string Recieve(UrlContentModel model);
    }
}
