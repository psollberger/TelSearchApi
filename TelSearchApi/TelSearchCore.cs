namespace TelSearchApi
{
  using System;

  public static class TelSearchCore
  {
    public static readonly Uri BaseUri = new Uri("https://tel.search.ch/api/");
    public static readonly int QueryMaxPos = 200;
  }
}
