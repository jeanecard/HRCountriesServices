using HRCountriesServicesSolution.Business;
using HRCountriesServicesSolution.DAL;
using System;
using System.ComponentModel.DataAnnotations;

namespace HRCountriesServicesSolution.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class HRRegion : IErrorDescriptionAbility
    {
        private String _errorDescription = String.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// Used by Service if an error occured while retrieving or setting a HRRegion
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