using HRCountriesServicesSolution.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace HRCountriesServicesSolution.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class CountriesStub
    {
        /// <summary>
        /// 
        /// </summary>
        public static List<CountryModel> __countries = null;
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, CountriesIteration> __data = new Dictionary<string, CountriesIteration>();
        //!HArd code à reprendre.
        /// <summary>
        /// 
        /// </summary>
        public CountriesStub()
        {
            if (__countries == null)
            {
                //Chargement des pays :
                string path = HttpContext.Current.Server.MapPath("~/App_Data/allCountries.json");
                __countries = JsonConvert.DeserializeObject<List<CountryModel>>(File.ReadAllText(path));
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
        /// <param name="alpha3Code"></param>
        /// <returns></returns>
        public CountryModel GetCountryByAlpha3Code(string alpha3Code)
        {
            CountryModel retour = null;
            if (!String.IsNullOrEmpty(alpha3Code))
            {
                foreach(CountryModel iterator in __countries)
                {
                    if(iterator.alpha3Code == alpha3Code)
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


