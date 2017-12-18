using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRCountriesServicesSolution.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class CountriesIteration :  IErrorDescriptionAbility
    {
        private String _errorDescription = String.Empty;
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public List<CountryModel> countries { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public String iterationKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int finalItemsCount { get; set; }
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