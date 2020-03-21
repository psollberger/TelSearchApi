namespace TelSearchApi.Tests
{
  using NUnit.Framework;

  [TestFixture]
  public class TelSearchQueryTests
  {
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void GetRequestUri_WithoutParams_EqualsBaseUri()
    {
      var query = new TelSearchQuery(null);
      Assert.That(query.GetRequestUri().AbsoluteUri, Is.EqualTo(TelSearchCore.BaseUri.AbsoluteUri));
    }
  }
}
