using MakingWavesCodeTest.Controller;
using MakingWavesCodeTest.Entitiy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingWavesCodeTest.Services
{
    public class DataPageService : IDataPageService
    {
        public async Task<List<DataPage>> GetAllDataPages()
        {
			var results = new List<DataPage>();

            var pageNr = 1;
            bool keepWorking = true;

            while (keepWorking)
            {
                using (var response = await new DataPageController().GetDataPage(pageNr))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var post = await response.Content.ReadAsStringAsync();
                        var responseFromJson = JsonConvert.DeserializeObject<DataPage>(post);
                        results.Add(responseFromJson);
                        if (pageNr == responseFromJson.Total_Pages)
                        {
                            keepWorking = false;
                        }
                        pageNr++;
                    } else
                    {
                        keepWorking = false;
                    }
                };
            }

            return results;
		}
    }
}
