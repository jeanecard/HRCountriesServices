using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using HRCountriesServicesSolution.Models;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// GeoName Response Analyser Implementation based on Levenstein algortihm
    /// </summary>
    public class GeonameRestResponseAnalyser : IGeonameRestResponseAnalyser
    {
        private static int INITIAL_BEST_LEVENSTEIN_SCORE = 1000;
        /// <summary>
        /// Get the Best approching placeName in the world
        /// </summary>
        /// <param name="placeName">Place name to search</param>
        /// <param name="inGeonames">A List of GeoName object</param>
        /// <returns>The most approching GeoName null if can not be found</returns>
        public Geoname GetBestFittingPlaceName(string placeName, List<Geoname> inGeonames)
        {
            Geoname retour = null;
            if (!String.IsNullOrEmpty(placeName) &&  inGeonames != null && inGeonames.Count > 0)
            {
                int bestLevensteinScore = INITIAL_BEST_LEVENSTEIN_SCORE;
                String cleanPlaceName = RemoveWeirdCharToCompare(placeName);
                foreach (Geoname iterator in inGeonames)
                {
                    if (iterator.name != null)
                    {
                        int levensteinScore = LevenshteinDistance.Compute(cleanPlaceName, RemoveWeirdCharToCompare(iterator.name));
                        if (levensteinScore < bestLevensteinScore)
                        {
                            bestLevensteinScore = levensteinScore;
                            retour = iterator;
                        }
                    }
                }
            }
            return retour;
        }

        private String RemoveWeirdCharToCompare(String stringToUpdate)
        {
            return Regex.Replace(stringToUpdate, "[^A-Za-z]", "").ToLower();
        }
    }
}
