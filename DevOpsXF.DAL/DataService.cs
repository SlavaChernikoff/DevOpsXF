using System;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace DevOpsXF.DAL
{
    public class DataService
    {
		static readonly Lazy<DataService> LazyInstance = new Lazy<DataService>(()=>new DataService());
	    public static DataService Instance => LazyInstance.Value;

	    IRestApiService _apiService;
	    string _accessToken;

		DataService() {}

	    public void Init(string apiBaseAddress, string accessToken) {
		    _apiService = RestService.For<IRestApiService>(new HttpClient(new HttpLoggingHandler()) {
			    BaseAddress = new Uri(apiBaseAddress),
			    Timeout = TimeSpan.FromMinutes(10)
		    });
		    _accessToken = accessToken;
	    }

	    public async Task<double> GetResult(double originalValue, string fromCurrency, string toCurrency) {
		    try {
			    var res = await _apiService.GetLatestRates(_accessToken, fromCurrency, toCurrency).ConfigureAwait(false);
			    return res.Rates[toCurrency] * originalValue;
		    }
		    catch (Exception e) {
			    return 0;
		    }
	    }
	}
}
