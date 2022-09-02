using Nethereum.ABI.FunctionEncoding.Attributes;
using System.Numerics;

namespace Mayhem.Blockchain.Dto
{
    [Event("Transfer")]
    public class TransferEventBaseDto : IEventDTO
    {
        [Parameter("address", "from", 1, true)]
        public virtual string From { get; set; }

        [Parameter("address", "to", 2, true)]
        public virtual string To { get; set; }

        [Parameter("uint256", "tokens", 3, false)]
        public virtual BigInteger Value { get; set; }
    }
}
