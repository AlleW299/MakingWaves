using MakingWavesCodeTest.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingWavesCodeTest.Services
{
    public interface IDataPageService
    {
        Task<List<DataPage>> GetAllDataPages();
    }
}
