using Microsoft.EntityFrameworkCore;
using RutGonLink.Client.DTOs;
using RutGonLink.Client.Extensions;
using RutGonLink.Client.Interfaces;
using RutGonLink.Data;
using RutGonLink.Services;
using System.Security.Claims;

namespace RutGonLink.Endpoints
{
  public static class LinkEndpoint
  {
    //public static async Task CreateLinkAsync(HttpContext context)
    //{
    //  var dbContextFactory = context.RequestServices.GetRequiredService<IDbContextFactory<ApplicationDbContext>>();
    //  var taoCodeRutGonLinkService = context.RequestServices.GetRequiredService<ITaoCodeRutGonLinkService>();
    //  var configuration = context.RequestServices.GetRequiredService<IConfiguration>();
    //  var linkCreateDto = await context.Request.ReadFromJsonAsync<LinkCreateDto>();
    //  var domain = configuration["Domain"] ?? throw new InvalidOperationException($"khong tim thay url, hay vao appsetting de set url");
    //  var shortCode = await taoCodeRutGonLinkService.TaoCodeRutGonLinkAsync();
    //  var link = new Link
    //  {
    //    LongUrl = linkCreateDto.LongUrl,
    //    UserId = linkCreateDto.UserId,
    //    ShortCode = shortCode,
    //    IsActive = true,
    //    ShortUrl = domain
    //  };
    //  await using var dbContext = dbContextFactory.CreateDbContext();
    //  await dbContext.Links.AddAsync(link);
    //  await dbContext.SaveChangesAsync();
    //  await context.Response.WriteAsJsonAsync(new LinkDto
    //  {
    //    Id = link.Id,
    //    LongUrl = link.LongUrl,
    //    ShortUrl = link.ShortUrl,
    //    ShortCode = link.ShortCode,
    //    IsActive = link.IsActive
    //  });
    //}

    public static IEndpointRouteBuilder MapLinkEndpoint(this IEndpointRouteBuilder endpoints)
    {
      endpoints.MapPost("/api/link", async (LinkCreateDto dto, ILinkService linkService, ClaimsPrincipal user) =>
      {
        // Lấy thông tin người dùng từ ClaimsPrincipal
        //var userId = user.FindFirst("UserId")?.Value;

        //if (userId == null)
        //{
        //  return Results.Unauthorized();
        //}

        //// Tạo link rút gọn
        //var result = await linkService.CreateShortLinkAsync(dto, userId);

        //if (result == null)
        //{
        //  return Results.BadRequest("Failed to create short link.");
        //}

        //return Results.Ok(result);

        //var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //var userId = user.FindFirst(ClaimTypes.NameIdentifier)!.Value;

        var userId = user.GetUserId();

        if (userId != dto.UserId)
        {
          return Results.Unauthorized();
        }

        var link = await linkService.CreateLinkServiceAsync(dto);

        return Results.Ok(link);

      }).RequireAuthorization();
      return endpoints;
    }
  }
}
