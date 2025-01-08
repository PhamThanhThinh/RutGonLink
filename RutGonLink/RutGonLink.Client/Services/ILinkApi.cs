using Refit;
using RutGonLink.Client.DTOs;

namespace RutGonLink.Client.Services
{
  public interface ILinkApi
  {
    //[Post("/api/link")]
    [Post("/api/links")]
    Task<LinkDto> CreateLinkAsync(LinkCreateDto linkCreateDto);
  }
}
