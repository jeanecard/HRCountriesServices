using GeoJSON.Net.Feature;
using HRCountriesServicesSolution.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace HRCountriesServicesSolution.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class leGrosStub
    {
        static List<CountryModel> __countries = null;
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, CountriesIteration> __data = new Dictionary<string, CountriesIteration>();
        /// <summary>
        /// 
        /// </summary>
        public leGrosStub()
        {
            if (__countries == null)
            {
                //Chargement des pays :
                string path = HttpContext.Current.Server.MapPath("~/App_Data/allCountries.json");
                string boundariesPath = HttpContext.Current.Server.MapPath("~/App_Data/Boundaries.json");
                __countries = JsonConvert.DeserializeObject<List<CountryModel>>(File.ReadAllText(path));
                FeatureCollection fc = JsonConvert.DeserializeObject<FeatureCollection>(File.ReadAllText(boundariesPath));
                
           }
            //La première itération avec une clé vide ne renvoi pas de pays mais l'id de la prochaine itération.
            CountriesIteration ct = new CountriesIteration();
            ct.iterationKey = "1";
            ct.finalItemsCount = __countries.Count;
            __data.Add("", ct);

            //La seconde itération renvoi les 20 premiers pays
            ct = new CountriesIteration();
            ct.iterationKey = "2";
            ct.finalItemsCount = __countries.Count;
            ct.countries = new List<CountryModel>();
            for (int i = 0; i < 19; i++)
            {
                ct.countries.Add(__countries[i]);
                //ct.countries.Add(new Country { alpha3Code = "AFG", name = "Afghanistan", capital = "Kabuuul", flag = "https://restcountries.eu/data/afg.svg", latlng = new float[2] { 33.0f, 65.0f } });
            }
            __data.Add("1", ct);

            //La seconde itération renvoi les 100 pays suivants
            ct = new CountriesIteration();
            ct.iterationKey = "3";
            ct.finalItemsCount = __countries.Count;
            ct.countries = new List<CountryModel>();
            for (int i = 19; i < 120; i++)
            {
                ct.countries.Add(__countries[i]);
            }
            __data.Add("2", ct);

            //La dernière itération renvoi  le reste.
            ct = new CountriesIteration();
            ct.finalItemsCount = __countries.Count;
            ct.iterationKey = "";
            ct.countries = new List<CountryModel>();
            for (int i = 120; i < ct.finalItemsCount; i++)
            {
                ct.countries.Add(__countries[i]);
            }

            __data.Add("3", ct);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iterationKey"></param>
        /// <returns></returns>
        public CountriesIteration GetCountrieIteration(String iterationKey)
        {
            String key = iterationKey;
            if (key == null)
                key = String.Empty;
            if (__data.Keys.Contains(key))
            {
                return __data[key];
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CountriesIteration> GetCountriesIteration()
        {
            return __data.Values;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public CountriesIteration GetCountriesIterationByRegion(string Id)
        {
            CountriesIteration retour = new CountriesIteration();
            retour.countries = new List<CountryModel>();
            retour.finalItemsCount = 0;
            retour.iterationKey = String.Empty;
            if (!String.IsNullOrEmpty(Id))
            {
                String idToLower = Id.ToLower();
                foreach (String iterKey in __data.Keys)
                {
                    CountriesIteration countriesIteration = __data[iterKey];
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
    }
}