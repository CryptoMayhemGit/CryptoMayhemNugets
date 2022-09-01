using FluentValidation.Results;

namespace Mayhem.Messages
{
    public class FailureMessages
    {
        public static ValidationFailure GuildWithIdDoesNotExistFailure(int guildId) => new("GuildId", $"Guild with id {guildId} doesn't exist.");
        public static ValidationFailure UserWithIdDoesNotExistFailure(int userId) => new("UserId", $"User with id {userId} doesn't exist.");
        public static ValidationFailure UserWithIdIsAlreadyInThisGuildFailure(int userId) => new("UserId", $"User with id {userId} is already in this guild.");
        public static ValidationFailure UserWithIdIsAlreadyInOtherGuildFailure(int userId) => new("UserId", $"User with id {userId} is already in other guild.");
        public static ValidationFailure InvitationWithIdDoesNotExistFailure(int invitationId) => new("InvitationId", $"Invitation with id {invitationId} doesn't exist.");
        public static ValidationFailure OnlyGuildOwnerCanAcceptInvitationFailure() => new("InvitationId", $"Only guild owner can accept the invitation.");
        public static ValidationFailure OnlyUserFromInvitationCanAcceptFailure() => new("InvitationId", $"Only user from invitation can accept.");
        public static ValidationFailure LandWithIdAlreadyHasBuildingFailure(long landId) => new("LandId", $"Land with id {landId} already has a building.");
        public static ValidationFailure LandWithIdMustBeDiscoveredFailure(long landId) => new("LandId", $"Land with id {landId} is undiscover.");
        public static ValidationFailure LandWithIdBelongsToAnotherUserFailure(long landId) => new("LandId", $"Land with id {landId} belongs to another user.");
        public static ValidationFailure BuildingCannotBeBuildOnLandFailure(string buildingTypeId, string landTypeId) => new("BuildingId", $"Building {buildingTypeId} cannot be build on land {landTypeId}.");
        public static ValidationFailure BuildingCannotBeBuildWithoutNpcAvatarFailure(string buildingTypeId) => new("BuildingId", $"Building {buildingTypeId} cannot be build without Npc/Avatar.");
        public static ValidationFailure OnlyOwnerCanAddBuildingFailure() => new("OwnerId", $"Only owner can add building.");
        public static ValidationFailure OnlyOwnerCanUpgradeBuildingFailure() => new("OwnerId", $"Only owner can upgrade building.");
        public static ValidationFailure BuildingWithTypeAlreadyExistsFailure(string guildBuildingTypeId) => new("BuildingId", $"Building with type {guildBuildingTypeId} already exists.");
        public static ValidationFailure OnlyOwnerCanAddImprovementFailure() => new("OwnerId", $"Only owner can add improvement");
        public static ValidationFailure ImprovementWithGuildIdAndImprovementTypeIdAlreadyExistsFailure(int guildId, string guildImprovementTypeId) => new("GuildImprovement", $"Improvement with guildId {guildId} and ImprovementsTypeId {guildImprovementTypeId} already exists.");
        public static ValidationFailure LandWithIdDoesNotExistFailure(long landId) => new("LandId", $"Land with id {landId} doesn't exist.");
        public static ValidationFailure UserLandWithIdDoesNotExistFailure(long landId) => new("UserLandId", $"User land with id {landId} doesn't exist.");
        public static ValidationFailure LandWithIdDoesNotHaveAnyHeroFailure(long landId) => new("LandId", $"Land with id {landId} doesn't have any hero.");
        public static ValidationFailure LandWithIdHasWrongTypeFailure(long landId) => new("LandId", $"Land with id {landId} has wrong type.");
        public static ValidationFailure LandWithIdIsAlreadyExploredFailure(long landId) => new("LandId", $"Land with id {landId} is already explored.");
        public static ValidationFailure LandWithIdIsAlreadyDiscoveredFailure(long landId) => new("LandId", $"Land with id {landId} is already discovered.");
        public static ValidationFailure ImprovementWithLandIdAndImprovementTypeIdAlreadyExistsFailure(long landId, string improvementTypeId) => new("ImprovementId", $"Improvement with landId {landId} and ImprovementsTypeId {improvementTypeId} already exists.");
        public static ValidationFailure UserCannotInviteHimselfFailure() => new("UserId", $"User cannot invite himself.");
        public static ValidationFailure UserHasAlreadySentAnInvitationFailure() => new("UserId", $"User has already sent an invitation.");
        public static ValidationFailure GuildWithNameAlreadyExistsFailure(string guildName) => new("GuildName", $"Guild with name {guildName} already exists.");
        public static ValidationFailure UserWithIdAlreadyHasGuildFailure(int userId) => new("UserId", $"User with id {userId} already has guild.");
        public static ValidationFailure ItemWithIdDoesNotExistFailure(long itemId) => new("ItemId", $"Item with id {itemId} doesn't exist.");
        public static ValidationFailure ItemWithIdIsAlreadyAssignedFailure(long itemId) => new("ItemId", $"Item with id {itemId} is already assigned.");
        public static ValidationFailure ItemWithIdIsNotMintedFailure(long itemId) => new("ItemId", $"Item with id {itemId} is not minted.");
        public static ValidationFailure NpcWithIdDoesNotExistFailure(long npcId) => new($"NpcId", $"Npc with id {npcId} doesn't exist.");
        public static ValidationFailure TravelWithNpcWithIdExist(long npcId) => new($"NpcId", $"Npc with id {npcId} is already on the travel.");
        public static ValidationFailure TravelWithNpcWithIdNotExist(long npcId) => new($"NpcId", $"Npc with id {npcId} doesn't have any travel.");
        public static ValidationFailure NpcWithIdHasItemFailure(long npcId) => new($"NpcId", $"Npc with id {npcId} has item.");
        public static ValidationFailure UserDoesNotHaveGuildFailure() => new($"UserId", $"User doesn't have guild.");
        public static ValidationFailure UserIsNotGuildOwnerFailure() => new($"UserId", $"User isn't guild owner.");
        public static ValidationFailure NewOwnerDoesNotBelongToGuildFailure() => new($"NewOwnerId", $"New owner doesn't belong to the guild.");
        public static ValidationFailure UserWithIdDoesNotBelongToGuildFailure(int userId, string guildName) => new($"UserId", $"User with id {userId} doesn't belong to the guild {guildName}.");
        public static ValidationFailure AccountWithWalletAlreadyExistsFailure(string wallet) => new($"UserId", $"Account with wallet {wallet} already exists.");
        public static ValidationFailure NotificationWithWalletAlreadyExistsFailure(string wallet) => new($"NotificationId", $"Notification with wallet {wallet} already exists.");
        public static ValidationFailure NotificationWithEmailAlreadyExistsFailure(string email) => new($"NotificationId", $"Notification with email {email} already exists.");
        public static ValidationFailure NotificationWithEmailDoesNotExistFailure(string email) => new($"NotificationId", $"Notification with email {email} does not exist.");
        public static ValidationFailure PleaseWaitBeforeResend(int time) => new("ResendTime", $"Please wait {time} minutes before resending");
        public static ValidationFailure OnlyGuildOwnerCanDeclineInvitationFailure() => new($"InvitationId", $"Only guild owner can decline the invitation.");
        public static ValidationFailure OnlyUserFromInvitationCanDeclineFailure() => new($"InvitationId", $"Only user from invitation can decline.");
        public static ValidationFailure UserHasAlreadyBeenInvitedFailure() => new($"InvitedUserId", $"User has already been invited.");
        public static ValidationFailure InvitedUserDoesNotExistFailure() => new($"InvitedUserId", $"Invited user doesn't exist.");
        public static ValidationFailure InvitedUserIsAlreadyInGuildFailure() => new($"InvitedUserId", $"Invited user is already in guild.");
        public static ValidationFailure GuildBuildingWithIdDoesNotExistFailure(int guildBuildingId) => new($"BuildingId", $"Guild building with id {guildBuildingId} doesn't exist.");
        public static ValidationFailure GuildBuildingCannotBeUpgradedDueTolackOfImprovementFailure() => new($"Improvement", $"Guild building cannot be upgraded due to lack of improvements.");
        public static ValidationFailure GuildResourcesCouldNotBeFetchFailure() => new($"Resources", $"Guild resources could not be fetched.");
        public static ValidationFailure BuildingWithIdDoesNotExistFailure(long buildingId) => new($"BuildingId", $"Building with id {buildingId} doesn't exist.");
        public static ValidationFailure BuildingCannotBeUpgradedDueTolackOfImprovementFailure() => new($"Improvement", $"Building cannot be upgraded due to lack of improvements.");
        public static ValidationFailure UserResourcesCouldNotBeFetchedFailure() => new($"Resources", $"User resources could not be fetched.");
        public static ValidationFailure UserWithWalletAlreadyExistsFailure(string wallet) => new($"WalletAddress", $"User with wallet {wallet} already exists.");
        public static ValidationFailure UserWithEmailAlreadyExistsFailure(string email) => new($"EmailAddress", $"User with email {email} already exists.");
        public static ValidationFailure ActivationTokenIsInvalidOrHasExpiredFailure() => new($"Token", $"The activation token is invalid or has expired.");
        public static ValidationFailure LandFromNotBelongToUserFailure(long landFromId) => new($"LandFrom", $"Land from {landFromId} not belong to the user.");
        public static ValidationFailure LandToNotBelongToUserFailure(long landToId) => new($"LandTo", $"Land to {landToId} not belong to the user.");
        public static ValidationFailure LandFromMustBeTheSameAsNpcLandFailure() => new($"LandId", $"Land from must be the same as the npc land.");
        public static ValidationFailure NpcIsNotInAnyLand(long npcId) => new($"LandId", $"Npc with id {npcId} is not in any land.");
        public static ValidationFailure LandFromAndLandToMustBelongToTheSameLandInstanceFailure() => new($"Lands", $"Land from and land to must belong to the same land instance.");
        public static ValidationFailure UserCannotLeaveGuildHeOwnsFailure() => new($"UserId", $"User cannot leave the guild he owns.");
        public static ValidationFailure NpcWithIdIsBusy(long npcId) => new("NpcId", $"Npc with id {npcId} is busy.");
        public static ValidationFailure AnotherNpcIsOnAMissionOnThisLand() => new("LandId", $"Another npc is on a mission on this land.");
        public static ValidationFailure OwnFailure(string propertyName, string errorMessage) => new(propertyName, errorMessage);
    }
}
