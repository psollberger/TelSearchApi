namespace TelSearchApi
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  public class TelSearchQueryResult
  {
    public TelSearchQuery Query { get; }

    public string QueryResultXml { get; }

    /// <summary>
    ///   Gets the count of total found entries
    /// </summary>
    /// <remarks>openSearch:totalResults</remarks>
    public int TotalResults { get; }

    /// <summary>
    ///   Gets the 1-based position of the first entry in the resultset
    /// </summary>
    /// <remarks>openSearch:startIndex</remarks>
    public int StartIndex { get; }

    /// <summary>
    ///   Gets the amount of maximum items per page
    /// </summary>
    /// <remarks>openSearch:itemsPerPage</remarks>
    public int ItemsPerPage { get; }

    /// <summary>
    ///   Gets the current page number
    /// </summary>
    public int CurrentPage => (StartIndex - 1) / ItemsPerPage + 1;

    /// <summary>
    ///   Gets the total count of pages
    /// </summary>
    public int TotalPages => (int) Math.Ceiling((double) TotalResults / ItemsPerPage);

    /// <summary>
    ///   Gets if this is the first page
    /// </summary>
    public bool IsFirstPage => CurrentPage == 1;

    /// <summary>
    ///   Gets if this is the last page
    /// </summary>
    public bool IsLastPage => CurrentPage >= TotalPages;

    /// <summary>
    ///   If there are no matching entries or the query was sent with <see cref="TelSearchQuery.CountOnly" />,
    ///   the api sends 0..n correction suggestions which are accessible here
    /// </summary>
    /// <example>&lt;openSearch:Query role="correction" searchTerms="Bäckerei" totalResults="5256" /&gt;</example>
    /// <remarks>openSearch:Query</remarks>
    public IReadOnlyList<TelSearchCorrection> Corrections { get; }

    /// <summary>
    ///   Resulting entries of the query
    /// </summary>
    public IReadOnlyList<TelSearchEntry> Entries { get; }

    public string ResultLink { get; }

    public string SelfLink { get; }

    public TelSearchQueryResult(TelSearchQuery query, string queryResultXml)
    {
      Query = query;
      QueryResultXml = queryResultXml;

      var doc = XDocument.Parse(QueryResultXml);

      XNamespace ns = "http://www.w3.org/2005/Atom";
      XNamespace nsOpenSearch = "http://a9.com/-/spec/opensearchrss/1.0/";

      var feed = doc.Element(ns + "feed");
      if (feed == null) throw new FeedNotFoundException();

      TotalResults = feed.GetInteger(nsOpenSearch + "totalResults");
      StartIndex = feed.GetInteger(nsOpenSearch + "startIndex");
      ItemsPerPage = feed.GetInteger(nsOpenSearch + "itemsPerPage");

      var links = feed.Elements(ns + "link").ToArray();
      ResultLink = links.GetLinkHref("alternate");
      SelfLink = links.GetLinkHref("self");

      var xCorrections = feed.Elements(nsOpenSearch + "Query")
        .Where(e => e.Attribute("role")?.Value.Equals("correction") ?? false).ToArray();
      if (xCorrections.Length > 0)
        Corrections = new List<TelSearchCorrection>(xCorrections.Select(TelSearchCorrection.CreateFromElement));

      var xEntries = feed.Elements(ns + "entry").ToArray();
      if (xEntries.Length > 0) Entries = new List<TelSearchEntry>(xEntries.Select(e => new TelSearchEntry(e)));
    }

    public TelSearchQuery GetPreviousPageQuery()
    {
      return IsFirstPage ? null : GetPageQuery(CurrentPage - 1);
    }

    public TelSearchQuery GetNextPageQuery()
    {
      return IsLastPage ? null : GetPageQuery(CurrentPage + 1);
    }

    public TelSearchQuery GetPageQuery(int page)
    {
      if (page < 1 || page > TotalPages) return null;
      var query = Query.GetMemberwiseClone();
      query.StartIndex = (page - 1) * ItemsPerPage + 1;
      return query;
    }
  }
}
