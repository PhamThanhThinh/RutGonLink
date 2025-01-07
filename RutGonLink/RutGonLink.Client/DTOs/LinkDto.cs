namespace RutGonLink.Client.DTOs
{
  public class LinkDto
  {
    public long Id { get; set; }
    public string LongUrl { get; set; }
    public string ShortUrl { get; set; }
    //public string ShortCode { get; set; }
    public bool IsActive { get; set; }
  }
}
