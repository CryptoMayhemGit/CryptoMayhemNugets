using Mayhem.Blockchain.Implementations.Services;
using Mayhem.Blockchain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Nethereum.Web3;

namespace Mayhem.Blockchain.Extensions
{
    public static class BlockchainExtensions
    {
        public static void AddBlockchain(this IServiceCollection services, string web3ProviderEndpoint)
        {
            services.AddScoped<IWeb3>(x => new Web3(web3ProviderEndpoint));
            services.AddScoped<IBlockchainService, BlockchainService>();
        }
    }
}
