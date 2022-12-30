using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SearchAndRescue.Business
{
    public class City : BaseClass
    {
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }
        public State State { get; set; }
    }
}
