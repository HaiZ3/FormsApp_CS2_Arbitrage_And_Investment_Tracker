using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Context;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Interfaces.IServices;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models.DTOs;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Models.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.Services
{
    public class CurrencyService : ICurrencyService
    {
        HttpClient _httpClient;
        CS2TrackerContext _context;
        public CurrencyService(HttpClient httpClient,CS2TrackerContext context)
        {
            _httpClient = httpClient;
            _context = context;
        }
        public async Task FetchCurrencyInfoAndSaveRates()
        {
            _httpClient.BaseAddress = new Uri("https://api.exchangerate-api.com/v4/latest/");

            const string usd = "USD";
            const string eur = "EUR";
            const string cny = "CNY";

            var usdInfo = _httpClient.GetFromJsonAsync<CurrencyInfoDto>(_httpClient.BaseAddress + usd).Result;
            var eurInfo = _httpClient.GetFromJsonAsync<CurrencyInfoDto>(_httpClient.BaseAddress + eur).Result;
            var cnyInfo = _httpClient.GetFromJsonAsync<CurrencyInfoDto>(_httpClient.BaseAddress + cny).Result;

            DateTime lastUpdate = usdInfo.Date;

            CurrencyInfo currencyInfoUsdToCny = new CurrencyInfo
            {
                FromCurrency = usd,
                ToCurrency = cny,
                ConversionRate = usdInfo.Rates[cny],
                LastUpdate = lastUpdate
            };

            CurrencyInfo currencyInfoUsdToEur = new CurrencyInfo
            {
                FromCurrency = usd,
                ToCurrency = eur,
                ConversionRate = usdInfo.Rates[eur],
                LastUpdate = lastUpdate
            };

            CurrencyInfo currencyInfoEurToCny = new CurrencyInfo
            {
                FromCurrency = eur,
                ToCurrency = cny,
                ConversionRate = eurInfo.Rates[cny],
                LastUpdate = lastUpdate
            };

            CurrencyInfo currencyInfoEurToUsd = new CurrencyInfo
            {
                FromCurrency = eur,
                ToCurrency = usd,
                ConversionRate = eurInfo.Rates[usd],
                LastUpdate = lastUpdate
            };

            CurrencyInfo currencyInfoCnyToUsd = new CurrencyInfo
            {
                FromCurrency = cny,
                ToCurrency = usd,
                ConversionRate = cnyInfo.Rates[usd],
                LastUpdate = lastUpdate
            };

            CurrencyInfo currencyInfoCnyToEur = new CurrencyInfo
            {
                FromCurrency = cny,
                ToCurrency = eur,
                ConversionRate = cnyInfo.Rates[eur],
                LastUpdate = lastUpdate
            };

            _context.CurrencyInfos.Add(currencyInfoUsdToCny);
            _context.CurrencyInfos.Add(currencyInfoUsdToEur);

            _context.CurrencyInfos.Add(currencyInfoEurToCny);
            _context.CurrencyInfos.Add(currencyInfoEurToUsd);

            _context.CurrencyInfos.Add(currencyInfoCnyToUsd);
            _context.CurrencyInfos.Add(currencyInfoCnyToEur);

            await _context.SaveChangesAsync();
        }
        public async Task RefreshRatesAsync()
        {
            _context.CurrencyInfos.RemoveRange(_context.CurrencyInfos);

            await _context.SaveChangesAsync();

            await FetchCurrencyInfoAndSaveRates();            
        }
    }
}
