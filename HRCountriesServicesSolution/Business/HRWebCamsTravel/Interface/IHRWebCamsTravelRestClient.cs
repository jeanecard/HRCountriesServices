using HRCountriesServicesSolution.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHRWebCamsTravelRestClient
    {
        /// <summary>
        /// Get the nearest bests webcams at given lat lon.
        /// </summary>
        /// <returns></returns>
        Task<WebCamsTravelRootObject> ExecuteBestWebCam();

        /// <summary>
        /// 
        /// </summary>
        double Lat { get; set; }
        /// <summary>
        /// 
        /// </summary>
        double Lon { get; set; }
    }
}
