using OpenQA.Selenium;

namespace SL_Pom_Framework_Test.lib.pages;

public class InventoryPage
{
    private IWebDriver _driver;

    public InventoryPage(IWebDriver seleniumDriver)
    {
        _driver = seleniumDriver;
    }
    public void VisitInventoryPage()
    {
        _driver.Navigate().GoToUrl(AppConfigReader.InventoryPageUrl);
        if (_driver.Url != AppConfigReader.InventoryPageUrl)
        {
            _driver.FindElement(By.Id("user-name")).SendKeys(AppConfigReader.UserName);
            _driver.FindElement(By.Id("password")).SendKeys(AppConfigReader.Password);
            _driver.FindElement(By.Id("login-button")).Click();
        }
    }

    public void AddSauceLabsBackpack()
    {
        var addItem = _driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        addItem.Click();
    }
    
    public void AddSauceLabsBikeLight()
    {
        var addItem = _driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));
        addItem.Click();
    }
    
    public void AddSauceLabsBoltTShirt()
    {
        var addItem = _driver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt"));
        addItem.Click();
    }    
    
    public void AddSauceLabsFleeceJacket()
    {
        var addItem = _driver.FindElement(By.Id("add-to-cart-sauce-labs-fleece-jacket"));
        addItem.Click();
    }    
    public void AddSauceLabsOnesie()
    {
        var addItem = _driver.FindElement(By.Id("add-to-cart-sauce-labs-onesie"));
        addItem.Click();
    }    
    

    public void AddAllItemsToCart()
    {
        AddSauceLabsBackpack();
        AddSauceLabsBikeLight();
        AddSauceLabsBoltTShirt();
        AddSauceLabsFleeceJacket();
        AddSauceLabsOnesie();
        
    }

    public string CartItemNumber()
    {
        var cartNumber = _driver.FindElement(By.ClassName("shopping_cart_badge"));
        return cartNumber.Text;
    }

    public void PressCartIcon()
    {
        _driver.FindElement(By.ClassName("shopping_cart_link")).Click();
    }
    
    public void RemoveSauceLabsBikeLightFromCart()
    {
        var removeItem = _driver.FindElement(By.Id("remove-sauce-labs-bike-light"));
        removeItem.Click();
    }    
    
    public void ContinueShopping()
    {
        _driver.FindElement(By.Id("continue-shopping")).Click();
    }
    
    public void Checkout()
    {
        _driver.FindElement(By.Id("checkout")).Click();
    }

    public void AddFirstName()
    {
        var firstnameField = _driver.FindElement(By.Id("first-name"));
        firstnameField.SendKeys("Faisal");
    }


    public void CheckoutContinue()
    {
        _driver.FindElement(By.Id("continue")).Click();
    }

    public string CheckoutContinueError()
    {
        var errorMessage = _driver.FindElement(By.ClassName("error-message-container")).FindElement(By.TagName("h3"));
        return errorMessage.Text;
    }
}
