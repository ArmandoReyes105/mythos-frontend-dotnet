namespace mythos_frontend_dotnet.Models
{
    public class PurchaseMythrasResponse
    {
        public string Message { get; set; } = string.Empty;
        public int MythrasBalance { get; set; }
        public DateTime WalletLastUpdated { get; set; }
    }
}
