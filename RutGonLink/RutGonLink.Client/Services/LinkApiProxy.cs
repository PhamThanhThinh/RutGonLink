using RutGonLink.Client.DTOs;
using RutGonLink.Client.Interfaces;

namespace RutGonLink.Client.Services
{
  public class LinkApiProxy : ILinkService
  {
    //private readonly ILinkApi _linkApi;
    //public LinkApiProxy(ILinkApi linkApi)
    //{
    //  _linkApi = linkApi;
    //}
    //public async Task<LinkDto> CreateLinkServiceAsync(LinkCreateDto linkCreateDto)
    //{
    //  return await _linkApi.CreateLinkAsync(linkCreateDto);
    //}

    private readonly ILinkApi _linkApi;

    public LinkApiProxy(ILinkApi linkApi)
    {
      _linkApi = linkApi;
    }

    public Task<LinkDto> CreateLinkServiceAsync(LinkCreateDto linkCreateDto) =>
      _linkApi.CreateLinkAsync(linkCreateDto);
  }
}
