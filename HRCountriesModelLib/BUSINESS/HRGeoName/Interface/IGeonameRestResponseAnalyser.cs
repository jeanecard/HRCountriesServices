using HRCountriesServicesSolution.Models;
using System.Collections.Generic;

namespace HRCountriesServicesSolution.Business
{
    interface IGeonameRestResponseAnalyser
    {
        Geoname GetBestFittingPlaceName(string placeName, List<Geoname> inGeonames);
    }
}
