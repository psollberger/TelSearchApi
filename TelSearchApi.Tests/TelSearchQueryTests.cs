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
    public void AsDictionary_WithoutParams_IsEmpty()
    {
      var query = new TelSearchQuery();
      Assert.That(query.AsDictionary(), Is.Empty);
    }

    [Test]
    public void AsUri_WithoutParams_EqualsBaseUri()
    {
      var query = new TelSearchQuery();
      Assert.That(query.AsUri().AbsoluteUri, Is.EqualTo(TelSearchCore.BaseUri.AbsoluteUri));
    }
  }
}
