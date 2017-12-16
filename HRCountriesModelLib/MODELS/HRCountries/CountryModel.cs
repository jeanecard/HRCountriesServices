using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRCountriesServicesSolution.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string symbol { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Language
    {
        /// <summary>
        /// 
        /// </summary>
        public string iso639_1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string iso639_2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string nativeName { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Translations
    {
        /// <summary>
        /// 
        /// </summary>
        public string de { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string es { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ja { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string it { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string br { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string nl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hr { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public class RegionalBloc
    {
        /// <summary>
        /// 
        /// </summary>
        public String acronym { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<String> otherAcronyms { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<String> otherNames { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class CountryModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> topLevelDomain { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string alpha2Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string alpha3Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> callingCodes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string capital { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<object> altSpellings { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string region { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string subregion { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public int population { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public float[] latlng { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string demonym { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double? area { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double? gini { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> timezones { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<String> borders { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string nativeName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string numericCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Currency> currencies { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Language> languages { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Translations translations { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string flag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<RegionalBloc> regionalBlocs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string detailFrame { get; set; }
    }
}