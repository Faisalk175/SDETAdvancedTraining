using OpenQA.Selenium;
using SL_Pom_Framework_Test.lib.driver_config;

//Responsible for the driver and its behaviours

namespace SL_Pom_Framework_Test.lib.pages;

public class SL_Website<T> where T : IWebDriver, new()
{
    public IWebDriver SeleniumDriver { get; set; }
    public HomePage SL_HomePage { get; set; }
    public InventoryPage SL_InventoryPage { get; set; }

    public SL_Website(int pageLoadInSecs = 6, int implicitWaitInSecs = 2, bool headless = true)
    {
        var seleniumDriverConfig = new SeleniumDriverConfig<T>(pageLoadInSecs, implicitWaitInSecs, headless);
        SeleniumDriver = seleniumDriverConfig.SeleniumDriver;

        SL_HomePage = new HomePage(SeleniumDriver);

        SL_InventoryPage = new InventoryPage(SeleniumDriver);
    }
}
