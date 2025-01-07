using RutGonLink.Client.DTOs;

namespace RutGonLink.Client.Interfaces
{
  public interface ILinkService
  {
    Task<LinkDto> CreateLinkServiceAsync(LinkCreateDto linkCreateDto);
  }
}
