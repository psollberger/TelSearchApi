using System.Threading.Tasks;

namespace TelSearchApi
{
  public interface ITelSearchClient
  {
    string ApiKey { get; }

    Task<TelSearchQueryResponse> ExecuteQueryAsync(TelSearchQuery query);
  }
}