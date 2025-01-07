

using Microsoft.EntityFrameworkCore;
using RutGonLink.Data;

namespace RutGonLink.Services
{
  public class LinkService
  {
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
    private readonly ITaoCodeRutGonLinkService _taoCodeRutGonLinkService;

    public LinkService(IDbContextFactory<ApplicationDbContext> dbContextFactory, ITaoCodeRutGonLinkService taoCodeRutGonLinkService)
    {
      _dbContextFactory = dbContextFactory;
      _taoCodeRutGonLinkService = taoCodeRutGonLinkService;
    }

    public async Task CreateLinkServiceAsync(Link link)
    {
      await using var dbContext = _dbContextFactory.CreateDbContext();
      link.ShortCode = await _taoCodeRutGonLinkService.TaoCodeRutGonLinkAsync();
      dbContext.Links.Add(link);
      await dbContext.SaveChangesAsync();
    }
  }
}
