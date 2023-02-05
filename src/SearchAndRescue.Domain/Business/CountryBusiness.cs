using System;
using System.ComponentModel.DataAnnotations;

namespace SearchAndRescue.Business
{ 
    public class CountryBusiness : BaseClassBusiness
    {
        [MaxLength(30)]
        [Required]
        public string Name { get; set; } 
    }
}