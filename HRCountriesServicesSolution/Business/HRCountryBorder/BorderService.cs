using HRCountriesServicesSolution.Constant;
using HRCountriesServicesSolution.DAL;
using HRCountriesServicesSolution.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// Border service Implementation
    /// No unit test as implementation is trivial
    /// </summary>
    public class BorderService : IBorderService
    {
        IHRCountryBorderRepository _repo = null;
        /// <summary>
        /// Dependancy injection by constructor.
        /// </summary>
        /// <param name="rep"></param>
        public BorderService(IHRCountryBorderRepository rep)
        {
            _repo = rep;
        }

        /// <summary>
        /// Get all Borders available.
        /// 1- If Repository is available return result
        /// 2- Else throw Exception.
        /// </summary>
        /// <returns>All Borders available</returns>
        public async Task<IEnumerable<HRCountryBorder>> GetBorderCountriesAsync()
        {
            //1-
            if (_repo != null)
            {
                return await _repo.GetBorderCountriesAsync();
            }
            else
            {
                //2-
                throw new Exception(HRCountriesServicesSolution.Constant.BOUNDARIES.BORDER_REPOSITORY_ERROR_DESCRIPTION);
            }
        }
        /// <summary>
        /// Get Border by alpha3Code
        /// 1- If Repository is available return result
        /// 2- Else throw Exception.
        /// </summary>
        /// <param name="alpha3Code">a Country Alpha3Code. e.g : 'FRA' foir France.</param>
        /// <returns>The HRCountryBorder with the corresponding Alpha3Code Country if exists.</returns>
        public async Task<HRCountryBorder> GetBorderCountriesByAlpha3CodeAsync(string alpha3Code)
        {
            //1-
            if (_repo != null)
            {
                return await _repo.GetBorderCountriesByAlpha3CodeAsync(alpha3Code);
            }
            else
            {
                //2-
                throw new Exception(HRCountriesServicesSolution.Constant.BOUNDARIES.BORDER_REPOSITORY_ERROR_DESCRIPTION);
            }
        }
    }
}