using System.Web.Http.Description;

namespace HRCountriesServicesSolution.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// 
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    public class EnumValueDescription
    {
        /// <summary>
        /// 
        /// </summary>
        public string Documentation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Value { get; set; }
    }
}