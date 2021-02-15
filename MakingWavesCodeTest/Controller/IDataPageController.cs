using MakingWavesCodeTest.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MakingWavesCodeTest.Controller
{
    public interface IDataPageController
    {
        Task<HttpResponseMessage> GetDataPage(int pageNr);
    }
}
