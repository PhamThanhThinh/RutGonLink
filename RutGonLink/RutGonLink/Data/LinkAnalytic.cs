namespace RutGonLink.Data
{
  public class LinkAnalytic
  {
    public long Id { get; set; }
    public long LinkId { get; set; }

    public DateTime ClickTime { get; set; }

    //public virtual Link OriginalLink { get; set; }
    public virtual Link Link { get; set; }


  }
}
