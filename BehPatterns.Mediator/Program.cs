using System.Threading.Tasks;

namespace BehPatterns.Mediator
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            await ServiceSetup.Run();
        }
    }
}
