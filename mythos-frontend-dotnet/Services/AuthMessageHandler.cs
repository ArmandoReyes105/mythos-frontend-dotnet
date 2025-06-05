using Microsoft.JSInterop;
using System.Net.Http.Headers; 

namespace mythos_frontend_dotnet.Services
{
    public class AuthMessageHandler(IJSRuntime js) : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            var token = await js.InvokeAsync<string>("localStorage.getItem", "access_token");

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
