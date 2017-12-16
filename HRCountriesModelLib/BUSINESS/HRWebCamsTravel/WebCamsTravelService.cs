using HRCountriesServicesSolution.Models;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class WebCamsTravelService : IWebCamsTravelService
    {
        private IWebCamsTravelApi _repo = null; //!Injection à faire.
        /// <summary>
        /// 
        /// </summary>
        public WebCamsTravelService()
        {
            _repo = new WebCamsTravelApi();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="country"></param>
        /// <param name="capital"></param>
        /// <returns></returns>
        public WebCamsTravelRootObject GetBestWebCam(string country, string capital)
        {
            return _repo.GetBestWebCam(country, capital);
        }
    }
}