using System.Configuration;

namespace APIClientApp;

internal class AppConfigReader
{
    public static readonly string BaseUrl = ConfigurationManager.AppSettings["base_url"];
}
