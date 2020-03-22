namespace TelSearchApi.Tests
{
  public static class Program
  {
    public static void Main()
    {
      var query = new TelSearchQuery(new TelSearchClient(null))
      {
        Query = "Meier",
        IncludePrivates = false
      };
      var result = query.ExecuteAsync().GetAwaiter().GetResult();
    }
  }
}
