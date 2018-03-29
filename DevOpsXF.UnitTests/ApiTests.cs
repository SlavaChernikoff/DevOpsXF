using System;
using System.Net.Http;
using DevOpsXF.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refit;

namespace DevOpsXF.UnitTests
{
    [TestClass]
    public class ApiTests {
	    const string ApiBaseAddress = "http://data.fixer.io";
	    const string AccessKey = "8754892b614a90b5cb1debdf6948e7dc";

	    IRestApiService _apiService;

		[TestInitialize]
	    public void SetUp() {
			var client = new HttpClient {
				BaseAddress = new Uri(ApiBaseAddress),
				Timeout = TimeSpan.FromMinutes(10),
			};
			_apiService = RestService.For<IRestApiService>(client);
		}

        [TestMethod]
        public void TestLatestRatesEurJpy()
        {
	        var ratesTask = _apiService.GetLatestRates(AccessKey, "EUR", "JPY");
	        ratesTask.Wait();
	        var result = ratesTask.Result;

			Assert.AreNotEqual(result, null);
			Assert.AreNotEqual(result.Rates, null);
			Assert.AreNotEqual(result.Rates.Count, 0);
        }
    }
}
