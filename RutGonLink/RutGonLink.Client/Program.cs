using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Refit;
using RutGonLink.Client;
using RutGonLink.Client.Interfaces;
using RutGonLink.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddTransient<ILinkService, LinkApiProxy>();
//var apiUrl = builder.HostEnvironment.BaseAddress;
builder.Services.AddRefitClient<ILinkApi>()
  .ConfigureHttpClient(httpClient =>
  {
    var apiUrl = builder.Configuration["ApiUrl"];

    //httpClient.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
    httpClient.BaseAddress = new Uri(apiUrl);
  });

await builder.Build().RunAsync();
