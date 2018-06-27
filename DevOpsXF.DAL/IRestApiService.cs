using System.Threading.Tasks;
using Refit;

namespace DevOpsXF.DAL
{
	public interface IRestApiService
    {
	    [Get("/api/live")]
	    Task<RatesResultDto> GetLatestRates(string access_key, string currencies, int format);
	}
}
