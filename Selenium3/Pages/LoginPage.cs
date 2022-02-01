using OpenQA.Selenium;

namespace Selenium3.Pages
{
    public class LoginPage
    {
        private IWebDriver webdriver;

        public LoginPage(IWebDriver webdriver)
        {
            this.webdriver = webdriver;
        }

        // Locators
        By locatorUsernameInput     = By.Id("user-name");
        By locatorPasswordInput     = By.Id("password");
        By locatorLoginButton       = By.Id("login-button");

        #region SendKeys
        public void SendKeysToUsernameTextField(string username)
        {
            webdriver.FindElement(locatorUsernameInput).SendKeys(username);
        }

        public void SendKeysToPasswordTextField(string password)
        {
            webdriver.FindElement(locatorPasswordInput).SendKeys(password);
        }
        #endregion

        #region Clicks
        public void ClickOnTheLoginButton()
        {
            webdriver.FindElement(locatorLoginButton).Click();
        }
        #endregion

    }
}