namespace TelSearchApi
{
  using System;
  using System.Collections.Generic;

  /// <summary>
  ///   Proxy für die freie API von tel.search.ch
  /// </summary>
  /// <example>https://tel.search.ch/api/help</example>
  public class TelSearchQuery
  {
    /// <summary>
    ///   General search term. Searches in name, category or phone number
    /// </summary>
    public string What { get; set; }

    /// <summary>
    ///   Geographic restriction of the search.
    ///   This could be a street, city, zip code or canton abbreviation.
    /// </summary>
    public string Where { get; set; }

    /// <summary>
    ///   Single term search. The terms are looked up in <see cref="What" /> and <see cref="Where" />.
    /// </summary>
    public string Query { get; set; }

    /// <summary>
    ///   Gets or sets if private persons should be included in the results.
    /// </summary>
    /// <remarks>true if private persons should be included. false if not. Default is true</remarks>
    public bool IncludePrivates { get; set; } = true;

    /// <summary>
    ///   Gets or sets if organizations should be included in the results.
    /// </summary>
    /// ///
    /// <remarks>true if organizations should be included. false if not. Default is true</remarks>
    public bool IncludeOrganizations { get; set; } = true;

    /// <summary>
    ///   Position of the first entry in the query. Used if a query has more than <see cref="MaxResults" /> matches.
    /// </summary>
    public int StartIndex { get; set; }

    /// <summary>
    ///   Gets or sets the maximum count of result items
    /// </summary>
    public int MaxResults { get; set; }

    /// <summary>
    ///   Gets or sets the api language.
    ///   Translatable information like categories will be returned in this language.
    /// </summary>
    /// <remarks>The API documentation defines the following languages: de, fr, it, en</remarks>
    public string Language { get; set; }

    /// <summary>
    ///   Gets or sets if only the result items count should be retrieved from the API
    /// </summary>
    public bool CountOnly { get; set; }

    public TelSearchQuery GetMemberwiseClone()
    {
      return (TelSearchQuery)MemberwiseClone();
    }

    public IDictionary<string, string> AsDictionary()
    {
      var argsList = new Dictionary<string, string>(10);

      if (!string.IsNullOrEmpty(What))
        argsList.Add("was", What);

      if (!string.IsNullOrEmpty(Where))
        argsList.Add("wo", Where);

      if (!string.IsNullOrEmpty(Query))
        argsList.Add("q", Query);

      if (!IncludePrivates)
        argsList.Add("privat", "0");

      if (!IncludeOrganizations)
        argsList.Add("firma", "0");

      if (StartIndex > 0)
        argsList.Add("pos", StartIndex.ToString());

      if (MaxResults > 0)
        argsList.Add("maxnum", MaxResults.ToString());

      if (!string.IsNullOrEmpty(TelSearchCore.ApiKey))
        argsList.Add("key", TelSearchCore.ApiKey);

      if (!string.IsNullOrEmpty(Language))
        argsList.Add("lang", Language);

      if (CountOnly)
        argsList.Add("count_only", "1");

      return argsList;
    }

    public Uri AsUri()
    {
      return new UriBuilder(TelSearchCore.BaseUri)
      {
        Query = AsDictionary().AsUriQuery()
      }.Uri;
    }
  }
}
