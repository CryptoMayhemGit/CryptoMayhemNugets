using System.Collections.Generic;

namespace Mayhem.Configuration.Classes
{
    public static class ConfigurationTypes
    {
        public static List<string> Configurations => new()
        {
            "Development",
            "Production"
        };
    }
}
