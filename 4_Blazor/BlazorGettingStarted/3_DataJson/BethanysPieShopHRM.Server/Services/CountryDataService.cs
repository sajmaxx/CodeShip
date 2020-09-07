using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Server.Services
{
    public class CountryDataService : ICountryDataService
    {
        private readonly HttpClient _httpclienta;

        public CountryDataService(HttpClient httpclienta)
        {
            _httpclienta = httpclienta;
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Country>>
                (await _httpclienta.GetStreamAsync($"api/country"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Country> GetCountryById(int countryId)
        {
            return await JsonSerializer.DeserializeAsync<Country>
                (await _httpclienta.GetStreamAsync($"api/country{countryId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
