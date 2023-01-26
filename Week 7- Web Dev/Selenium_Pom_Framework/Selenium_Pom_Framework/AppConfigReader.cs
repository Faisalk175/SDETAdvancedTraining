using System.Configuration;

namespace SL_Pom_Framework_Test;

public static class AppConfigReader
{
    public static readonly string BaseUrl = ConfigurationManager.AppSettings["BaseUrl"];
    public static readonly string InventoryPageUrl = ConfigurationManager.AppSettings["InventoryPageUrl"];
    public static readonly string CartPage = ConfigurationManager.AppSettings["CartPage"];
    public static readonly string UserName = ConfigurationManager.AppSettings["UserName"];
    public static readonly string Password = ConfigurationManager.AppSettings["Password"];
}
