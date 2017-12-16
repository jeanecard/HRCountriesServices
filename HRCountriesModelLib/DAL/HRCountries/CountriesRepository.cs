using HRCountriesServicesSolution.Models;
using System.Collections.Generic;

namespace HRCountriesServicesSolution.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class CountriesRepository : ICountriesRepository
    {
        CountriesStub _stub = null;
        /// <summary>
        /// 
        /// </summary>
        public CountriesRepository()
        {
            _stub = new CountriesStub();
            this.Reset();
            this.Initialize();
        }

        private List<CountryModel> _countries { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            this._countries = null;
        }
        /// <summary>
        /// 
        /// </summary>
        public void Initialize()
        {
            this._countries = CountriesStub.__countries;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CountryModel> GetCountries()
        {
            return this._countries;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alpha3Code"></param>
        /// <returns></returns>
        public CountryModel GetCountryByAlpha3Code(string alpha3Code)
        {
            CountryModel retour = null;
            if(_stub != null)
            {
                retour = _stub.GetCountryByAlpha3Code(alpha3Code);
            }
            return retour;
        }
    }
}
