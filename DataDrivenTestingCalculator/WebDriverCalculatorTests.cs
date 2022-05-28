using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace DataDrivenTestingCalculator
{
    public class WebDriverCalculatorTests
    {
        //private ChromeDriver driver;
        private FirefoxDriver driver;
        IWebElement field1;
        IWebElement field2;
        IWebElement operation;
        IWebElement calculate;
        IWebElement resultField;
        IWebElement clearField;

        [OneTimeSetUp]
        public void Setup()
        {
            //this.driver = new ChromeDriver();
            this.driver = new FirefoxDriver();
            driver.Url = "https://number-calculator.nakov.repl.co/";
            this.field1 = driver.FindElement(By.Name("number1"));
            this.field2 = driver.FindElement(By.Id("number2"));
            this.operation = driver.FindElement(By.Id("operation"));
            this.calculate = driver.FindElement(By.Id("calcButton"));
            this.resultField = driver.FindElement(By.Id("result"));
            this.clearField = driver.FindElement(By.Id("resetButton"));
        }

        [TestCase("5", "6", "+", "Result: 11")]
        [TestCase("15", "6", "-", "Result: 9")]
        [TestCase("2", "8", "*", "Result: 16")]
        [TestCase("2", "8", "*", "Result: 16")]
        [TestCase("2", "0", "/", "Result: Infinity")]
        [TestCase("2", "8", "no", "Result: invalid operation")]
        [TestCase("2", "no", "+", "Result: invalid input")]
        public void Test_Calkulator(string num1, string num2, string oper, string result)
        {
            field1.SendKeys(num1);
            operation.SendKeys(oper);
            field2.SendKeys(num2);
            calculate.Click();

            Assert.AreEqual(result, resultField.Text);

            clearField.Click();
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}