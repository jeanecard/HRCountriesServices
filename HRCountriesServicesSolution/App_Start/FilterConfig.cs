using System.Web;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace HRCountriesServicesSolution
{
    /// <summary>
    /// 
    /// </summary>

    public class FilterConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
