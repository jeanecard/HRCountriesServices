using System;
using System.Collections.Generic;
using HRCountriesServicesSolution.Models;
using RestSharp;
using RestSharp.Authenticators;
using HRCountriesServicesSolution.Business;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class HRGeonameRestClient : IHRGeonameRestClient
    {
        String _connectGeoNamesURL = String.Empty;
        String _geonameKey = String.Empty;
        private IGeonameRestRequestGenerator _restRequestGenerator = null;
        private IGeonameRestResponseAnalyser _restResponseAnalyser = null;
        private IRestClientProvider _clientProvider = null;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public HRGeonameRestClient(IRestClientProvider clientProvider,
            IGeonameRestRequestGenerator restRequestGenerator,
            IGeonameRestResponseAnalyser restResponseAnalyser
            )
        {
            //Dependancy injection
            _clientProvider = clientProvider;
            _restRequestGenerator = restRequestGenerator;
            _restResponseAnalyser = restResponseAnalyser;
            //Initialisation
            _connectGeoNamesURL = System.Configuration.ConfigurationManager.AppSettings[HRCountriesServicesSolution.Constant.WEBCONFIG.GEONAME_SEARCHJSON_URL_KEY];
            _geonameKey = System.Configuration.ConfigurationManager.AppSettings[HRCountriesServicesSolution.Constant.WEBCONFIG.GEONAME_KEY];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Geoname>> Execute()
        {
            if (_clientProvider != null && _restRequestGenerator != null && _restResponseAnalyser != null)
            {
                List<Geoname> retour = new List<Geoname>();
                _clientProvider.ConnectionURL = _connectGeoNamesURL;
                var geonameClient = _clientProvider.CreateRestClient();

                var request = _restRequestGenerator.Generate(Capital, Country, _geonameKey);
                IRestResponse response = await geonameClient.ExecuteGetTaskAsync(request);
                HRGeoNameRootObject result = JsonConvert.DeserializeObject<HRGeoNameRootObject>(response.Content);
                if (result != null && _restResponseAnalyser != null)
                {
                    Geoname fittingGeoname = _restResponseAnalyser.GetBestFittingPlaceName(Capital, result.geonames);
                    retour.Add(fittingGeoname);
                }
                return retour;
            }
            else
            {
                throw new Exception(HRCountriesServicesSolution.Constant.GEONAME.REST_CLIENT_NOT_INITIALIZED);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public String Capital { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String Country { get; set; }

    }
}