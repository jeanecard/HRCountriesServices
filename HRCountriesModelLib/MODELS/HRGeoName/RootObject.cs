using System.Collections.Generic;

namespace HRCountriesServicesSolution.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class HRGeoNameRootObject
    {
        /// <summary>
        /// 
        /// </summary>
        public int totalResultsCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Geoname> geonames { get; set; }
    }
}