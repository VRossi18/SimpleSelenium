using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace SeleniumChrome
{
    class Program
    {
        private static IWebDriver _driver;
        static void Main(string[] args)
        {
            //Chrome options, there are a thousands of these, this one is just so the window starts maximized
            var options = new ChromeOptions();
            options.AddArguments("--start-maximized");

            //This block tells the driver which driver to use, the options variable needs to go in the parameters
            _driver = new ChromeDriver(options);
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));

            //Navigate to the url
            _driver.Navigate().GoToUrl("https:\\google.com");

            //Using wait to find a element
            wait.Until(x => x.FindElement(By.ClassName("gsfi"))).Click();
            wait.Until(x => x.FindElement(By.ClassName("gsfi"))).SendKeys("c# is awesome");

            wait.Until(x => x.FindElement(By.ClassName("gsfi"))).SendKeys(Keys.Enter);

            //getting a atribute of a a element , careful when using xpath method , all the "" should be replaced with ''
            var atribute = wait.Until(x => x.FindElement(By.ClassName("r"))).Text;
            var getAtribute = wait.Until(x => x.FindElement(By.XPath("//*[@id='rso']/div/div/div[1]/div/div/h3/a"))).GetAttribute("href");

            Console.WriteLine(atribute);
            Console.WriteLine(getAtribute);

            //close the browser page
            _driver.Close();
        }
    }
}
