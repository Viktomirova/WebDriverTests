using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

// Create new Chrome browser instance
ChromeDriver driver = new ChromeDriver();

// Navigate to Wikipedia
driver.Url = "https://wikipedia.org";
Console.WriteLine("CURRENT DRIVER: " + driver.Title);

// Locate Search Field by ID
var searchField = driver.FindElement(By.Id("searchInput"));

// Click on element
searchField.Click();

// Fill "QA" and press ENTER keybord button
searchField.SendKeys("QA" + Keys.Enter);

Console.WriteLine("TITLE AFTER SEARCH: " + driver.Title);

// Close browser
driver.Quit();

