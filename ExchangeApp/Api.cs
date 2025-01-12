using System;
using System.Net.Http;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

class Api
{
    static async System.Threading.Tasks.Task Main(string[] args)
    {
        using HttpClient client = new HttpClient();
        string url = "https://www.bankofalbania.org/Tregjet/Kursi_zyrtar_i_kembimit/";
        var exchangeRates = new Dictionary<string, double>();

        try
        {
            // Fetch the HTML content
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string htmlContent = await response.Content.ReadAsStringAsync();

            // Load the HTML into HtmlAgilityPack
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlContent);

            // Find the table containing exchange rates
            var table = htmlDoc.DocumentNode.SelectSingleNode("//table[@class='table table-sm table-responsive w-100 d-block d-md-table table-bordered m-0']");

            if (table != null)
            {
                Console.WriteLine("Exchange Rates:\n");

                // Iterate over table rows
                foreach (var row in table.SelectNodes(".//tr"))
                {
                    var cells = row.SelectNodes(".//td");
                    if (cells != null && cells.Count >= 3) // Ensure row has enough cells
                    {
                        string currencyName = cells[0].InnerText.Trim();
                        string currencyCode = cells[1].InnerText.Trim();
                        string rateString = cells[2].InnerText.Trim();

                        if (double.TryParse(rateString, out double rate))
                        {
                            exchangeRates[currencyCode] = rate; // Store the rate in the dictionary
                            Console.WriteLine($"{currencyName} ({currencyCode}): {rate}");
                        }
                    }
                }


                //var dec = new ExchangeApp.Dec();
                //dec.Start(exchangeRates);

            }
            else
            {
                Console.WriteLine("Could not find the table with exchange rates.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

}
