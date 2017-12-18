using HRCountriesServicesSolution.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;

namespace HRCountriesServicesSolution.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class BufferedCountriesRepository : ICountriesRepository
    {
        static List<CountryModel> _countries = null;
        private Object _locker = new Object();
        private ITextContentGetter _contentGetter = null;
        /// <summary>
        /// default dummy constructor.
        /// </summary>
        public BufferedCountriesRepository(ITextContentGetter contentGetter)
        {
            _contentGetter = contentGetter;
        }

        private async Task<bool> InitAsync()
        {
            if (_countries == null)
            {
                String countriesFileText = await _contentGetter.GetCountriesData();
                lock (_locker)
                {
                    _countries = JsonConvert.DeserializeObject<List<CountryModel>>(countriesFileText);
                }
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<CountryModel>> GetCountriesAsync()
        {
            await InitAsync();
            return _countries;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alpha3Code"></param>
        /// <returns></returns>
        public async Task<CountryModel> GetCountryByAlpha3CodeAsync(String alpha3Code)
        {
            await InitAsync();
            CountryModel retour = null;
            if (!String.IsNullOrEmpty(alpha3Code))
            {
                foreach (CountryModel iterator in _countries)
                {
                    if (iterator.alpha3Code == alpha3Code)
                    {
                        retour = iterator;
                        break;
                    }
                }
            }
            return retour;
        }
    }
}
