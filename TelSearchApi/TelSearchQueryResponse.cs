namespace TelSearchApi
{
  public class TelSearchQueryResponse
  {
    public TelSearchError Error { get; }
    public TelSearchQueryResult Result { get; }

    public TelSearchQueryResponse(TelSearchQueryResult result)
    {
      Result = result;
    }

    public TelSearchQueryResponse(TelSearchError error)
    {
      Error = error;
    }
  }
}
