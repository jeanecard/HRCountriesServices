
using System;

namespace HRCountriesServicesSolution.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class WebCamsTravelRootObject : IErrorDescriptionAbility
    {
        private String _errorDescription = String.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Result result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string errorDescription
        {
            get
            {
                return _errorDescription;
            }

            set
            {
                _errorDescription = value;
            }
        }
    }
}
