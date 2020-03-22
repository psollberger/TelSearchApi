namespace TelSearchApi
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;

  public static class XDocumentExtensions
  {
    public static string GetString(this XContainer container, XName name)
    {
      return container.Element(name)?.Value;
    }

    public static int GetInteger(this XContainer container, XName name)
    {
      var strValue = container.Element(name)?.Value;
      if (string.IsNullOrEmpty(strValue)) return 0;
      return int.TryParse(strValue, out var tmp) ? tmp : 0;
    }

    public static DateTime GetDateTime(this XContainer container, XName name)
    {
      var strValue = container.Element(name)?.Value;
      return !string.IsNullOrEmpty(strValue) && DateTime.TryParse(strValue, out var tmp) ? tmp : DateTime.MinValue;
    }

    public static string GetStringByType(this IEnumerable<XElement> elements, string typeName)
    {
      return elements.FirstOrDefault(l => l.Attribute("type")?.Value.Equals(typeName) ?? false)
        ?.Value;
    }

    public static string GetLinkHref(this IEnumerable<XElement> elements, string relValue)
    {
      return elements.FirstOrDefault(l => l.Attribute("rel")?.Value.Equals(relValue) ?? false)
        ?.Attribute("href")?.Value;
    }

    public static string GetLinkHref(this IEnumerable<XElement> elements, string relValue, string typeValue)
    {
      return elements.FirstOrDefault(l =>
        {
          var relAttribute = l.Attribute("rel");
          var typeAttribute = l.Attribute("type");
          if (relAttribute == null || typeAttribute == null) return false;
          return relAttribute.Value.Equals(relValue) && typeAttribute.Value.Equals(typeValue);
        })
        ?.Attribute("href")?.Value;
    }
  }
}
