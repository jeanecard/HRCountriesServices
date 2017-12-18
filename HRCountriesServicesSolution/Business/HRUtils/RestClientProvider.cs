using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using RestSharp.Authenticators;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class RestClientProvider : IRestClientProvider
    {
        String _connectionURL = String.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ConnectionURL
        {
            get
            {
                return _connectionURL;
            }

            set
            {
                _connectionURL = value;
            }
        }
        String _login = String.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Login
        {
            get
            {
                return _login;
            }

            set
            {
                _login = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        String _password = String.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }
        /// <summary>
        /// Instanciate new RestClient
        /// </summary>
        /// <returns></returns>
        public IRestClient CreateRestClient()
        {
            //!Would have been better to pass through StructureMap...
            var webCamClient = new RestClient(_connectionURL);
            if (!String.IsNullOrEmpty(_login) && !String.IsNullOrEmpty(_password))
            {
                webCamClient.Authenticator = new HttpBasicAuthenticator(_login, _password);
            }
            return webCamClient;
        }
    }
}