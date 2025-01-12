// ExchangeHelper.cs (or whatever name you want)
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace ExchangeApp
{
    public static class ExchangeHelper
    {
        public static async Task<List<CurrencyInfo>> GetExchangeRatesAsync()
        {
            var currencyList = new List<CurrencyInfo>();
            string url = "https://www.bankofalbania.org/Tregjet/Kursi_zyrtar_i_kembimit/";

            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string htmlContent = await response.Content.ReadAsStringAsync();

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlContent);

            var table = htmlDoc.DocumentNode
                .SelectSingleNode("//table[@class='table table-sm table-responsive w-100 d-block d-md-table table-bordered m-0']");

            if (table != null)
            {
                foreach (var row in table.SelectNodes(".//tr"))
                {
                    var cells = row.SelectNodes(".//td");
                    if (cells != null && cells.Count >= 3)
                    {
                        string currencyName = cells[0].InnerText.Trim();
                        string currencyCode = cells[1].InnerText.Trim();
                        string rateString = cells[2].InnerText.Trim();

                        if (double.TryParse(rateString, out double rate))
                        {
                            currencyList.Add(new CurrencyInfo
                            {
                                Name = currencyName,
                                Code = currencyCode,
                                Rate = rate
                            });
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Could not find the table with exchange rates.");
            }
            return currencyList;
        }
    }
}
