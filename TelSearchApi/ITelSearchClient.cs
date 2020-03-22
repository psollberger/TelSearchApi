namespace TelSearchApi
{
  using System.Threading.Tasks;

  public interface ITelSearchClient
  {
    string ApiKey { get; }

    Task<TelSearchQueryResponse> ExecuteQueryAsync(TelSearchQuery query);
  }
}
