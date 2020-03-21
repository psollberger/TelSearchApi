namespace TelSearchApi
{
  using System;

  public class TelSearchException : Exception
  {
    /// <summary>
    ///   Fehlercode
    /// </summary>
    /// <remarks>/feed/tel:errorCode</remarks>
    public int Code { get; internal set; }

    /// <summary>
    ///   Grund des Fehlers
    /// </summary>
    /// <remarks>/feed/tel:errorReason</remarks>
    public string Reason { get; internal set; }

    /// <summary>
    ///   Beschreibung des Fehlers
    /// </summary>
    /// <remarks>/feed/tel:errorMessage</remarks>
    public new string Message { get; internal set; }
  }
}
