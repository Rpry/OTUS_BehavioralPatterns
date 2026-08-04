using System.Threading.Tasks;

namespace BehPatterns.Grpc
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            await ServiceSetup.Run();
        }
    }
}
