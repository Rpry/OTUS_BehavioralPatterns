namespace BehPatterns.Grpc.DomainServices.GetPostingExemplarRegradingRequirements
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
