namespace TelSearchApi
{
  using System.Xml.Linq;

  public class TelSearchCorrection
  {
    public string SearchTerms { get; internal set; }
    public int TotalResults { get; internal set; }

    public static TelSearchCorrection CreateFromElement(XElement element)
    {
      return new TelSearchCorrection
      {
        SearchTerms = element.Attribute("searchTerms")?.Value,
        TotalResults = int.Parse(element.Attribute("totalResults")?.Value ?? "0")
      };
    }
  }
}
