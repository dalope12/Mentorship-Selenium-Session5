using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;

namespace Selenium3
{
    public class Tests
    {
        IWebDriver webdriver;

        [SetUp]
        public void Setup()
        {
            webdriver = new ChromeDriver("C:\\Drivers\\mentor\\");
            webdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test, Category("Regression"), Category("Production"), Category("Stage"), Category("Test"), TestCaseSource("TestUsers")]
        [Author("Daniel Lopez")]
        public void FirstTest(string username)
        {
            // Locators
            By locatorUsernameInput     = By.Id("user-name");
            By locatorPasswordInput     = By.Id("password");
            By locatorLoginButton       = By.Id("login-button");
            By locatorProductsText      = By.ClassName("title");

            // URL
            webdriver.Url = "https://www.saucedemo.com/";
            string password = "secret_sauce";

            // Login
            webdriver.FindElement(locatorUsernameInput).SendKeys(username);
            webdriver.FindElement(locatorPasswordInput).SendKeys(password);
            webdriver.FindElement(locatorLoginButton).Click();

            // Product            
            Assert.That(webdriver.FindElement(locatorProductsText).Text.Equals("PRODUCTS"), $"The products text is: {webdriver.FindElement(locatorProductsText)}");

            // Get the page title text.
            var titleText = webdriver.Title;
            var expectedTitleText = "Swag Labs";

            // Assert that the title of the page contains "Swag Labs" text.
            Assert.That(titleText.Contains(expectedTitleText), $"The page title does not contain '{expectedTitleText}', instead contains : {titleText}");
        }

        [Test, Category("Regression"), Category("Production"), Category("Stage"), Category("Test"), TestCaseSource("TestUsers")]
        [Author("Daniel Lopez")]
        public void SecondTest(string username)
        {
            // URL
            webdriver.Url = "https://www.saucedemo.com/";
            string password = "secret_sauce";

            // Login
            var loginPage = new Pages.LoginPage(webdriver);
            loginPage.SendKeysToUsernameTextField(username);
            loginPage.SendKeysToPasswordTextField(password);
            loginPage.ClickOnTheLoginButton();

            // Product
            var productsPage = new Pages.ProductsPage(webdriver);
            Assert.That(productsPage.GetProductsText().Equals("PRODUCTS"), $"The products text is: {productsPage.GetProductsText()}");

            // Get the page title text.
            var titleText = webdriver.Title;

            // Assert that the title of the page contains "Swag Labs" text.
            Assert.That(titleText.Contains("Swag Labs"), $"The page title does not contain 'Swag Labs', instead contains : {titleText}");
        }

        [TearDown]
        public void CloseBrowser()
        {
            // Close the driver instance.
            webdriver.Close();
            webdriver.Quit();
        }

        public static IEnumerable TestUsers
        {
            get
            {
                yield return "standard_user";
                yield return "locked_out_user";
                yield return "problem_user";
                yield return "performance_glitch_user";
            }
        }
    }
}