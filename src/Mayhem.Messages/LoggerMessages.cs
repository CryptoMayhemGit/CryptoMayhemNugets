using System;

namespace Mayhem.Messages
{
    public class LoggerMessages
    {
        public static string HandlingCommand => "Handling command {CommandName} ({@Command}).";
        public static string CommandHandled => "----- Command {CommandName} handled.";
        public static string CommandHandledResponse => "----- Command {CommandName} handled - response: {@Response}.";
        public static string RegisteringMessageHandler => "Registering message handler.";
        public static string MessageHasNullOrEmptyBody => "Message has null or empty body.";
        public static string GettingBodyForMessage => "Getting body for message.";
        public static string NewTokenGenerated => "New token generated.";
        public static string GeneratingPackagesFailed => "Generating packages failed.";
        public static string GeneratingLandsFailed => "Generating lands failed.";
        public static string NotificationHasBeenSentToTeam => "Notification has been sent to the team.";
        public static string PublishMessageToQueueNotification => "Publish message to queue notification.";

        public static string GettingBlobFor(string name, string containerName) => $"Getting blob for {name} and container {containerName}";
        public static string GettingBlobsFor(string containerName) => $"Getting blobs for container {containerName}";
        public static string UploadingBlobFor(string name, string containerName) => $"Uploading blob for {name} and container {containerName}";
        public static string DeletingBlobFor(string name, string containerName) => $"Deleting blob for {name} and container {containerName}";

        public static string NotificationQueueValueIsNotNumeric(long notificationId) => $"Notification queue value {notificationId} is non-numeric.";
        public static string NotificationWithIdHasBeenSent(string encodedNotificationId) => $"Notification with id {encodedNotificationId} has been sent.";
        public static string UnableToSendNotificationWithId(string encodedNotificationId) => $"Unable to send notification with id {encodedNotificationId}.";

        public static string ErrorOccurredDuring(string actionName) => $"Error occurred during {actionName}.";
        public static string GettingInformationForBlocks(long blockTo, long blockFrom) => $"Gettings information for {blockTo} - {blockFrom} blocks.";
        public static string MessageBody(string body) => $"Message body {body}.";

        public static string ValidationError(string errorResponse) => $"Validation error: {errorResponse}.";
        public static string SendingMessageOfSubject(string subject, string to) => $"Sending message of subject {subject} to: {to}.";
        public static string MessageHandlerEncounteredException(Exception ex) => $"Message handler encountered an exception {ex}.";
        public static string ExceptionContextForTroubleshooting(string endpoint, string entityPath, string action) => $"Exception context for troubleshooting. Endpoint: {endpoint}, Entity Path: {entityPath}, Executing Action: {action}.";
        public static string SuccessfullyAddedItems(int itemsCount, int bonusesCount, long elapsedMilliseconds) => $"Successfully added {itemsCount} items and {bonusesCount} bonuses in {elapsedMilliseconds} miliseconds.";
        public static string SuccessfullyAddedLands(int landsCount, long elapsedMilliseconds) => $"Successfully added {landsCount} lands in {elapsedMilliseconds} miliseconds.";
        public static string SuccessfullyAddedNpcs(int npcsCount, int attributesCount, long elapsedMilliseconds) => $"Successfully added {npcsCount} npcs and {attributesCount} attributes in {elapsedMilliseconds} miliseconds.";
        public static string SuccessfullyGeneratedPackages(int packageCount, long elapsedMilliseconds) => $"Successfully generated {packageCount} packages with NftIds in {elapsedMilliseconds} miliseconds.";
        public static string SuccessfullyGeneratedLands(int landCount, long elapsedMilliseconds) => $"Successfully generated {landCount} lands in {elapsedMilliseconds} miliseconds.";
        public static string PublishMessageWith(int count, bool status) => $"Publish message with: {count} positions and status: {status}";

        public static string HttpGetAsJsonAsyncNoRequest(string requestUri) => $"HttpGetAsJsonAsyncNoRequest {requestUri}. Get request. Start.";
        public static string HttpGetAsJsonAsync(string requestUri) => $"HttpGetAsJsonAsync {requestUri}. Get request. Start.";
        public static string HttpClientHttpGetAsJsonAsyncNoRequestException => "HttpClient HttpGetAsJsonAsyncNoRequest exception.";
        public static string HttpClientHttpGetAsJsonAsyncException => "HttpClient HttpGetAsJsonAsync exception.";

        public static string HttpPostAsJsonAsyncNoRequest(string requestUri) => $"HttpPostAsJsonAsyncNoRequest {requestUri}. Post request. Start.";
        public static string HttpPostAsJsonAsync(string requestUri) => $"HttpPostAsJsonAsync {requestUri}. Post request. Start.";

        public static string HttpClientHttpPostAsJsonAsyncNoRequestException => "HttpClient HttpPostAsJsonAsyncNoRequest exception.";
        public static string HttpClientHttpPostAsJsonAsyncException => "HttpClient HttpPostAsJsonAsync exception.";

