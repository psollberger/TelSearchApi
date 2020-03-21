namespace TelSearchApi
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Net;
  using System.Text;

  public class TelSearchWebDataSource
  {
    ///// <summary>
    /////   Führt das Query aus und setzt die QueryResult Eigenschaft
    ///// </summary>
    ///// <exception cref="NotSupportedException"></exception>
    ///// <exception cref="ArgumentException"></exception>
    ///// <exception cref="ArgumentNullException"></exception>
    ///// <exception cref="System.Security.SecurityException"></exception>
    ///// <exception cref="InvalidOperationException"></exception>
    ///// <exception cref="ProtocolViolationException"></exception>
    ///// <exception cref="WebException"></exception>
    //public void BeginExecute(TelSearchQuery query, Action<TelSearchResponse> callback)
    //{
    //  var client = new System.Net.Http.HttpClient();
    //  HttpWebRequest request = (HttpWebRequest) WebRequest.Create(BuildQueryUri(query));
    //  request.BeginGetResponse(FinishExecute, new object[] {request, query, callback});
    //}

    //private void FinishExecute(IAsyncResult result)
    //{
    //  HttpWebRequest request = ((object[]) result.AsyncState)[0] as HttpWebRequest;
    //  var query = ((object[]) result.AsyncState)[1] as TelSearchQuery;
    //  var callback = ((object[]) result.AsyncState)[2] as Action<TelSearchResponse>;

    //  if (request?.EndGetResponse(result) is HttpWebResponse response)
    //    using (var responsStream =
    //      new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException(), Encoding.UTF8))
    //    {
    //      using (TextReader textReader = responsStream)
    //      {
    //        callback?.Invoke(new TelSearchResponse(query, textReader.ReadToEnd()));
    //      }
    //    }
    //}

    //private static Uri BuildQueryUri(TelSearchQuery query)
    //{
    //  var argsList = new List<string>(10);

    //  if (!string.IsNullOrEmpty(query.What))
    //    argsList.Add($"was={Uri.EscapeDataString(query.What)}");

    //  if (!string.IsNullOrEmpty(query.Where))
    //    argsList.Add($"wo={Uri.EscapeDataString(query.Where)}");

    //  if (!string.IsNullOrEmpty(query.Query))
    //    argsList.Add($"q={Uri.EscapeDataString(query.Query)}");

    //  if (!query.IncludePrivates)
    //    argsList.Add("private=0");

    //  if (!query.IncludeOrganizations)
    //    argsList.Add("firma=0");

    //  if (query.StartIndex > 0)
    //    argsList.Add($"pos={query.StartIndex}");

    //  if (query.MaxResults > 0)
    //    argsList.Add($"maxnum={query.MaxResults}");

    //  if (!string.IsNullOrEmpty(TelSearchCore.ApiKey))
    //    argsList.Add($"key={TelSearchCore.ApiKey}");

    //  argsList.Add($"lang={query.Language.ToApiValue()}");

    //  if (query.CountOnly)
    //    argsList.Add("count_only=1");

    //  var ub = new UriBuilder("http://tel.search.ch/api/")
    //  {
    //    Query = string.Join("&", argsList)
    //  };
    //  return ub.Uri;
    //}
  }
}
