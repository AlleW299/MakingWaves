using System.Web.Mvc;
using MakingWavesCodeTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MakingWavesCodeTest.Entitiy;
using System.Net.Http;
using System.Net;

namespace MakingWavesCodeTest.Controller
{
    public class DataPageController : IDataPageController
    {
		static HttpClient client = new HttpClient();

        public async Task<HttpResponseMessage> GetDataPage(int pageNr)
        {
			try
			{
				var result = await client.GetAsync(string.Format("https://reqres.in/api/example?per_page=2&page={0}", pageNr));

				// Check that response was successful or throw exception
				result.EnsureSuccessStatusCode();

				return result;
			}
			catch (Exception ex)
			{
				// Return a NotFound status code, noi matter why it failed to find the data.
				return new HttpResponseMessage(HttpStatusCode.NotFound);
			}
        }
    }
}
