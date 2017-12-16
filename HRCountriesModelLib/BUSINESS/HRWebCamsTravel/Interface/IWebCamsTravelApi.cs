
using HRCountriesServicesSolution.Models;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// 
    /// </summary>
    public interface IWebCamsTravelApi
    {
        /// <summary>
        /// 
        /// </summary>
        WebCamsTravelRootObject GetBestWebCam(string country, string capital);
    }
}
