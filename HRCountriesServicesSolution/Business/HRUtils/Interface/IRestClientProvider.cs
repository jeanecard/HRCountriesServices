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
    public interface IRestClientProvider
    {
        /// <summary>
        /// 
        /// </summary>
        String ConnectionURL { get; set; }

        /// <summary>
        /// 
        /// </summary>
        String Login { get; set; }

        /// <summary>
        /// 
        /// </summary>
        String Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IRestClient CreateRestClient();
    }
}
