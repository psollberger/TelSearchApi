namespace TelSearchApi
{
  using System;
  using System.Net.Http;
  using System.Threading.Tasks;

  public class TelSearchClient : ITelSearchClient
  {
    public string ApiKey { get; }

    public TelSearchClient(string apiKey)
    {
      ApiKey = apiKey;
    }

    /// <summary>
    ///   Executes the query and returns the api response
    /// </summary>
    public async Task<TelSearchQueryResponse> ExecuteQueryAsync(TelSearchQuery query)
    {
      if (query == null) throw new ArgumentNullException(nameof(query));
      using (var client = new HttpClient())
      {
        var response = await client.GetAsync(query.GetRequestUri());

        if (response.IsSuccessStatusCode)
          return new TelSearchQueryResponse(new TelSearchQueryResult(query,
            await response.Content.ReadAsStringAsync()));

        return new TelSearchQueryResponse(new TelSearchError(await response.Content.ReadAsStringAsync()));
      }
    }
  }
}
