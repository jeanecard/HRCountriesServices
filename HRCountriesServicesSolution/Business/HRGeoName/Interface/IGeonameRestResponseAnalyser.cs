using HRCountriesServicesSolution.Models;
using System.Collections.Generic;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// GeoName Response Analyser Interface
    /// </summary>
    public interface IGeonameRestResponseAnalyser
    {
        /// <summary>
        /// Get the Best approching placeName in the world
        /// </summary>
        /// <param name="placeName">Place name to search</param>
        /// <param name="inGeonames">A List of GeoName object</param>
        /// <returns>The most approching GeoName null if can not be found</returns>
        Geoname GetBestFittingPlaceName(string placeName, List<Geoname> inGeonames);
    }
}
