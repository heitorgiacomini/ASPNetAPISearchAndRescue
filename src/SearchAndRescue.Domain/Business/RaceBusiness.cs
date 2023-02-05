using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SearchAndRescue.Business
{
    public class RaceBusiness : BaseClassBusiness
    {

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

    }
}
