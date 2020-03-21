namespace TelSearchApi
{
  using System;
  using System.Collections.Generic;
  using System.Text;

  public static class DictionaryExtensions
  {
    public static string AsUriQuery(this IDictionary<string, string> dictionary)
    {
      if (dictionary.Count == 0) return null;
      var queryString = new StringBuilder();
      foreach (var arg in dictionary) queryString.Append(arg.Key + "=" + Uri.EscapeDataString(arg.Value) + "&");
      queryString.Remove(queryString.Length - 1, 1);
      return queryString.ToString();
    }
  }
}
