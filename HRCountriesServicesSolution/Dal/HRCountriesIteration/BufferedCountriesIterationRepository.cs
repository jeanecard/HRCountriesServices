using System;
using System.Collections.Generic;
using HRCountriesServicesSolution.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GeoJSON.Net.Feature;
using System.Linq;

namespace HRCountriesServicesSolution.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class BufferedCountriesIterationRepository : ICountriesIterationRepository
    {
        static List<CountryModel> _countries = null;
        static Dictionary<string, CountriesIteration> _countriesMap = new Dictionary<string, CountriesIteration>();
        private Object _locker = new Object();
        private ITextContentGetter _contentGetter = null;
        /// <summary>
        /// Implementation of a local buffer of CountriesIteration.
        /// This class is used to enable a free deployment on Azure as accessing Azure DB is too expensive for only test reasons.
        /// </summary>
        public BufferedCountriesIterationRepository(ITextContentGetter contentGetter)
        {
            _contentGetter = contentGetter;
        }

        private async Task<bool> InitAsync()
        {

            if (_countries == null)
            {
                //Chargement des pays :
                String countriesFileText = await _contentGetter.GetCountriesData();
                lock (_locker)
                {
                    _countries = JsonConvert.DeserializeObject<List<CountryModel>>(countriesFileText);
                }
                String boundariesFileText = await _contentGetter.GetBoundariesData();
                lock (_locker)
                {
                    FeatureCollection fc = JsonConvert.DeserializeObject<FeatureCollection>(boundariesFileText);
                    //La première itération avec une clé vide ne renvoi pas de pays mais l'id de la prochaine itération.
                    CountriesIteration ct = new CountriesIteration();
                    ct.iterationKey = "1";
                    ct.finalItemsCount = _countries.Count;
                    _countriesMap.Add("", ct);
                    //La seconde itération renvoi les 20 premiers pays
                    ct = new CountriesIteration();
                    ct.iterationKey = "2";
                    ct.finalItemsCount = _countries.Count;
                    ct.countries = new List<CountryModel>();
                    for (int i = 0; i < 19; i++)
                    {
                        ct.countries.Add(_countries[i]);
                    }
                    _countriesMap.Add("1", ct);

                    //La seconde itération renvoi les 100 pays suivants
                    ct = new CountriesIteration();
                    ct.iterationKey = "3";
                    ct.finalItemsCount = _countries.Count;
                    ct.countries = new List<CountryModel>();
                    for (int i = 19; i < 120; i++)
                    {
                        ct.countries.Add(_countries[i]);
                    }
                    _countriesMap.Add("2", ct);

                    //La dernière itération renvoi  le reste.
                    ct = new CountriesIteration();
                    ct.finalItemsCount = _countries.Count;
                    ct.iterationKey = "";
                    ct.countries = new List<CountryModel>();
                    for (int i = 120; i < ct.finalItemsCount; i++)
                    {
                        ct.countries.Add(_countries[i]);
                    }
                    _countriesMap.Add("3", ct);
                }
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<CountriesIteration> GetCountrieIterationAsync(String Id)
        {
            await InitAsync();
            return GetCountrieIteration(Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        public async Task<CountriesIteration> GetCountriesIterationByRegionAsync(string Id)
        {
            await InitAsync();

            CountriesIteration retour = new CountriesIteration();
            retour.countries = new List<CountryModel>();
            retour.finalItemsCount = 0;
            retour.iterationKey = String.Empty;
            if (!String.IsNullOrEmpty(Id))
            {
                String idToLower = Id.ToLower();
                foreach (String iterKey in _countriesMap.Keys)
                {
                    CountriesIteration countriesIteration = _countriesMap[iterKey];
                    if (countriesIteration.countries != null)
                    {
                        IEnumerable<CountryModel> countriesinRegion = from countryCandidate in countriesIteration.countries
                                                                      where (countryCandidate.region != null && idToLower.CompareTo(countryCandidate.region.ToLower()) == 0)
                                                                      select countryCandidate;

                        foreach (CountryModel countryIterator in countriesinRegion)
                        {
                            retour.countries.Add(countryIterator);
                        }
                    }
                }
                retour.finalItemsCount = retour.countries.Count;
            }
            return retour;
        }

        private CountriesIteration GetCountrieIteration(String iterationKey)
        {

            String key = iterationKey;
            if (key == null)
                key = String.Empty;
            if (_countriesMap.Keys.Contains(key))
            {
                return _countriesMap[key];
            }
            return null;
        }
    }
}