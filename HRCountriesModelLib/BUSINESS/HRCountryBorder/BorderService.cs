using HRCountriesServicesSolution.DAL;
using HRCountriesServicesSolution.Models;
using System.Collections.Generic;
namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class BorderService : IBorderService
    {
        IHRCountryBorderRepository _repo = new HRCountryBorderRepository(); //!Injection
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<HRCountryBorder> GetBorderCountries()
        {
            return _repo.GetBorderCountries();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alpha3Code"></param>
        /// <returns></returns>
        public HRCountryBorder GetBorderCountriesByAlpha3Code(string alpha3Code)
        {
            return _repo.GetBorderCountriesByAlpha3Code(alpha3Code);
        }
    }
}