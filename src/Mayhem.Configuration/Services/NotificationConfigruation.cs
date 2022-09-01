namespace Mayhem.Configuration.Services
{
    public class NotificationConfigruation
    {
        public string SmtpSenderName { get; set; }
        public string SmtpSenderAddress { get; set; }
        public string AdriaTeamAddress { get; set; }
        public bool StartTls { get; set; }
        public string SmtpHostAddress { get; set; }
        public int SmtpHostPort { get; set; }
        public string SmtpHostUser { get; set; }
        public string SmtpHostPass { get; set; }
        public string ContactEmail { get; set; }
    }
}
