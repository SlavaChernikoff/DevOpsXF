using System.Threading.Tasks;
using Refit;

namespace DevOpsXF.DAL
{
	public interface IRestApiService
    {
	    [Get("/api/latest")]
	    Task<RatesResultDto> GetLatestRates([AliasAs("access_key")]string accessKey, [AliasAs("base")]string baseCurrency, [AliasAs("symbols")]string toCurrency);
	}
}
