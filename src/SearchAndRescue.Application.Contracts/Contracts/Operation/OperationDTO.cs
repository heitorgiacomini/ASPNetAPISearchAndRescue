using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SearchAndRescue.Contracts.Operation
{
    public class OperationDTO : FullAuditedEntityDto<long>
    {
        public string Name { get; set; }
        public Point Point { get; set; }
        public decimal RadiusOfInterest { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long OperationStatusId { get; set; }
    }
}
