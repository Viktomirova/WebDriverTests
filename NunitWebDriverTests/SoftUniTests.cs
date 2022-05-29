using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NunitWebDriverTests
{
    public class SoftUniTests
    {
        private WebDriver driver;

        [SetUp]
        public void Setup_OpenBrowserAndNavigate()
        {
            var options = new ChromeOptions();
            options.AddArguments("--headless", "--window-size=1920,1200");
            this.driver = new ChromeDriver(options);
            driver.Url = "https://softuni.bg";
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void ShutDown()
        {
            driver.Close();
        }

        [Test]
        public void Test_Assert_Main_Page_Title()
        {
            IWebElement aboutElement = driver.FindElement(By.CssSelector("#page-header > div > div > div > div.logo.hover-dropdown-btn > a > img.desktop-logo.hidden-xs"));
            aboutElement.Click();
            string expectedTitle = "Обучение по програмиране - Софтуерен университет";
            Assert.AreEqual(expectedTitle, driver.Title);
        }

        [Test]
        public void Test_Assert_AboutAs_Title()
        {
            driver.FindElement(By.CssSelector("#page-footer > div > ul > li.col-md-3.col-sm-12.col-xs-12.footer-list-wrapper.about-us-container > ul > li:nth-child(1) > a")).Click();
            Assert.That(driver.Title, Is.EqualTo("За нас - Софтуерен университет"));
        }

        [Test]
        public void Test_Login_InvalidUserAndPassword()
        {
            driver.FindElement(By.CssSelector(".softuni-btn-primary")).Click();
            driver.FindElement(By.Id("username")).Click();
            driver.FindElement(By.Id("username")).SendKeys("Test1");
            driver.FindElement(By.Id("password-input")).Click();
            driver.FindElement(By.Id("password-input")).SendKeys("Test1");
            driver.FindElement(By.CssSelector(".softuni-btn")).Click();
            driver.FindElement(By.CssSelector("li")).Click();
            Assert.That(driver.FindElement(By.CssSelector("li")).Text, Is.EqualTo("Невалидно потребителско име или парола"));
        }

        [Test]
        public void Test_Search()
        {
            driver.FindElement(By.CssSelector("#search-icon-container > a > span > i")).Click();
            IWebElement searchField = driver.FindElement(By.CssSelector(".container > form #search-input"));
            searchField.Click();
            searchField.SendKeys("qa");
            searchField.SendKeys(Keys.Enter);
            IWebElement searchTitle = driver.FindElement(By.CssSelector(".search-title"));
            searchTitle.Click();
            Assert.That(searchTitle.Text, Is.EqualTo("Резултати от търсене на “qa”"));
        }
    }
}
