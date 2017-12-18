using HRCountriesServicesSolution.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRCountriesServicesSolution.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHRCountryBorderRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<HRCountryBorder>> GetBorderCountriesAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alpha3Code"></param>
        /// <returns></returns>
        Task<HRCountryBorder> GetBorderCountriesByAlpha3CodeAsync(string alpha3Code);
    }
}
