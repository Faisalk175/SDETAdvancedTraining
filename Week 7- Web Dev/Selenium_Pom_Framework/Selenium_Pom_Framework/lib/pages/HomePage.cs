using OpenQA.Selenium;

namespace SL_Pom_Framework_Test.lib.pages;

public class HomePage
{
    private IWebDriver _driver;

    #region web elements
    // move my elements to private fields so I can reuse them
    #endregion

    public HomePage(IWebDriver seleniumDriver)
    {
        _driver = seleniumDriver;
    }
    public void VisitHomePage()
    {
        _driver.Navigate().GoToUrl(AppConfigReader.BaseUrl);
    }

    public void ClickLoginButton()
    {
        var loginButton = _driver.FindElement(By.Id("login-button"));
        loginButton.Click();
    }

    public void EnterPassword(string password)
    {
        var passwordElement = _driver.FindElement(By.Id("password"));
        passwordElement.SendKeys(password);
    }

    public void EnterUserName(string userName)
    {
        var userNameElement = _driver.FindElement(By.Id("user-name"));
        userNameElement.SendKeys(userName);
    }

    public string GetErrorMessage()
    {
        var errorMessage = _driver.FindElement(By.ClassName("error-message-container")).FindElement(By.TagName("h3"));
        return errorMessage.Text;
    }
}
