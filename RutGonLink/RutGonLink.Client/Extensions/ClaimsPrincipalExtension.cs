using System.Security.Claims;

namespace RutGonLink.Client.Extensions
{
  public static class ClaimsPrincipalExtension
  {
    // cách 1
    // khó dùng trong file razor (blazor)
    //public static string GetUserId(this System.Security.Claims.ClaimsPrincipal user)
    //{
    //  return user.FindFirst("UserId")!.Value;
    //}

    // cách 2
    public static string? GetUserId(this ClaimsPrincipal claimsPrincipal) =>
      claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
  }
}
