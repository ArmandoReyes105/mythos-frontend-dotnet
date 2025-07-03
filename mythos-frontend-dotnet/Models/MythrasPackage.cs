namespace mythos_frontend_dotnet.Models
{
    public class MythrasPackage
    {
        public int MythrasPackageId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int MythrasAmount { get; set; }
        public decimal Price { get; set; }
        public int BonusMythras { get; set; }
    }
}
