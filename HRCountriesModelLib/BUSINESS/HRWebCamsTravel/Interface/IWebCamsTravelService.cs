using HRCountriesServicesSolution.Models;
using System;
namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// 
    /// </summary>
    public interface IWebCamsTravelService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="country"></param>
        /// <param name="capital"></param>
        /// <returns></returns>
        WebCamsTravelRootObject GetBestWebCam(String country, String capital);
    }
}
