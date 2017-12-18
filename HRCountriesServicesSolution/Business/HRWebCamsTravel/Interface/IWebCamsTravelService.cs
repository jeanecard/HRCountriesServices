using HRCountriesServicesSolution.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        Task<WebCamsTravelRootObject> GetBestWebCam(String country, String capital);
    }
}
