using Mayhem.Blockchain.Enums;
using Mayhem.Blockchain.Interfaces.Services;
using Mayhem.Blockchain.Responses;
using Mayhem.Configuration.Interfaces;
using Mayhem.Messages;
using Microsoft.Extensions.Logging;
using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Signer;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mayhem.Blockchain.Implementations.Services
{
    public class BlockchainService : IBlockchainService
    {
        private readonly IWeb3 web3;
        private readonly ILogger<BlockchainService> logger;
        private readonly IMayhemConfigurationService mayhemConfigurationService;

        public BlockchainService(
            IWeb3 web3,
            ILogger<BlockchainService> logger, IMayhemConfigurationService mayhemConfigurationService)
        {
            this.web3 = web3;
            this.logger = logger;
            this.mayhemConfigurationService = mayhemConfigurationService;
        }

        public async Task<bool> VerifyWalletWithSignedMessageAsync(string wallet, string messageToSign, string signedMessage)
        {
            EthereumMessageSigner signer = new();
            string addressRec = signer.EncodeUTF8AndEcRecover(messageToSign, signedMessage);
            return wallet.Equals(addressRec, StringComparison.InvariantCultureIgnoreCase)
                ? await Task.FromResult(true)
                : await Task.FromResult(false);
        }

        public async Task<List<GetLogResult>> GetTokenLogsAsync(BlocksType blockType, long blockFrom, long blockTo)
        {
            try
            {
                logger.LogDebug(LoggerMessages.GettingInformationForBlocks(blockTo, blockFrom));

                string contract = GetContract(blockType);
                Event<TransferEventDTO> transferEventHandlerContract = web3.Eth.GetEvent<TransferEventDTO>(contract);
                NewFilterInput filterAllTransferEventsForAllContracts = transferEventHandlerContract.CreateFilterInput(new BlockParameter((ulong)blockFrom), new BlockParameter((ulong)blockTo));
                List<EventLog<TransferEventDTO>> allTransferEventsForContract3 = await transferEventHandlerContract.GetAllChangesAsync(filterAllTransferEventsForAllContracts);

                if (allTransferEventsForContract3 == null)
                {
                    throw ExceptionMessages.CannotGetDataException;
                }
                return allTransferEventsForContract3.Select(x => new GetLogResult()
                {
                    Topics = new List<string>()
                    {
                        x.Event.From,
                        x.Event.To,
                        x.Event.Value.ToString(),
                    }
                }).ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, LoggerMessages.ErrorOccurredDuring(nameof(GetTokenLogsAsync)));
                return null;
            }
        }

        public async Task<long> GetCurrentBlockAsync()
        {
            HexBigInteger res = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();

            return (long)res.Value;
        }

        private string GetContract(BlocksType blockType)
        {
            return blockType switch
            {
                BlocksType.Item => mayhemConfigurationService.MayhemConfiguration.CommonConfiguration.NftItemSmartContractAddress,
                BlocksType.Land => mayhemConfigurationService.MayhemConfiguration.CommonConfiguration.NftLandSmartContractAddress,
                BlocksType.Npc => mayhemConfigurationService.MayhemConfiguration.CommonConfiguration.NftNpcSmartContractAddress,
                _ => throw ExceptionMessages.ContractNotFoundException,
            };
        }
    }
}
