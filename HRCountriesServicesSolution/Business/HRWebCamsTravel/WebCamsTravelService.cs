using HRCountriesServicesSolution.Constant;
using HRCountriesServicesSolution.Business;
using HRCountriesServicesSolution.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// Service to get the best WebCam for a specific town in a given country.
    /// No unit test as implementation is trivial
    /// </summary>
    public class WebCamsTravelService : IWebCamsTravelService
    {
        private IHRGeonameRestClient _geoNameClient = null;
        private IHRWebCamsTravelRestClient _webCamRestClient = null;

        /// <summary>
        /// Constructor for dependancy injection
        /// </summary>
        /// <param name="geoNameClient"></param>
        /// <param name="webCamRestClient"></param>
        public WebCamsTravelService(IHRGeonameRestClient geoNameClient,
            IHRWebCamsTravelRestClient webCamRestClient)
        {
            _geoNameClient = geoNameClient;
            _webCamRestClient = webCamRestClient;
    }
        /// <summary>
        /// Get the 5 best Webcams for the given Capital in the given Country
        /// 1- Get the Lat lon of capital via GeoName Service
        /// 2- If Lat Lon is retrieved, Get the Player from Lat Lon capital.
        /// 3- Else, return null
        /// 4- Throw Exception if internal initialisation failed.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="capital"></param>
        /// <returns></returns>
        public async Task<WebCamsTravelRootObject> GetBestWebCam(string country, string capital)
        {
            //1- 
            if (_geoNameClient != null && _webCamRestClient != null)
            {
                _geoNameClient.Capital = capital;
                _geoNameClient.Country = country;
                List<Geoname> geonames = await _geoNameClient.Execute();
                if (geonames != null && geonames.Count > 0)
                {
                    double capitalLat = 0.0;
                    double capitalLon = 0.0;
                    if (Double.TryParse(geonames[0].lat.Replace('.', ','), out capitalLat))
                    {
                        if (Double.TryParse(geonames[0].lng.Replace('.', ','), out capitalLon))
                        {
                            //2- 
                            _webCamRestClient.Lat = capitalLat;
                            _webCamRestClient.Lon = capitalLon;
                            return await _webCamRestClient.ExecuteBestWebCam();
                        }
                    }
                }
                else
                {
                    //3-
                    return null;
                }
            }
            //4-
            throw new Exception(Constant.WEBCAMTRAVEL.INITIALISATION_ERROR_DESCRIPTION);
        }
    }
}