using System;
using mythos_frontend_dotnet.Services;

namespace mythos_frontend_dotnet.Clients;

public class NodeApiClient
{
    public HttpClient Client { get; }

    public NodeApiClient(AuthMessageHandler handler, IConfiguration configuration)
    {
        //handler.InnerHandler = new HttpClientHandler();

        Client = new HttpClient(handler)
        {
            BaseAddress = new Uri(configuration.GetValue<string>("NodeURL")!)
        };
    }
}
