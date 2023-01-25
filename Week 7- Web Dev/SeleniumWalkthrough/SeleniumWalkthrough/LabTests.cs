using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace SeleniumWalkthrough;

public class LabTests
{

    

    [Test]
    [Category("Login")]
    public void GivenIamOnHomepage_WhenIClickAndHoldBoxAAndDragItTowardsB_ThenTheyShouldSwapPlaces()
    {
        //Scenario: Successful login with valid email and password
        //Given the user is on the login page
        //When the user enters a valid email and password
        //And clicks the login button
        //Then the user should be taken to the secure page

        //setup headless driver
        var options = new ChromeOptions();
        options.AddArgument("headless");
        //use the web driver
        using (IWebDriver driver = new ChromeDriver())
        {

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

            //grab the username field
            var userNameField = driver.FindElement(By.Id("username"));

            // enter useername into it
            userNameField.SendKeys("tomsmith");

            //grab the password into it
            var passwordField = driver.FindElement(By.Id("password"));

            //Enter password into it
            passwordField.SendKeys("SuperSecretPassword!");

            //click the sign in button
            driver.FindElement(By.ClassName("radius")).Click();

            //Asssert that we are not on the sign in page
            Assert.That(driver.Url, Is.EqualTo("https://the-internet.herokuapp.com/secure"));

        }


    }

    [Test]
    [Category("Successful redirector")]
    public void GivenIamOnTheRedirectorPage_WhenIClickTheLink_ThenIShouldBeRedirected()
    {
        //Scenario: Successful redirection when clicking "here" to trigger a redirect
        //Given the user is on the redirector page
        //When the user clicks "here"
        //Then the user should be redirected to a status codes page

        //setup headless driver
        var options = new ChromeOptions();
        options.AddArgument("headless");
        //use the web driver
        using (IWebDriver driver = new ChromeDriver(options))
        {

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/redirector");

            //Click the redirect link
            driver.FindElement(By.Id("redirect")).Click();

            //Asssert that we are not on the sign in page
            Assert.That(driver.Url, Is.EqualTo("https://the-internet.herokuapp.com/status_codes"));

        }
    }

    [Test]
    [Category("404 status code")]
    public void GivenIamOnTheStatusCodePage_WhenIClickThe404Button_ThenIShouldBeSentToA404StatusCodePage()
    {
       //Scenario: Navigating to 404 page
       //Given the user is on the status code page
       //When the user clicks on the link for status code 404
       //Then the user should be taken to the 404 error page

        //setup headless driver
        var options = new ChromeOptions();
        options.AddArgument("headless");
        //use the web driver
        using (IWebDriver driver = new ChromeDriver(options))
        {

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/status_codes");

            //Click the redirect link
            driver.FindElement(By.ClassName("example")).FindElement(By.LinkText("404")).Click();

            //Asssert that we are not on the sign in page
            Assert.That(driver.Url, Is.EqualTo("https://the-internet.herokuapp.com/status_codes/404"));

        }
    }

    [Test]
    [Category("Option 1 from list")]
    public void GivenIamOnTheDrowdownPage_WhenISelectOption1FromTheList_ThenIShouldSeeOption1()
    {
        //Scenario: Selecting option 1 from the dropdown list
        //Given the user is on the dropdown page
        //When the user clicks on the dropdownlist
        //Then the user should be able to select option 1 from the list

        //setup headless driver
        var options = new ChromeOptions();
        options.AddArgument("headless");
        //use the web driver
        using (IWebDriver driver = new ChromeDriver(options))
        {

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dropdown");

            
            var dropdown = driver.FindElement(By.Id("dropdown"));


            // Find all the options in the dropdown
            var options1 = dropdown.FindElements(By.TagName("option"));

            // Find option 1 in the list of options
            var option1 = options1.First(o => o.GetAttribute("value") == "1");

            // Select option 1
            option1.Click();

            // Assert that option 1 is selected
            Assert.That(option1.Text, Is.EqualTo("Option 1"));
        }
    }

    [Test]
    [Category("Error")]
    public void GivenIamOnTheForgotPasswordPage_WhenIInputAnInvalidEmail_ThenAnErrorWillBeDisplayed()
    {
        //Scenario: Entering an invalid email will give an error
        //Given the user is on the forgot passoword page
        //When the user enters an invalid email
        //Then the user will be directed to an error page

        //setup headless driver
        var options = new ChromeOptions();
        options.AddArgument("headless");
        //use the web driver
        using (IWebDriver driver = new ChromeDriver(options))
        {

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/forgot_password");


            var email = driver.FindElement(By.Id("email"));

            email.SendKeys("ffdf");

            // Click retrieve password button
            driver.FindElement(By.ClassName("radius")).Click();

            var error = driver.FindElement(By.TagName("h1")).Text;

            // Assert that option 1 is selected
            Assert.That(error, Is.EqualTo("Internal Server Error"));
        }
    }


}

