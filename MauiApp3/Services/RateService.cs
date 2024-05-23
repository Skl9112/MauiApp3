using MauiApp3;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class RateService : IRateService
{
    private readonly HttpClient _httpClient;

    public RateService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Rate>> GetRates(DateTime date)
    {
        string url = $"https://www.nbrb.by/api/exrates/rates?ondate={date:yyyy-MM-dd}&periodicity=0";
        return await _httpClient.GetFromJsonAsync<IEnumerable<Rate>>(url);
    }
}
