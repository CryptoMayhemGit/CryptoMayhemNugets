using Mayhem.Util.Exceptions;

namespace Mayhem.Messages
{
    public static class ValidationMessages
    {
        public static ValidationMessage CannotGenerateTokenMessage(string wallet) => new("Token", $"Cannot generate token for wallet {wallet}.");
        public static ValidationMessage UserDoesNotExistMessage(int userId) => new("User", $"User with id {userId} doesn't exist.");
        public static ValidationMessage UserDoesNotHaveEnoughResourceExistMessage(string resource) => new($"{resource}", "The user doesn't have enough resource.");
        public static ValidationMessage GuildDoesNotExistMessage() => new("Guild", $"Guild doesn't exist.");
        public static ValidationMessage GuildDoesNotHaveEnoughResourceMessage() => new("Guild", $"Guild doesn't have enough resource.");
        public static ValidationMessage CouldNotGeneratePathForLands(long landFromId, long landToId) => new("Path", $"Could not generate path from land {landFromId} to land {landToId}");
    }
}
