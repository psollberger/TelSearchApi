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
    ///   Eindeutiger Identifikator gemäss RFC 4287
    /// </summary>
    /// <remarks>/feed/entry/id</remarks>
    public string Id { get; private set; }

    /// <summary>
    ///   Publikationsdatum
    /// </summary>
    /// <remarks>/feed/entry/published</remarks>
    public DateTime? Published { get; private set; }

    /// <summary>
    ///   Letze Änderung des Eintrags
    /// </summary>
    /// <remarks>/feed/entry/updated</remarks>
    public DateTime? Updated { get; private set; }

    /// <summary>
    ///   Titel des Eintrags (Name der Person oder Organisation)
    /// </summary>
    /// <remarks>/feed/entry/title</remarks>
    public string Title { get; private set; }

    /// <summary>
    ///   Zusammenfassung des Eintrags in Plaintext
    /// </summary>
    /// <remarks>/feed/entry/content</remarks>
    public string Content { get; private set; }

    /// <summary>
    ///   Autor des Eintrags (gem. RFC 4287)
    /// </summary>
    /// <remarks>/feed/entry/author/name</remarks>
    public string AuthorName { get; private set; }

    /// <summary>
    ///   Link zur Detailseite des Eintrags auf tel.search.ch
    /// </summary>
    /// <remarks>/feed/entry/link/@rel='alternate'</remarks>
    public string DetailsUrl { get; private set; }

    /// <summary>
    ///   Link zur Korrekturseite des Eintrags auf tel.search.ch
    /// </summary>
    /// <remarks>/feed/entry/link/@rel='edit'</remarks>
    public string EditUrl { get; private set; }

    /// <summary>
    ///   URL für den Download als VCard
    /// </summary>
    /// <remarks>/feed/entry/link/@type='text/x-vcard'</remarks>
    public string VCardUrl { get; private set; }

    /// <summary>
    ///   Position des Eintrags im gesamten Resultateset
    /// </summary>
    /// <remarks>/feed/entry/tel:pos</remarks>
    public int ResultPosition { get; private set; }

    /// <summary>
    ///   Eindeutige tel.search.ch-ID des Eintrags
    /// </summary>
    /// <remarks>/feed/entry/tel:id</remarks>
    public string TelSearchId { get; private set; }

    /// <summary>
    ///   Art des Eintrags: Person oder Organisation
    /// </summary>
    /// <remarks>/feed/entry/tel:type</remarks>
    public TelSearchAddressType AddressType { get; private set; } = TelSearchAddressType.Unknown;

    /// <summary>
    ///   Nachname der Person resp. Name der Firma/Organisation
    /// </summary>
    /// <remarks>/feed/entry/tel:name</remarks>
    public string LastName { get; private set; }

    /// <summary>
    ///   Vorname der Person
    /// </summary>
    /// <remarks>/feed/entry/tel:firstname</remarks>
    public string FirstName { get; private set; }

    /// <summary>
    ///   Namenszusatz
    /// </summary>
    /// <remarks>/feed/entry/tel:subname</remarks>
    public string AdditionalName { get; private set; }

    /// <summary>
    ///   Mädchenname der Person
    /// </summary>
    /// <remarks>/feed/entry/tel:maidenname</remarks>
    public string MaidenName { get; private set; }

    /// <summary>
    ///   Beruf der Person, Zusatzbezeichnung bei Firmeneinträgen
    /// </summary>
    /// <remarks>/feed/entry/tel:occupation</remarks>
    public string Occupation { get; private set; }

    /// <summary>
    ///   Rubrik bei Firmeneinträgen (mehrere Elemente möglich)
    /// </summary>
    /// <remarks>/feed/entry/tel:category</remarks>
    public IList<string> Category { get; private set; }

    /// <summary>
    ///   Strassenbezeichnung
    /// </summary>
    /// <remarks>/feed/entry/tel:street</remarks>
    public string Street { get; private set; }

    /// <summary>
    ///   Hausnummer
    /// </summary>
    /// <remarks>/feed/entry/tel:streetno</remarks>
    public string StreetNumber { get; private set; }

    /// <summary>
    ///   Postfach
    /// </summary>
    /// <remarks>/feed/entry/tel:pobox</remarks>
    public string PostOfficeBox { get; private set; }

    /// <summary>
    ///   Postleitzahl
    /// </summary>
    /// <remarks>/feed/entry/tel:zip</remarks>
    public string PostalCode { get; private set; }

    /// <summary>
    ///   Ortsbezeichnung
    /// </summary>
    /// <remarks>/feed/entry/tel:city</remarks>
    public string City { get; private set; }

    /// <summary>
    ///   Kantonskürzel (ZH,BE,AG,...)
    /// </summary>
    /// <remarks>/feed/entry/tel:canton</remarks>
    public string Canton { get; private set; }

    /// <summary>
    ///   * Wünscht keine Werbung
    /// </summary>
    /// <remarks>/feed/entry/tel:nopromo</remarks>
    public bool NoPromotion { get; private set; }

    /// <summary>
    ///   Telefonnummer mit Ländervorwahl
    /// </summary>
    /// <remarks>/feed/entry/tel:phone</remarks>
    public string Phone { get; private set; }

    /// <summary>
    ///   Faxnummer (optional)
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='fax'</remarks>
    public string Fax { get; private set; }

    /// <summary>
    ///   Handynummer (optional)
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='mobile'</remarks>
    public string Mobile { get; private set; }

    /// <summary>
    ///   E-Mail-Adresse (optional)
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='email'</remarks>
    public string EMail { get; private set; }

    /// <summary>
    ///   Website URL (optional)
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='website'</remarks>
    public string Website { get; private set; }

    /// <summary>
    ///   Skype-Name (optional)
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='skype'</remarks>
    public string Skype { get; private set; }

    /// <summary>
    ///   ICQ Instant-Messenger-Name (optional)
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='icq'</remarks>
    public string Icq { get; private set; }

    /// <summary>
    ///   MSN Instant-Messenger-Name (optional)
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@tpye='msn'</remarks>
    public string Msn { get; private set; }

    /// <summary>
    ///   AIM Instant-Messenger-Name (optional)
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='aim'</remarks>
    public string Aim { get; private set; }

    /// <summary>
    ///   Yahoo Instant-Messenger-Name (optional)
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='yahoo'</remarks>
    public string Yahoo { get; private set; }

    /// <summary>
    ///   Alle Extra Felder die nicht speziell behandelt werden.
    /// </summary>
    /// <remarks>/feed/entry/tel:extra/@type='...'</remarks>
    public IDictionary<string, string> ExtraFields { get; private set; }

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
            result.Category.Add(elem.Value);
            break;
          case "street":
            result.Street = elem.Value;
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
            result.Canton = elem.Value;
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
                result.ExtraFields[extType] = extValue;
                break;
            }

            break;
        }

      return result;
    }
  }
}
