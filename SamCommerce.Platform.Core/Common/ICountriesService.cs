using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.Common
{
    public interface ICountriesService
    {
        IList<Country> GetCountries();
        Task<IList<Country>> GetCountriesAsync();
        Task<IList<CountryRegion>> GetCountryRegionsAsync(string countryId);
        Country GetByCode(string code);
    }
}
