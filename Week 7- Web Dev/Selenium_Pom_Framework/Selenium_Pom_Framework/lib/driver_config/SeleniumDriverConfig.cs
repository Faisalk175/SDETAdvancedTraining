using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SL_Pom_Framework_Test.lib.driver_config;

public class SeleniumDriverConfig<T> where T : IWebDriver, new()
{
    public IWebDriver SeleniumDriver { get; set; }
    public SeleniumDriverConfig(int pageLoadInSecs, int implicitWaitInSecs, bool headless)
    {

        SeleniumDriver = new T();

        //check driver is of valid type
        CheckDriverType();

        //check if headless is true or false
        if (headless) SetHeadless();

        // This is the time the driver will wait for the page to load
        SeleniumDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadInSecs);
        // This is the time the driver waits for the elements
        SeleniumDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitInSecs);
    }

    private void SetHeadless()
    {
        ChromeOptions options = new();
        options.AddArgument("headless");
        SeleniumDriver = new ChromeDriver(options);

    }

    private void CheckDriverType()
    {
        if (!(SeleniumDriver is ChromeDriver))
        {
            throw new ArgumentException("IWebDriver must be of type ChromeDriver");
        }
    }
}
