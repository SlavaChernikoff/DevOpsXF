using System;
using System.Net.Http;
using DevOpsXF.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refit;

namespace DevOpsXF.UnitTests
{
    [TestClass]
    public class ApiTests {
	    const string ApiBaseAddress = "http://apilayer.net";
	    const string AccessKey = "1809397aeb646717dc0f4b44f820d81c";

	    IRestApiService _apiService;

		[TestInitialize]
	    public void SetUp() {
			var client = new HttpClient {
				BaseAddress = new Uri(ApiBaseAddress),
				Timeout = TimeSpan.FromMinutes(1),
			};
			_apiService = RestService.For<IRestApiService>(client);
		}

        [TestMethod]
        public void TestLatestRatesEurJpy()
        {
	        var ratesTask = _apiService.GetLatestRates(AccessKey, "EUR,JPY", 1);
	        ratesTask.Wait();
	        var result = ratesTask.Result;

			Assert.AreNotEqual(result, null);
			Assert.AreNotEqual(result.Quotes, null);
			Assert.AreNotEqual(result.Quotes.Count, 0);
        }
    }
}
