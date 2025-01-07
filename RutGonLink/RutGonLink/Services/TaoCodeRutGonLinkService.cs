using Microsoft.EntityFrameworkCore;
using RutGonLink.Data;

namespace RutGonLink.Services
{
  public interface ITaoCodeRutGonLinkService
  {
    Task<string> TaoCodeRutGonLinkAsync();
  }

  public class TaoCodeRutGonLinkService : ITaoCodeRutGonLinkService
  {
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
    public TaoCodeRutGonLinkService(IDbContextFactory<ApplicationDbContext> contextFactory)
    {
      _dbContextFactory = contextFactory;
    }
    public async Task<string> TaoCodeRutGonLinkAsync()
    {
      //const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
      ////var maRutGonTuCacKyTu = characters.ToCharArray();
      //int length = characters.Length;
      //var maRutGonTuCacKyTu = Enumerable.Repeat(characters, 5)
      //  .Select(c =>
      //  {
      //    var soNgauNhien = Random.Shared.Next(length);
      //    return c[soNgauNhien];
      //  }
      //  ).ToArray();

      //return new string(maRutGonTuCacKyTu);

      var codeRutGon = TaoCodeRutGonLink(5);

      await using var dbcontext = _dbContextFactory.CreateDbContext();

      while (await dbcontext.Links.AsNoTracking().AnyAsync(link => link.ShortCode == codeRutGon))
      {
        codeRutGon = TaoCodeRutGonLink(5);
      }

      return codeRutGon;
    }

    public static string TaoCodeRutGonLink(int length)
    {
      const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
      //var maRutGonTuCacKyTu = characters.ToCharArray();
      length = characters.Length;
      var maRutGonTuCacKyTu = Enumerable.Repeat(characters, 5)
        .Select(c =>
        {
          var soNgauNhien = Random.Shared.Next(length);
          return c[soNgauNhien];
        }
        ).ToArray();

      return new string(maRutGonTuCacKyTu);
    }
  }
}
