using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Selenium3.Pages
{
    public class ProductsPage
    {
        private IWebDriver webdriver;

        public ProductsPage(IWebDriver webdriver)
        {
            this.webdriver = webdriver;
        }

        // Locators      
        By locatorProductsText = By.ClassName("title");

        #region Gets
        public string GetProductsText()
        {
            return webdriver.FindElement(locatorProductsText).Text;
        }

        public string GetProductsTextExplicitWait()
        {
            // Thread.Sleep(2000);
            WebDriverWait wait = new WebDriverWait(webdriver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locatorProductsText));
            return element.Text;
        }
        #endregion

    }
}