        public static string HttpPutAsJsonAsync(string requestUri) => $"HttpPutAsJsonAsync {requestUri}. Put request. Start.";
        public static string HttpClientHttpPutAsJsonAsyncException => $"HttpClient HttpPutAsJsonAsync exception.";

        public static string HttpDeleteAsJsonAsyncNoRequest(string requestUri) => $"HttpDeleteAsJsonAsyncNoRequest {requestUri}. Delete request. Start.";
        public static string HttpDeleteAsJsonAsync(string requestUri) => $"HttpDeleteAsJsonAsync {requestUri}. Delete request. Start.";
        public static string HttpClientHttpDeleteAsJsonAsyncNoRequestException => "HttpClient HttpDeleteAsJsonAsyncNoRequest exception.";
        public static string HttpClientHttpDeleteAsJsonAsyncException => "HttpClient HttpDeleteAsJsonAsync exception.";

        public static string HttpGetAsStreamAsync(string requestUri) => $"HttpGetAsStreamAsync {requestUri}. Get request. Start.";
        public static string HttpClientHttpGetAsStreamAsyncException => "HttpClient HttpGetAsStreamAsync exception.";
        public static string HttpPostAsStreamAsync(string requestUri) => $"HttpPostAsStreamAsync {requestUri}. Post request. Start.";
        public static string HttpClientHttpPostAsStreamAsyncException => "HttpClient HttpPostAsStreamAsync exception.";

        public static string ReceivedMessageFrom(string from, string to, string value) => $"Received message from: {from}, to: {to}, value: {value}.";

        public static string UpdatedNpcOwnerForWallet(string to, string value) => $"Updated npc's owner for wallet address: {to} and npc id {value}.";
        public static string CannotUpdateNpcOwnerForWallet(string to, string value) => $"Cannot update npc's owner for wallet address: {to} and npc id {value}.";
        public static string RemovedNpcOwnerFor(string value) => $"Removed npc's owner for npc id {value}.";
        public static string CannotRemoveNpcOwnerFor(string value) => $"Cannot remove npc's owner for npc id {value}.";

        public static string UpdatedItemOwnerForWallet(string to, string value) => $"Updated item's owner for wallet address: {to} and item id {value}.";
        public static string CannotUpdateItemOwnerForWallet(string to, string value) => $"Cannot update item's owner for wallet address: {to} and item id {value}.";
        public static string RemovedItemOwnerFor(string value) => $"Removed item's owner for item id {value}.";
        public static string CannotRemoveItemOwnerFor(string value) => $"Cannot remove item's owner for item id {value}.";

        public static string UpdatedLandOwnerForWallet(string to, string value) => $"Updated land's owner for wallet address: {to} and land id {value}.";
        public static string CannotUpdateLandOwnerForWallet(string to, string value) => $"Cannot update land's owner for wallet address: {to} and land id {value}.";
        public static string RemovedLandOwnerFor(string value) => $"Removed land's owner for land id {value}.";
        public static string CannotRemoveLandOwnerFor(string value) => $"Cannot remove land's owner for land id {value}.";

        public static string CannotFindNftNpcWithId(long id) => $"Cannot find nft npc with id = {id}.";
        public static string CannotFindNftItemWithId(long id) => $"Cannot find nft item with id = {id}.";
        public static string CannotFindNftLandWithId(long id) => $"Cannot find nft land with id = {id}.";
        public static string CannotFindNotificationWithId(long notificationId) => $"Cannot find notification with id = {notificationId}.";
        public static string CannotFindUserWithWallet(string walletAddress) => $"Cannot find user with wallet address = {walletAddress}.";

        public static string FoundMissionsCount(int count) => $"Found {count} missions.";
        public static string UpdatedUserLandWithDiscovered(int userId, long landId) => $"Updated userland with userId: {userId} and landId {landId}. Changed status to discovered.";
        public static string UpdatedUserLandWithExplored(int userId, long landId) => $"Updated userland with userId: {userId} and landId {landId}. Changed status to explored.";
        public static string AddedUserLandExplored(int userId, long landId) => $"Added userland with userId {userId}, landId {landId}, status explored.";
        public static string AddedUserLandDiscovered(int userId, long landId) => $"Added userland with userId {userId}, landId {landId}, status discovered.";
        public static string RemovedMissionWithId(long id) => $"Removed mission with id {id}.";
        public static string FoundTravelsCount(int count) => $"Found {count} travels.";
        public static string TravelFromLandToLandForNpcEndedUnhindered(long landFromId, long landToId, long npcId) => $"Travel from land {landFromId} to land {landToId} for npc {npcId} ended unhindered.";
        public static string TravelForNpcWithIdFinished(long npcId) => $"Travel for npc with id {npcId} finished.";
        public static string EnemyWasEncounteredNewPathCalculated() => "Enemy was encountered during the travel. New path has been calculated";
        public static string EnemyWasEncounteredNewPathImpossible() => "Enemy was encountered during the travel. New path impossible. Travel has ended";

    }
}
