namespace TelSearchApi
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;
  using System.Text;
  using System.Xml.Linq;

  public class TelSearchQueryResult
  {
    private readonly string _queryResult;

    public TelSearchQuery OriginalQuery { get; private set; }

    /// <summary>
    ///   Gets the count of total found entries with a maximum of 200
    /// </summary>
    /// <remarks>openSearch:totalResults</remarks>
    public int TotalResults { get; private set; }

    /// <summary>
    ///   Gets the real count of total found entries. This can be bigger than TotalResults but the API only allows to access
    ///   the first 200 results found
    /// </summary>
    public int TotalResultsReal { get; private set; }

    /// <summary>
    ///   Gets the 1-based position of the first entry in the resultset
    /// </summary>
    /// <remarks>openSearch:startIndex</remarks>
    public int StartIndex { get; private set; }

    /// <summary>
    ///   Gets the count of items on this page
    /// </summary>
    /// <remarks>openSearch:itemsPerPage</remarks>
    public int ItemsOnPage { get; private set; }

    /// <summary>
    ///   Gets the current page number
    /// </summary>
    public int CurrentPage
    {
      get
      {
        if (StartIndex == 1) return 1;
        var offset = StartIndex % OriginalQuery.MaxResults > 0 ? 1 : 0;
        return StartIndex / OriginalQuery.MaxResults + offset;
      }
    }

    /// <summary>
    ///   Gets the total count of pages
    /// </summary>
    public int TotalPages
    {
      get
      {
        var offset = (TotalResults & OriginalQuery.MaxResults) > 0 ? 1 : 0;
        return TotalResults / OriginalQuery.MaxResults + offset;
      }
    }

    /// <summary>
    ///   Gets if this is the last page
    /// </summary>
    public bool IsLastPage => CurrentPage >= TotalPages;

    /// <summary>
    ///   Werden mit dem aktuellen Suchbegriff keine Resultate gefunden, wird ein zusätzliches Query-Element mit einem
    ///   Korrekturvorschlag eingefügt.
    /// </summary>
    /// <example>&lt;openSearch:Query role="correction" searchTerms="Bäckerei" totalResults="5256" /&gt;</example>
    /// <remarks>openSearch:Query</remarks>
    public TelSearchCorrection Correction { get; private set; }

    /// <summary>
    ///   Einträge dieses Resultsets
    /// </summary>
    public IList<TelSearchEntry> Entries { get; private set; }

    /// <summary>
    ///   Die Fehlerinformation falls ein Fehler aufgetreten ist
    /// </summary>
    public TelSearchError Error { get; private set; }

    public string ResultBrowserLink { get; private set; }
    public string NextPageLink { get; private set; }

    public TelSearchQueryResult(TelSearchQuery originalQuery, string responseContentString)
    {
      InitVars();
      OriginalQuery = originalQuery;
      _queryResult = responseContentString;
      ParseResponse(responseContentString);
    }

    public string GetResultXml()
    {
      if (string.IsNullOrEmpty(_queryResult)) return string.Empty;
      return _queryResult;
    }

    public void BeginGetNextPage(Action<TelSearchQueryResult> callback)
    {
      if (IsLastPage)
      {
        callback(null);
        return;
      }

      var q = OriginalQuery.GetMemberwiseClone();
      q.StartIndex += OriginalQuery.MaxResults;
      if (q.StartIndex > 200) q.StartIndex = 200;
      //q.BeginExecute(callback);
    }

    public void BeginGetPreviousPage(Action<TelSearchQueryResult> callback)
    {
      if (CurrentPage == 1)
      {
        callback(null);
        return;
      }

      var q = OriginalQuery.GetMemberwiseClone();
      q.StartIndex -= OriginalQuery.MaxResults + Entries.Count;
      if (q.StartIndex > 200) q.StartIndex = 200;
      //q.BeginExecute(callback);
    }

    public void BeginGetPage(int page, Action<TelSearchQueryResult> callback)
    {
      if (page < 1 || page > TotalPages)
      {
        callback(null);
        return;
      }

      var q = OriginalQuery.GetMemberwiseClone();
      q.StartIndex = page * OriginalQuery.MaxResults - 1;
      if (q.StartIndex > 200) q.StartIndex = 200;
      //q.BeginExecute(callback);
    }

    private void InitVars()
    {
      OriginalQuery = null;
      TotalResults = 0;
      TotalResultsReal = 0;
      StartIndex = 0;
      ItemsOnPage = 0;
      //CurrentPage = 0;
      //TotalPages = 0;
      //IsLastPage = true;
      Correction = null;
      Entries = new List<TelSearchEntry>();
      Error = null;
    }

    private void ParseResponse(string responseContent)
    {
      using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseContent)))
      {
        ParseResponse(ms);
      }
    }

    private void ParseResponse(Stream responseStream)
    {
      try
      {
        var doc = XDocument.Load(responseStream);

        if (doc.Root != null)
        {
          //Anzahl totaler Resultate
          var totalResultsValue = doc.Root.Elements().FirstOrDefault(i => i.Name.LocalName == "totalResults")?.Value;
          if (!string.IsNullOrEmpty(totalResultsValue))
            if (int.TryParse(totalResultsValue, out var tmp))
            {
              TotalResultsReal = tmp;
              TotalResults = Math.Min(tmp, 200);
            }

          var startIndexValue = doc.Root.Elements().FirstOrDefault(i => i.Name.LocalName == "startIndex")?.Value;
          if (!string.IsNullOrEmpty(startIndexValue))
            if (int.TryParse(startIndexValue, out var tmp))
              StartIndex = tmp;

          var itemsPerPageValue = doc.Root.Elements().FirstOrDefault(i => i.Name.LocalName == "itemsPerPage")?.Value;
          if (!string.IsNullOrEmpty(itemsPerPageValue))
            if (int.TryParse(itemsPerPageValue, out var tmp))
              ItemsOnPage = tmp;

          var resultBrowserLinkValue = doc.Root.Elements().FirstOrDefault(i =>
            i.Name.LocalName == "link" && i.Attributes().FirstOrDefault(a => a.Name == "rel")?.Value == "alternate");
          if (resultBrowserLinkValue != null)
            ResultBrowserLink = resultBrowserLinkValue.Attributes().FirstOrDefault(a => a.Name == "href")?.Value;

          var nextPageLinkValue = doc.Root.Elements().FirstOrDefault(i =>
            i.Name.LocalName == "link" && i.Attributes().FirstOrDefault(a => a.Name == "rel")?.Value == "next");
          if (nextPageLinkValue != null)
            NextPageLink = nextPageLinkValue.Attributes().FirstOrDefault(a => a.Name == "href")?.Value;

          // Einträge parsen
          foreach (var item in doc.Root.Elements().Where(i => i.Name.LocalName == "entry"))
            Entries.Add(TelSearchEntry.CreateFromElement(item));
        }
      }
      catch
      {
        // ignore
      }
    }
  }
}
