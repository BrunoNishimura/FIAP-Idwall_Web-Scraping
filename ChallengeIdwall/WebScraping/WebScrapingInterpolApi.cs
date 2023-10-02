using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ChallengeIdwall.WebScraping.WebScraping
{
    internal class WebScrapingInterpolApi
    {
        public static void Executar()
        {
            string url = "https://ws-public.interpol.int/notices/v1/red?nationality=CN&resultPerPage=160";

            using (IWebDriver driver = new ChromeDriver())
            {                
                driver.Navigate().GoToUrl(url);

                System.Threading.Thread.Sleep(5000);

                string htmlContent = driver.PageSource;

                HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(htmlContent);

                var links = htmlDoc.DocumentNode.SelectNodes("//a[@href]");
                if (links != null)
                {
                    foreach (var link in links)
                    {
                        string href = link.GetAttributeValue("href", "");
                        Console.WriteLine(href);
                    }
                }

                driver.Quit();
            }
        }
    }
}