using HRCountriesServicesSolution.Models;
using System;
using System.Collections.Generic;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBorderService
    {
        /// <summary>
        /// 
        /// </summary>
        IEnumerable<HRCountryBorder> GetBorderCountries();
        /// <summary>
        /// 
        /// </summary>
        HRCountryBorder GetBorderCountriesByAlpha3Code(String alpha3Code);
    }
}