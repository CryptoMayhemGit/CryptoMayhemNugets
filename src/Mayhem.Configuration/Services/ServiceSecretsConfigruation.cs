namespace Mayhem.Configuration.Services
{
    public class ServiceSecretsConfigruation
    {
        public string JwtIssuer { get; set; }
        public string JwtAudience { get; set; }
        public string JwtKey { get; set; }
        public string ActivationTokenSecretKey { get; set; }
    }
}
