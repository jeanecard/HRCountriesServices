using HRCountriesServicesSolution.DAL;
using HRCountriesServicesSolution.Models;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class CountriesService : ICountriesService
    {
        private ICountriesRepository _repo = null;
        /// <summary>
        /// 
        /// </summary>
        public CountriesService()
        {
            _repo = new CountriesRepository();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alpha3Code"></param>
        /// <returns></returns>
        public CountryModel GetCountryByAlpha3Code(string alpha3Code)
        {
            CountryModel retour = null;
            if(_repo != null)
            {
                retour = _repo.GetCountryByAlpha3Code(alpha3Code);
            }
            return retour;
        }
    }
}