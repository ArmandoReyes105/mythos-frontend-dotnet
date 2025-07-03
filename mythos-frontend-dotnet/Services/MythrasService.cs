using System.Net.Http.Json;
using mythos_frontend_dotnet.Models;

namespace mythos_frontend_dotnet.Services
{
    public class MythrasService
    {
        private readonly HttpClient _http;

        public MythrasService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<MythrasPackage>> GetPackagesAsync()
        {
            try
            {
                var packages = await _http.GetFromJsonAsync<List<MythrasPackage>>("mythras-packages");
                return packages ?? new List<MythrasPackage>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error al obtener paquetes de Mythras: " + ex.Message);
            }
        }

        public async Task<PurchaseMythrasResponse> PurchaseMythrasAsync(PurchaseMythrasRequest request)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("mythras-purchase", request);

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al procesar la compra: {errorMessage}");
                }

                var result = await response.Content.ReadFromJsonAsync<PurchaseMythrasResponse>();
                return result ?? new PurchaseMythrasResponse();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error al procesar la compra: " + ex.Message);
            }
        }
    }
}
