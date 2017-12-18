// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace HRCountriesServicesSolution.DependencyResolution {
    using Business;
    using DAL;
    using RestSharp;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;

    /// <summary>
    /// Factory permettant de faire l'Injection de dépedance.
    /// </summary>
    public class DefaultRegistry : Registry {
        #region Constructors and Destructors
        /// <summary>
        /// La factory nécessaire pour faire l'injection de dépendance.
        /// </summary>
        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
            For<ICountriesService>().Use<CountriesService>();
            For<ICountriesIterationService>().Use<CountriesIterationService>();
            For<IRegionsRepository>().Use<BufferisedRegionsRepository>();
            For<IHRCountryBorderRepository>().Use<BufferisedHRCountryBorderRepository>();
            For<IGeonameRestResponseAnalyser>().Use<GeonameRestResponseAnalyser>();
            For<IGeonameRestRequestGenerator>().Use<GeonameRestRequestGenerator>();
            For<IBorderService>().Use<BorderService>();
            For<IWebCamsTravelService>().Use<WebCamsTravelService>();
            For<ICountriesIterationRepository>().Use<BufferedCountriesIterationRepository>();
            For<ICountriesRepository>().Use<BufferedCountriesRepository>();
            For<System.Uri>().Use<System.Uri>();
            For<IGeonameRestRequestGenerator>().Use<GeonameRestRequestGenerator>();
            For<IGeonameRestResponseAnalyser>().Use<GeonameRestResponseAnalyser>();
            For<IRestClient>().Use<RestClient>();
            For<IHRGeonameRestClient>().Use<HRGeonameRestClient>();
            For<IHRWebCamsTravelRestClient>().Use<HRWebCamsTravelRestClient>();
            For<ITextContentGetter>().Use<LocalJSONDataGetter>();
            For<IRestClientProvider>().Use<RestClientProvider>();
        }
        #endregion
    }
}