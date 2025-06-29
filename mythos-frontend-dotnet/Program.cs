using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using mythos_frontend_dotnet;
using MudBlazor.Services;
using mythos_frontend_dotnet.Services;
using Microsoft.AspNetCore.Components.Authorization;

using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IChapterService, ChapterService>();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<JwtParser>();
builder.Services.AddScoped<MythosAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<MythosAuthStateProvider>());

builder.Services.AddScoped<AuthMessageHandler>();
builder.Services.AddScoped(sp =>
{
    var handler = sp.GetRequiredService<AuthMessageHandler>();
    handler.InnerHandler = new HttpClientHandler();
    var httpClient = new HttpClient(handler)
    {
        BaseAddress = new Uri("https://localhost:7252/api/")
    };
    return httpClient;
});

/*builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7252/api/")
});*/

await builder.Build().RunAsync();
