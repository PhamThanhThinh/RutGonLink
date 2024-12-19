using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutGonLink.Data
{
  public class Link
  {
    [Key]
    public long Id { get; set; }
    // link dài (nhập giá trị đầu vào)
    [Required, Length(10, 4000)]
    //public string LongUrl { get; set; } = "";
    public string LongUrl { get; set; }

    [Required, Length(5, 10)]
    //public string ShortUrl { get; set; } = ""; // link rút gọn -> link ngắn
    public string ShortUrl { get; set; }
    //public string ShortCode { get; set; } = "";

    [Required]
    //public string UserId { get; set; } = "";
    public string UserId { get; set; }

    // dùng để vô hiệu hóa đường link
    public bool IsActive { get; set; }

    public virtual ApplicationUser User { get; set; }

    //[InverseProperty(nameof(LinkAnalytic.OriginalLink))]
    [InverseProperty(nameof(LinkAnalytic.Link))]
    public virtual ICollection<LinkAnalytic> LinkAnalytics { get; set; }
  }
}
