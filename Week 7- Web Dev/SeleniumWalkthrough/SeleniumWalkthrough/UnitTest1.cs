using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWalkthrough;

public class Tests
{
    

    [Test]
    [Category("Happy")]
    public void GivenIamOnHomepage_WhenIEnterValidEmailAndPassword_TheIShouldLandOntTheInventoryPage()
    {
        //setup headless driver
        var options = new ChromeOptions();
        options.AddArgument("headless");
        //use the web driver
        using (IWebDriver driver = new ChromeDriver())
        {

            driver.Manage().Window.Maximize();
            //navigate to saucedemo.com in the driver
            driver.Navigate().GoToUrl("https://www.saucedemo.com");

            //grab the username field
            var userNameField = driver.FindElement(By.Id("user-name"));

            // enter useername into it
            userNameField.SendKeys("standard_user");

            //grab the password into it
            var passwordField = driver.FindElement(By.Id("password"));

            //Enter password into it
            passwordField.SendKeys("secret_sauce");

            Thread.Sleep(2000);

            //click the sign in button
            driver.FindElement(By.Id("login-button")).Click();
            Thread.Sleep(2000);

            //Asssert that we are not on the sign in page
            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));



        }



     }

    [Test]
    [Category("sad")]
    public void GivenIamOnHomepage_WhenIEnterANInvalidEmailAndValidPassword_TheIShouldStayOnLoginPage()
    {
        using (IWebDriver driver = new ChromeDriver())
        {

            driver.Manage().Window.Maximize();
            //navigate to saucedemo.com in the driver
            driver.Navigate().GoToUrl("https://www.saucedemo.com");

            //grab the username field
            var userNameField = driver.FindElement(By.Id("user-name"));

            // enter useername into it
            userNameField.SendKeys("standard_ussdfsd");

            //grab the password into it
            var passwordField = driver.FindElement(By.Id("password"));

            //Enter password into it
            passwordField.SendKeys("secret_sauce");

            Thread.Sleep(2000);

            //click the sign in button
            driver.FindElement(By.Id("login-button")).Click();
            Thread.Sleep(2000);

            //Asssert that we are not on the sign in page
            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"));



        }
    }
}