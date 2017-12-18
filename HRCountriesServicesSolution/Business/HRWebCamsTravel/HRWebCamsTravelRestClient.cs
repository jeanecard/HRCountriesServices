using HRCountriesServicesSolution.Business;
using HRCountriesServicesSolution.Constant;
using HRCountriesServicesSolution.Models;
using log4net;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// 
    /// </summary>
   public class HRWebCamsTravelRestClient : IHRWebCamsTravelRestClient
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(HRWebCamsTravelRestClient));
        String _connectWebcamsTravelsURL = String.Empty;
        String _webcamsTravelLogin = String.Empty;
        String _webcamsTravelPwd = String.Empty;
        IRestClientProvider _clientProvider = null;

        private IWebCamsTravelRestRequestGenerator _restRequestGenerator = null;
        private IWebCamsTravelRestResponseAnalyser _restResponseAnalyser = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="restRequestGenerator"></param>
        /// <param name="restResponseAnalyser"></param>
        /// <param name="clientProvider"></param>
        public HRWebCamsTravelRestClient(IWebCamsTravelRestRequestGenerator restRequestGenerator, 
                                        IWebCamsTravelRestResponseAnalyser restResponseAnalyser,
                                        IRestClientProvider clientProvider)
        {
            _restRequestGenerator = restRequestGenerator;
            _restResponseAnalyser = restResponseAnalyser;
            _clientProvider = clientProvider;
            try
            {
                _connectWebcamsTravelsURL = System.Configuration.ConfigurationManager.AppSettings[HRCountriesServicesSolution.Constant.WEBCONFIG.WEBCAMSTRAVEL_URL_KEY];
                _webcamsTravelLogin = System.Configuration.ConfigurationManager.AppSettings[HRCountriesServicesSolution.Constant.WEBCONFIG.WEBCAMSTRAVEL_LOGIN_KEY];
                _webcamsTravelPwd = System.Configuration.ConfigurationManager.AppSettings[HRCountriesServicesSolution.Constant.WEBCONFIG.WEBCAMSTRAVEL_PWD_KEY];
            }
            catch(Exception ex)
            {
                if(_log != null)
                {
                    _log.DebugFormat("Application raise exception in {0}", "HRWebCamsTravelRestClient constructor");
                    _log.Debug(ex.Message);
                }
            }
        }

        /// <summary>
        /// Get the nearest bests webcams at given lat lon.
        /// Return null if data can not be found.
        /// </summary>
        /// <returns></returns>
        public async  Task<WebCamsTravelRootObject> ExecuteBestWebCam()
        {
            WebCamsTravelRootObject retour = null;
            _clientProvider.ConnectionURL = _connectWebcamsTravelsURL;
            _clientProvider.Login = _webcamsTravelLogin;
            _clientProvider.Password = _webcamsTravelPwd;
            var webCamClient = _clientProvider.CreateRestClient();  

            var webCamRequest = _restRequestGenerator.Generate(Lat, Lon);
            // execute the request
            IRestResponse<WebCamsTravelRootObject> webcamsTravelResponse = await webCamClient.ExecuteGetTaskAsync<WebCamsTravelRootObject>(webCamRequest);
            if (webcamsTravelResponse != null && webcamsTravelResponse.Data != null && webcamsTravelResponse.Data.result != null)
            {
                List<Webcam> bestWebCams = _restResponseAnalyser.GetBestFittingWebCam(webcamsTravelResponse.Data.result.webcams);
                if (bestWebCams != null)
                {
                    retour = new WebCamsTravelRootObject();
                    retour.status = "OK";
                    retour.result = new Result();
                    retour.result.limit = 0;
                    retour.result.offset = 0;
                    retour.result.total = 0;
                    retour.result.webcams = new List<Webcam>();
                    foreach (Webcam iterator in bestWebCams)
                    {
                        if (iterator.player != null)
                        {
                            retour.result.webcams.Add(iterator);
                            retour.result.limit++;
                            retour.result.total++;
                        }
                    }
                    return retour;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
        /// <summary>
        /// Latitude to look for the best Webcam
        /// </summary>
        public double Lat { get; set; }
        /// <summary>
        /// Longitude to look for the best Webcam
        /// </summary>
        public double Lon { get; set; }

    }
}
