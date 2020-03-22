namespace TelSearchApi
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Xml.Linq;

  /// <summary>
  ///   <see href="https://tel.search.ch/api/help" />
  /// </summary>
  [DebuggerDisplay("{" + nameof(Title) + "}")]
  public class TelSearchEntry
  {
    /// <summary>
    ///   Unique identification according to RFC 4287
    /// </summary>
    /// <remarks>/feed/entry/id</remarks>
    public string Id { get; }

    /// <summary>
    ///   Publishing date
    /// </summary>
    /// <remarks>/feed/entry/published</remarks>
    public DateTime? Published { get; }

    /// <summary>
    ///   Date of last change
    /// </summary>
    /// <remarks>/feed/entry/updated</remarks>
    public DateTime? Updated { get; }

    /// <summary>
    ///   Title of the entry (Name of the person or organization)
    /// </summary>
    /// <remarks>/feed/entry/title</remarks>
    public string Title { get; }

    /// <summary>
    ///   Aggregation of the entry in plaintext
    /// </summary>
    /// <remarks>/feed/entry/content</remarks>
    public string Content { get; }

    /// <summary>
    ///   Author of the entry according to RFC 4287
    /// </summary>
    /// <remarks>/feed/entry/author/name</remarks>
    public string AuthorName { get; }

    /// <summary>
    ///   Link to the detail page of the entry on tel.search.ch
    /// </summary>
    /// <remarks>/feed/entry/link/@rel='alternate'</remarks>
    public string DetailsUrl { get; }

    /// <summary>
    ///   Link to the correction page of the entry on tel.search.ch
    /// </summary>
    /// <remarks>/feed/entry/link/@rel='edit'</remarks>
    public string EditUrl { get; }

    /// <summary>
    ///   Link to the VCard file for the entry
    /// </summary>
    /// <remarks>/feed/entry/link/@type='text/x-vcard'</remarks>
    public string VCardUrl { get; }

    /// <summary>
    ///   Position of the entry in the entire result set
    /// </summary>
    /// <remarks>/feed/entry/tel:pos</remarks>
    public int Position { get; }

    /// <summary>
    ///   Unique tel.search.ch identification
    /// </summary>
    /// <remarks>/feed/entry/tel:id</remarks>
    public string TelSearchId { get; }

    /// <summary>
    ///   Type of the entry: person or organization
    /// </summary>
    /// <remarks>/feed/entry/tel:type</remarks>
    public TelSearchEntryType Type { get; } = TelSearchEntryType.Unknown;

    /// <summary>
    ///   Organizationname
    /// </summary>
    /// <remarks>/feed/entry/tel:org</remarks>
    public string Organizationname { get; }

    /// <summary>
    ///   Lastname of the person or name of the organization
    /// </summary>
    /// <remarks>/feed/entry/tel:name</remarks>
    public string LastName { get; }

    /// <summary>
    ///   Firstname of the person
    /// </summary>
    /// <remarks>/feed/entry/tel:firstname</remarks>
    public string FirstName { get; }

    /// <summary>
    ///   Additional name of the person or organization
    /// </summary>
    /// <remarks>/feed/entry/tel:subname</remarks>
    public string AdditionalName { get; }

    /// <summary>
    ///   The maiden name of the person
    /// </summary>
    /// <remarks>/feed/entry/tel:maidenname</remarks>
    public string MaidenName { get; }

    /// <summary>
    ///   Profession of the person or an additional description of the organization
    /// </summary>
    /// <remarks>/feed/entry/tel:occupation</remarks>
    public string Occupation { get; }

    /// <summary>
    ///   Zero, one or more categories the entry belongs to
    /// </summary>
    /// <remarks>/feed/entry/tel:category</remarks>
    public IReadOnlyList<string> Categories { get; }

    /// <summary>
    ///   The name of the street
    /// </summary>
    /// <remarks>/feed/entry/tel:street</remarks>
    public string StreetName { get; }

    /// <summary>
    ///   The building number
    /// </summary>
    /// <remarks>/feed/entry/tel:streetno</remarks>
    public string StreetNumber { get; }

    /// <summary>
    ///   The post office box number
    /// </summary>
    /// <remarks>/feed/entry/tel:pobox</remarks>
    public string PostOfficeBox { get; }

    /// <summary>
    ///   The zip code
    /// </summary>
    /// <remarks>/feed/entry/tel:zip</remarks>
    public string PostalCode { get; }

    /// <summary>
    ///   The city name
    /// </summary>
    /// <remarks>/feed/entry/tel:city</remarks>
    public string City { get; }

    /// <summary>
    ///   The abbreviation of the canton (ZH,BE,AG,TG,SG,...)
    /// </summary>
    /// <remarks>/feed/entry/tel:canton</remarks>
    public string Canton { get; }

    /// <summary>
    ///   The abbreviation of the country
    /// </summary>
    public string Country { get; }

    /// <summary>
    ///   Defines if the person/organization does not wish to receive advertisement
    /// </summary>
    /// <remarks>/feed/entry/tel:nopromo</remarks>
    public bool NoPromotion { get; }

    /// <summary>
    ///   The phone number in international format
    /// </summary>
    /// <remarks>/feed/entry/tel:phone</remarks>
    public string Phone { get; }

    /// <summary>
    ///   The first provided fax number
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='fax'</remarks>
    public string Fax { get; }

    /// <summary>
    ///   The first provided cell phone number
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='mobile'</remarks>
    public string Mobile { get; }

    /// <summary>
    ///   The first provided email address
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='email'</remarks>
    public string EMail { get; }

    /// <summary>
    ///   The first provided website URL
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='website'</remarks>
    public string Website { get; }

    /// <summary>
    ///   The first provided Skype name
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='skype'</remarks>
    public string Skype { get; }

    /// <summary>
    ///   The first provided ICQ Instant-Messenger-Name
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='icq'</remarks>
    public string Icq { get; }

    /// <summary>
    ///   The first provided MSN Instant-Messenger-Name
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='msn'</remarks>
    public string Msn { get; }

    /// <summary>
    ///   The first provided AIM Instant-Messenger-Name
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='aim'</remarks>
    public string Aim { get; }

    /// <summary>
    ///   The first provided Yahoo Instant-Messenger-Name
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='yahoo'</remarks>
    public string Yahoo { get; }

    /// <summary>
    ///   All extra values
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='...'</remarks>
    public IReadOnlyDictionary<string, IReadOnlyList<string>> ExtraFields { get; }

    public TelSearchEntry(XContainer entry)
    {
      XNamespace ns = "http://www.w3.org/2005/Atom";
      XNamespace nsTel = "http://tel.search.ch/api/spec/result/1.0/";

      Id = entry.GetString(ns + "id");
      Published = entry.GetDateTime(ns + "published");
      Updated = entry.GetDateTime(ns + "updated");
      Title = entry.GetString(ns + "title");
      Content = entry.GetString(ns + "content");
      AuthorName = entry.Element(ns + "author")?.GetString(ns + "name");

      var links = entry.Elements(ns + "link").ToArray();
      DetailsUrl = links.GetLinkHref("alternate", "text/html");
      VCardUrl = links.GetLinkHref("alternate", "text/x-vcard");
      EditUrl = links.GetLinkHref("edit");

      Position = entry.GetInteger(nsTel + "pos");
      TelSearchId = entry.GetString(nsTel + "id");

      var typeValue = entry.GetString(nsTel + "type");
      if (typeValue != null)
      {
        if (string.Equals(typeValue, "Person", StringComparison.CurrentCultureIgnoreCase))
          Type = TelSearchEntryType.Person;
        else if (string.Equals(typeValue, "Organisation", StringComparison.CurrentCultureIgnoreCase))
          Type = TelSearchEntryType.Organization;
      }

      Organizationname = entry.GetString(nsTel + "org");
      LastName = entry.GetString(nsTel + "name");
      FirstName = entry.GetString(nsTel + "firstname");
      AdditionalName = entry.GetString(nsTel + "subname");
      MaidenName = entry.GetString(nsTel + "maidenname");
      Occupation = entry.GetString(nsTel + "occupation");
      StreetName = entry.GetString(nsTel + "street");
      StreetNumber = entry.GetString(nsTel + "streetno");
      PostOfficeBox = entry.GetString(nsTel + "pobox");
      PostalCode = entry.GetString(nsTel + "zip");
      City = entry.GetString(nsTel + "city");
      Canton = entry.GetString(nsTel + "canton");
      Country = entry.GetString(nsTel + "country");
      NoPromotion = entry.GetString(nsTel + "nopromo")?.Equals("*") ?? false;
      Phone = entry.GetString(nsTel + "phone");

      var categories = entry.Elements(nsTel + "category").ToArray();
      if (categories.Length > 0)
      {
        Categories = new List<string>(categories.Length);
        foreach (var category in categories) ((List<string>) Categories).Add(category.Value);
      }

      var extras = entry.Elements(nsTel + "extra").ToArray();
      if (extras.Length > 0)
      {
        ExtraFields = new Dictionary<string, IReadOnlyList<string>>();

        foreach (var extra in extras)
        {
          var extraType = extra.Attribute("type")?.Value.ToLower();
          if (string.IsNullOrEmpty(extraType)) continue;
          var extraValue = extra.Value;
          if (string.IsNullOrEmpty(extraValue)) continue;

          if (!ExtraFields.TryGetValue(extraType, out var extraList))
          {
            extraList = new List<string>();
            ((Dictionary<string, IReadOnlyList<string>>) ExtraFields).Add(extraType, extraList);
          }

          ((List<string>) extraList).Add(extraValue);
        }

        if (ExtraFields.TryGetValue("fax", out _)) Fax = ExtraFields["fax"][0];
        if (ExtraFields.TryGetValue("mobile", out _)) Mobile = ExtraFields["mobile"][0];
        if (ExtraFields.TryGetValue("email", out _)) EMail = ExtraFields["email"][0];
        if (ExtraFields.TryGetValue("website", out _)) Website = ExtraFields["website"][0];
        if (ExtraFields.TryGetValue("skype", out _)) Skype = ExtraFields["skype"][0];
        if (ExtraFields.TryGetValue("icq", out _)) Icq = ExtraFields["icq"][0];
        if (ExtraFields.TryGetValue("msn", out _)) Msn = ExtraFields["msn"][0];
        if (ExtraFields.TryGetValue("aim", out _)) Aim = ExtraFields["aim"][0];
        if (ExtraFields.TryGetValue("yahoo", out _)) Yahoo = ExtraFields["yahoo"][0];
      }
    }
  }
}
