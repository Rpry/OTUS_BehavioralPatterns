namespace BehPatterns.Grpc.Domain
{
    // Требование к перемаркировке экземпляра.
    public class ExemplarRegradingRequirement
    {
        public string ExemplarId;
        public string CurrentSku;
        public string RequiredSku;
        public string Reason;
    }
}
