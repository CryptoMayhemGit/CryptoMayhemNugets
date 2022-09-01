namespace Mayhem.Messages
{
    public class BaseMessages
    {
        public const string LandFromMustBeDifferentThanLandToBaseMessage = "LandFrom must be different than LandTo.";
        public const string WalletIsRequiredBaseMessage = "Wallet is required.";
        public const string UserCannotInviteHimselfBaseMessage = "UserId: User cannot invite himself.";
        public const string ValidEmailIsRequiredBaseMessage = "A valid email is required.";
        public const string OwnerCannotChangeOwnerToHimselfBaseMessage = "Owner cannot change owner to himself.";
        public const string OwnerCannotRemoveHimselfBaseMessage = "Owner cannot remove himself.";
        public const string EmailAddressIsRequiredBaseMessage = "Email address is required.";
        public static string WalletSignatureValidationWasUnsuccessfulForWalletBaseMessage(string wallet) => $"Metamask signature: Wallet signature validation was unsuccessful for wallet: {wallet}.";
    }
}
