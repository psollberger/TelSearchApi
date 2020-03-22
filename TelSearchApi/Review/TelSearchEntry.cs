namespace TelSearchApi
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Xml.Linq;

  /// <summary>
  ///   <see href="https://tel.search.ch/api/help" />
  /// </summary>
  [DebuggerDisplay("{" + nameof(Title) + "}")]
  public class TelSearchEntry
  {
    /// <summary>
    ///   Unique identificator according to RFC 4287
    /// </summary>
    /// <remarks>/feed/entry/id</remarks>
    public string Id { get; private set; }

    /// <summary>
    ///   Publishing date
    /// </summary>
    /// <remarks>/feed/entry/published</remarks>
    public DateTime? Published { get; private set; }

    /// <summary>
    ///   Date of last change
    /// </summary>
    /// <remarks>/feed/entry/updated</remarks>
    public DateTime? Updated { get; private set; }

    /// <summary>
    ///   Title of the entry (Name of the person or organization)
    /// </summary>
    /// <remarks>/feed/entry/title</remarks>
    public string Title { get; private set; }

    /// <summary>
    ///   Aggregation of the entry in plaintext
    /// </summary>
    /// <remarks>/feed/entry/content</remarks>
    public string Content { get; private set; }

    /// <summary>
    ///   Author of the entry according to RFC 4287
    /// </summary>
    /// <remarks>/feed/entry/author/name</remarks>
    public string AuthorName { get; private set; }

    /// <summary>
    ///   Link to the detail page of the entry on tel.search.ch
    /// </summary>
    /// <remarks>/feed/entry/link/@rel='alternate'</remarks>
    public string DetailsUrl { get; private set; }

    /// <summary>
    ///   Link to the correction page of the entry on tel.search.ch
    /// </summary>
    /// <remarks>/feed/entry/link/@rel='edit'</remarks>
    public string EditUrl { get; private set; }

    /// <summary>
    ///   Link to the VCard file for the entry
    /// </summary>
    /// <remarks>/feed/entry/link/@type='text/x-vcard'</remarks>
    public string VCardUrl { get; private set; }

    /// <summary>
    ///   Position of the entry in the entire result set
    /// </summary>
    /// <remarks>/feed/entry/tel:pos</remarks>
    public int ResultPosition { get; private set; }

    /// <summary>
    ///   Unique tel.search.ch identification
    /// </summary>
    /// <remarks>/feed/entry/tel:id</remarks>
    public string TelSearchId { get; private set; }

    /// <summary>
    ///   Type of the entry: person or organization
    /// </summary>
    /// <remarks>/feed/entry/tel:type</remarks>
    public TelSearchAddressType AddressType { get; private set; } = TelSearchAddressType.Unknown;

    /// <summary>
    ///   Lastname of the person or name of the organization
    /// </summary>
    /// <remarks>/feed/entry/tel:name</remarks>
    public string LastName { get; private set; }

    /// <summary>
    ///   Firstname of the person
    /// </summary>
    /// <remarks>/feed/entry/tel:firstname</remarks>
    public string FirstName { get; private set; }

    /// <summary>
    ///   Additional name of the person or organization
    /// </summary>
    /// <remarks>/feed/entry/tel:subname</remarks>
    public string AdditionalName { get; private set; }

    /// <summary>
    ///   The maiden name of the person
    /// </summary>
    /// <remarks>/feed/entry/tel:maidenname</remarks>
    public string MaidenName { get; private set; }

    /// <summary>
    ///   Profession of the person or an additional description of the organization
    /// </summary>
    /// <remarks>/feed/entry/tel:occupation</remarks>
    public string Occupation { get; private set; }

    /// <summary>
    ///   Zero, one or more categories the entry belongs to
    /// </summary>
    /// <remarks>/feed/entry/tel:category</remarks>
    public IReadOnlyList<string> Categories { get; } = new List<string>();

    /// <summary>
    ///   The name of the street
    /// </summary>
    /// <remarks>/feed/entry/tel:street</remarks>
    public string StreetName { get; private set; }

    /// <summary>
    ///   The building number
    /// </summary>
    /// <remarks>/feed/entry/tel:streetno</remarks>
    public string StreetNumber { get; private set; }

    /// <summary>
    ///   The post office box number
    /// </summary>
    /// <remarks>/feed/entry/tel:pobox</remarks>
    public string PostOfficeBox { get; private set; }

    /// <summary>
    ///   The zip code
    /// </summary>
    /// <remarks>/feed/entry/tel:zip</remarks>
    public string PostalCode { get; private set; }

    /// <summary>
    ///   The city name
    /// </summary>
    /// <remarks>/feed/entry/tel:city</remarks>
    public string City { get; private set; }

    /// <summary>
    ///   The abbreviation of the canton (ZH,BE,AG,TG,SG,...)
    /// </summary>
    /// <remarks>/feed/entry/tel:canton</remarks>
    public string CantonAbbreviation { get; private set; }

    /// <summary>
    ///   Defines if the person/organization does not wish to receive advertisement
    /// </summary>
    /// <remarks>/feed/entry/tel:nopromo</remarks>
    public bool NoPromotion { get; private set; }

    /// <summary>
    ///   The phone number in international format
    /// </summary>
    /// <remarks>/feed/entry/tel:phone</remarks>
    public string Phone { get; private set; }

    /// <summary>
    ///   The fax number
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='fax'</remarks>
    public string Fax { get; private set; }

    /// <summary>
    ///   The cell phone number
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='mobile'</remarks>
    public string Mobile { get; private set; }

    /// <summary>
    ///   The email address
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='email'</remarks>
    public string EMail { get; private set; }

    /// <summary>
    ///   The website URL
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='website'</remarks>
    public string Website { get; private set; }

    /// <summary>
    ///   Skype name
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='skype'</remarks>
    public string Skype { get; private set; }

    /// <summary>
    ///   ICQ Instant-Messenger-Name
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='icq'</remarks>
    public string Icq { get; private set; }

    /// <summary>
    ///   MSN Instant-Messenger-Name
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='msn'</remarks>
    public string Msn { get; private set; }

    /// <summary>
    ///   AIM Instant-Messenger-Name
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='aim'</remarks>
    public string Aim { get; private set; }

    /// <summary>
    ///   Yahoo Instant-Messenger-Name
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='yahoo'</remarks>
    public string Yahoo { get; private set; }

    /// <summary>
    ///   All additional extra fields that are not listed in their own properties
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='...'</remarks>
    public IReadOnlyDictionary<string, string> ExtraFields { get; } = new Dictionary<string, string>();

    public static TelSearchEntry CreateFromElement(XElement entry)
    {
      var result = new TelSearchEntry();

      foreach (var elem in entry.Elements())
        switch (elem.Name.LocalName)
        {
          case "id":
            if (elem.Name.Namespace.NamespaceName.EndsWith("Atom"))
              result.Id = elem.Value;
            else if (elem.Name.Namespace.NamespaceName.Contains("tel.search.ch")) result.TelSearchId = elem.Value;
            break;
          case "published":
          {
            if (DateTime.TryParse(elem.Value, out var pub))
              result.Published = pub;
          }
            break;
          case "updated":
            if (DateTime.TryParse(elem.Value, out var upd))
              result.Updated = upd;
            break;
          case "title":
            result.Title = elem.Value;
            break;
          case "content":
            result.Content = elem.Value;
            break;
          case "author":
            result.AuthorName = elem.Element("{http://www.w3.org/2005/Atom}name")?.Value;
            break;
          case "link":
            var linkType = elem.Attribute("type")?.Value;
            if (linkType == "text/x-vcard")
            {
              result.VCardUrl = elem.Attribute("href")?.Value;
            }
            else
            {
              var linkRel = elem.Attribute("rel")?.Value;
              switch (linkRel)
              {
                case "alternate":
                  result.DetailsUrl = elem.Attribute("href")?.Value;
                  break;
                case "edit":
                  result.EditUrl = elem.Attribute("href")?.Value;
                  break;
              }
            }

            break;
          case "pos":
            if (int.TryParse(elem.Value, out var rpn))
              result.ResultPosition = rpn;
            break;
          case "type":
            var adrTyp = elem.Value;
            if (string.Equals(adrTyp, "Person", StringComparison.CurrentCultureIgnoreCase))
              result.AddressType = TelSearchAddressType.Person;
            else if (string.Equals(adrTyp, "Organisation", StringComparison.CurrentCultureIgnoreCase))
              result.AddressType = TelSearchAddressType.Organization;
            break;
          //case "org":
          //  result.OrganisationName = elem.Value;
          //  break;
          case "name":
            result.LastName = elem.Value;
            break;
          case "firstname":
            result.FirstName = elem.Value;
            break;
          case "subname":
            result.AdditionalName = elem.Value;
            break;
          case "maidenname":
            result.MaidenName = elem.Value;
            break;
          case "occupation":
            result.Occupation = elem.Value;
            break;
          case "category":
            ((List<string>) result.Categories).Add(elem.Value);
            break;
          case "street":
            result.StreetName = elem.Value;
            break;
          case "streetno":
            result.StreetNumber = elem.Value;
            break;
          case "pobox":
            result.PostOfficeBox = elem.Value;
            break;
          case "zip":
            result.PostalCode = elem.Value;
            break;
          case "city":
            result.City = elem.Value;
            break;
          case "canton":
            result.CantonAbbreviation = elem.Value;
            break;
          case "nopromo":
            result.NoPromotion = elem.Value == "*";
            break;
          case "phone":
            result.Phone = elem.Value;
            break;
          case "extra":
            var extType = elem.Attribute("type")?.Value.ToLower();
            if (extType == null) continue;
            var extValue = elem.Value;

            switch (extType)
            {
              case "mobile":
                result.Mobile = extValue;
                break;
              case "fax":
                result.Fax = extValue;
                break;
              case "email":
                result.EMail = extValue;
                break;
              case "website":
                result.Website = extValue;
                break;
              case "skype":
                result.Skype = extValue;
                break;
              case "icq":
                result.Icq = extValue;
                break;
              case "msn":
                result.Msn = extValue;
                break;
              case "aim":
                result.Aim = extValue;
                break;
              case "yahoo":
                result.Yahoo = extValue;
                break;
              default:
                ((Dictionary<string, string>) result.ExtraFields)[extType] = extValue;
                break;
            }

            break;
        }

      return result;
    }
  }
}
