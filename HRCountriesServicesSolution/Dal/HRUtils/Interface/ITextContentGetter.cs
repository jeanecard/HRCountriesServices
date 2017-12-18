using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRCountriesServicesSolution.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITextContentGetter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<String> GetCountriesData();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<String> GetBoundariesData();
    }
}
