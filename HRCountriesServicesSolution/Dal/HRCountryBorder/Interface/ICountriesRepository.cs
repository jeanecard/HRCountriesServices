using HRCountriesServicesSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRCountriesServicesSolution.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICountriesRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alpha3Code"></param>
        /// <returns></returns>
        Task<CountryModel> GetCountryByAlpha3CodeAsync(string alpha3Code);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<CountryModel>> GetCountriesAsync();
    }
}
