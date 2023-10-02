using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ChallengeIdwall.WebScraping.WebScraping
{
    internal class WebScrapingInterpol
    {
        public static void Executar()
        {
            using (var driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://www.interpol.int/How-we-work/Notices/View-Red-Notices");

                ScrollToBottom(driver);

                var nameElements = driver.FindElements(By.XPath("//a[@class='redNoticeItem__labelLink']"));

                if (nameElements.Count > 0)
                {
                    foreach (var element in nameElements)
                    {
                        string[] nameParts = element.Text.Trim().Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                        if (nameParts.Length >= 2)
                        {
                            string firstName = nameParts[0].Trim();
                            string lastName = nameParts[1].Trim();
                            Console.WriteLine($"{firstName} {lastName}");
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível encontrar o nome e sobrenome.");
                        }
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
                System.Threading.Thread.Sleep(2000);

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