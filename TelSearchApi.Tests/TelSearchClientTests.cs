namespace TelSearchApi.Tests
{
  using NUnit.Framework;

  [TestFixture]
  public class TelSearchClientTests
  {
    [Test]
    public void ExecuteQueryAsync_WhenCalledWithNullQuery_ThrowsArgumentNullException()
    {
      var client = new TelSearchClient(null);
      Assert.That(async () => { await client.ExecuteQueryAsync(null); }, Throws.ArgumentNullException);
    }
  }
}
