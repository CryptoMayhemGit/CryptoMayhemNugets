namespace Mayhem.Blockchain.Helpers
{
    public static class BlockchainHelperExtension
    {
        private const string ZeroWalletAddress = "0x0000000000000000000000000000000000000000";

        public static bool IsZeroAddress(this string address)
        {
            return address.Equals(ZeroWalletAddress);
        }
    }
}
