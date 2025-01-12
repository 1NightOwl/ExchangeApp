using System;
using System.Collections.Generic;

public class CurrencyConverter
{
    public double Convert(string fromCurrency, string toCurrency, double amount, Dictionary<string, double> exchangeRates)
    {
        if (!exchangeRates.ContainsKey(fromCurrency) || !exchangeRates.ContainsKey(toCurrency))
        {
            throw new Exception("Currency not supported.");
        }

        double fromRate = exchangeRates[fromCurrency];
        double toRate = exchangeRates[toCurrency];

        // Convert the amount
        double convertedAmount = (amount / fromRate) * toRate;
        return convertedAmount;
    }
}
