using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SearchAndRescue.Business
{
    public class OperationStatus : BaseClass
    {
        public string Name { get; set; }
    }
}
