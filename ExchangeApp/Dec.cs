//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ExchangeApp
//{
//    internal class Dec
//    {
//        public void Start(Dictionary<string, double> exchangeRates)
//        {
//            CurrencyConverter converter = new CurrencyConverter();
//            Console.WriteLine();
//            Console.WriteLine("==============================================");
//            Console.WriteLine("Welcome to the exchange\a");
//            Console.WriteLine("==============================================");

//            try
//            {
//                Console.WriteLine();
//                Console.WriteLine("Please enter the currency you are converting from: ");
//                Console.Write(">");
//                string fromCurrency = Console.ReadLine().ToUpper();
//                Console.WriteLine("Please enter the currency you are converting to: ");
//                Console.Write(">");
//                string toCurrency = Console.ReadLine().ToUpper();
//                Console.WriteLine("Enter the ammount: ");
//                Console.Write(">");
//                double amount = double.Parse(Console.ReadLine());

//                double convertedAmount = converter.Convert(fromCurrency, toCurrency, amount, exchangeRates);

//                Console.WriteLine($"The exchanged ammount is: {convertedAmount} {toCurrency}\a \a");

//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error: {ex.Message}");
//            }

//        }
//    }
//}
