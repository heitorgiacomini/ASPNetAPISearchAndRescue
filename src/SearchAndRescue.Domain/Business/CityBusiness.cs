using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SearchAndRescue.Business
{
    public class CityBusiness : BaseClassBusiness
    {
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }
        [Required]
        public long StateId { get; set; }
        public StateBusiness State { get; set; }
    }
}
