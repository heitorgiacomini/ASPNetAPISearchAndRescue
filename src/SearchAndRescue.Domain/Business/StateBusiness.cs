using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SearchAndRescue.Business
{
    public class StateBusiness : BaseClassBusiness
    {
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }
        [Required]
        public long CountryBusinessId { get; set; }
        public CountryBusiness CountryBusiness { get; set; }
    }
}
