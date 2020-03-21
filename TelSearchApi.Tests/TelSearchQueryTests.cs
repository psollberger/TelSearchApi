namespace TelSearchApi.Tests
{
  using System.Collections.Generic;
  using NUnit.Framework;

  [TestFixture]
  public class TelSearchQueryTests
  {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AsDictionary_WithoutParams_ContainsDefaults()
    {
      var query = new TelSearchQuery();
      Assert.That(query.AsDictionary(), Is.EquivalentTo(new Dictionary<string, string>
      {
        {"privat", "1"},
        {"firma", "1"}
      }));
    }

    [Test]
    public void AsUri_WithoutParams_ContainsDefaults()
    {
      var query = new TelSearchQuery();
      Assert.That(query.AsUri().AbsoluteUri,
        Is.EqualTo(
          "https://tel.search.ch/api/?privat=1&firma=1"));
    }
  }
}
