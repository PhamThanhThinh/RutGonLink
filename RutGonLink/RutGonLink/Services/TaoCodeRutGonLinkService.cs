namespace RutGonLink.Services
{
  public class TaoCodeRutGonLinkService
  {
    public ShortCodeGenerateService()
    {

    }
    public async Task<string> TaoCodeRutGonLinkAsync()
    {
      const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
      //var maRutGonTuCacKyTu = characters.ToCharArray();
      int length = characters.Length;
      var maRutGonTuCacKyTu = Enumerable.Repeat(characters, 5)
        .Select(c =>
        {
          var soNgauNhien = Random.Shared.Next(length);
          return c[soNgauNhien];
        }
        ).ToArray();

      return new string(maRutGonTuCacKyTu);

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
