using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using HRCountriesServicesSolution.Models;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class GeonameRestResponseAnalyser : IGeonameRestResponseAnalyser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="placeName"></param>
        /// <param name="inGeonames"></param>
        /// <returns></returns>
        public Geoname GetBestFittingPlaceName(string placeName, List<Geoname> inGeonames)
        {
            Geoname retour = null;
            if(inGeonames != null)
            {
                if(String.IsNullOrEmpty(placeName))
                {
                    if(inGeonames != null)
                        retour = inGeonames.FirstOrDefault();
                }
                else if(inGeonames != null)
                {
                    int bestLevensteinScore = 1000;
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
            }
            return retour;
        }

        private String RemoveWeirdCharToCompare(String stringToUpdate)
        {
            return Regex.Replace(stringToUpdate, "[^A-Za-z]", "").ToLower();
        }
    }
}
