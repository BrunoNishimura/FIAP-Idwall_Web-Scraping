using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ChallengeIdwall.WebScraping.WebScraping
{
    internal class WebScrapingFBI
    {
        public static void Executar()
        {
            using (var driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://www.fbi.gov/wanted/fugitives");

                ScrollToBottom(driver);

                var nameElements = driver.FindElements(By.XPath("//p[@class='name']"));

                if (nameElements.Count > 0)
                {
                    foreach (var element in nameElements)
                    {
                        Console.WriteLine(element.Text.Trim());
                    }
                }
                else
                {
                    Console.WriteLine("Não foi possível encontrar os nomes dos fugitivos.");
                }
            }
        }

        static void ScrollToBottom(IWebDriver driver)
        {
            var lastHeight = ((IJavaScriptExecutor)driver).ExecuteScript("return document.body.scrollHeight");

            while (true)
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
                Thread.Sleep(10000);

                var newHeight = ((IJavaScriptExecutor)driver).ExecuteScript("return document.body.scrollHeight");

                if (newHeight.Equals(lastHeight))
                {
                    break;
                }

                lastHeight = newHeight;
            }
        }
    }
}
