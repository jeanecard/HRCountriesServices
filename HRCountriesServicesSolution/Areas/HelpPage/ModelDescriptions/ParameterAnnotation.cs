using System;
using System.Web.Http.Description;

namespace HRCountriesServicesSolution.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// 
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ParameterAnnotation
    {
        /// <summary>
        /// 
        /// </summary>
        public Attribute AnnotationAttribute { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Documentation { get; set; }
    }
}