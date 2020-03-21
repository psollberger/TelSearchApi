namespace TelSearchApi
{
  using System;
  using System.Xml.Linq;

  public class TelSearchError
  {
    /// <summary>
    ///   Error code
    /// </summary>
    /// <remarks>/feed/tel:errorCode</remarks>
    public int Code { get; }

    /// <summary>
    ///   Reason phrase
    /// </summary>
    /// <remarks>/feed/tel:errorReason</remarks>
    public string Reason { get; }

    /// <summary>
    ///   Description of the error
    /// </summary>
    /// <remarks>/feed/tel:errorMessage</remarks>
    public string Message { get; }

    public TelSearchError(string responseContentString)
    {
      var doc = XDocument.Parse(responseContentString);
      XNamespace ns = "http://www.w3.org/2005/Atom";
      XNamespace nsTel = "http://tel.search.ch/api/spec/result/1.0/";
      var feed = doc.Element(ns + "feed");
      if (feed == null) throw new ArgumentNullException(nameof(feed));
      Code = int.Parse(feed.Element(nsTel + "errorCode")?.Value ?? "0");
      Reason = feed.Element(nsTel + "errorReason")?.Value;
      Message = feed.Element(nsTel + "errorMessage")?.Value;
    }
  }
}
