using Mayhem.Blockchain.Enums;
using Mayhem.Blockchain.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mayhem.Blockchain.Interfaces.Services
{
    /// <summary>
    /// Blockchain Service
    /// </summary>
    public interface IBlockchainService
    {
        /// <summary>
        /// Verifies the wallet with signed message asynchronous.
        /// </summary>
        /// <param name="wallet">The wallet.</param>
        /// <param name="messageToSign">The message to sign.</param>
        /// <param name="signedMessage">The signed message.</param>
        /// <returns></returns>
        Task<bool> VerifyWalletWithSignedMessageAsync(string wallet, string messageToSign, string signedMessage);
        /// <summary>
        /// Gets the token logs asynchronous.
        /// </summary>
        /// <param name="blockType">Type of the block.</param>
        /// <param name="blockFrom">The block from.</param>
        /// <param name="blockTo">The block to.</param>
        /// <returns></returns>
        Task<List<GetLogResult>> GetTokenLogsAsync(BlocksType blockType, long blockFrom, long blockTo);
        /// <summary>
        /// Gets the current block asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<long> GetCurrentBlockAsync();
    }
}