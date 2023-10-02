using System;
using System.Collections.Generic;

using ChallengeIdwall.WebScraping.WebScraping;

namespace CursoCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var central = new ChallengeIdwall.WebScraping.ControlWebScraping(new Dictionary<string, Action>()
            {
                //Section 3 - Fundamentos
                {"Executar WebScraping - Web FBI", WebScrapingFBI.Executar},
                {"Executar WebScraping - Web Interpol", WebScrapingInterpol.Executar},
                {"Executar WebScraping - API Interpol", WebScrapingInterpolApi.Executar},
            });

            central.SelecionarEExecutar();
        }
    }
}