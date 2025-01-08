

using Microsoft.EntityFrameworkCore;
using RutGonLink.Client.DTOs;
using RutGonLink.Client.Interfaces;
using RutGonLink.Data;

namespace RutGonLink.Services
{
  //public interface ILinkService
  //{
  //  Task<LinkDto> CreateLinkServiceAsync(LinkCreateDto linkCreateDto);
  //}

  public class LinkService : ILinkService
  {
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
    private readonly ITaoCodeRutGonLinkService _taoCodeRutGonLinkService;
    private readonly IConfiguration _configuration;
    public LinkService(IDbContextFactory<ApplicationDbContext> dbContextFactory, 
      ITaoCodeRutGonLinkService taoCodeRutGonLinkService,
      IConfiguration configuration
      )
    {
      _dbContextFactory = dbContextFactory;
      _taoCodeRutGonLinkService = taoCodeRutGonLinkService;
      _configuration = configuration;
    }

    //public async Task CreateLinkServiceAsync(Link link)
    //{
    //  await using var dbContext = _dbContextFactory.CreateDbContext();
    //  link.ShortCode = await _taoCodeRutGonLinkService.TaoCodeRutGonLinkAsync();
    //  dbContext.Links.Add(link);
    //  await dbContext.SaveChangesAsync();
    //}

    //public async Task<Link> GetLinkByShortCodeAsync(string shortCode)
    //{
    //  await using var dbContext = _dbContextFactory.CreateDbContext();
    //  return await dbContext.Links.FirstOrDefaultAsync(link => link.ShortCode == shortCode);
    //}

    //public async Task CreateLinkServiceAsync(string longUrl, string userId)
    //{

    //}

    public async Task<LinkDto> CreateLinkServiceAsync(LinkCreateDto linkCreateDto)
    {
      var domain = _configuration["Domain"] ?? throw new InvalidOperationException($"khong tim thay url, hay vao appsetting de set url");
      var shortCode = await _taoCodeRutGonLinkService.TaoCodeRutGonLinkAsync();

      var trimmedDomain = domain.TrimEnd('/');
      var shortUrl = $"{trimmedDomain}/{shortCode}";

      var link = new Link
      {
        LongUrl = linkCreateDto.LongUrl,
        ShortCode = shortCode,
        ShortUrl = shortUrl,
        UserId = linkCreateDto.UserId,
        IsActive = true,
      };

      await using var dbContext = _dbContextFactory.CreateDbContext();
      //dbContext.Links.Add(link);
      await dbContext.Links.AddAsync(link);
      await dbContext.SaveChangesAsync();

      return new LinkDto
      {
        Id = link.Id,
        LongUrl = link.LongUrl,
        ShortUrl = link.ShortUrl,
        ShortCode = link.ShortCode,
        IsActive = link.IsActive
      };
    }



  }
}
