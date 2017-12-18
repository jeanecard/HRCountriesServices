using HRCountriesServicesSolution.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// Border service Interface
    /// </summary>
    public interface IBorderService
    {
        /// <summary>
        /// Get all Borders available
        /// </summary>
        /// <returns>All Borders available</returns>
        Task<IEnumerable<HRCountryBorder>> GetBorderCountriesAsync();

        /// <summary>
        /// Get Border by alpha3Code
        /// </summary>
        /// <param name="alpha3Code">a Country Alpha3Code. e.g : 'FRA' foir France.</param>
        /// <returns>The HRCountryBorder with the corresponding Alpha3Code Country if exists.</returns>
        Task<HRCountryBorder> GetBorderCountriesByAlpha3CodeAsync(String alpha3Code);
    }
}

