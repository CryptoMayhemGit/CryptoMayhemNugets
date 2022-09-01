namespace Mayhem.Messages
{
    public static class NotificationMessages
    {
        public const string AdriaWelcomeMessage = "AdriaMail: Thank you for joining the galactic mission";

        public static string NotificationError => $"Notification error";

        public static string UnableToSendNotificationWithId(int id) => $"Unable to send notification with id = {id}";
    }
}
