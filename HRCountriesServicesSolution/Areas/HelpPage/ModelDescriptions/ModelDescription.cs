using System;
using System.Web.Http.Description;

namespace HRCountriesServicesSolution.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// 
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    public abstract class ModelDescription
    {
        /// <summary>
        /// 
        /// </summary>
        public string Documentation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Type ModelType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
    }
}