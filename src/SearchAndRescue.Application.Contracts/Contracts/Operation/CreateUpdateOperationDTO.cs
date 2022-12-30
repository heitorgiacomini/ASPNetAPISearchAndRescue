using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SearchAndRescue.Contracts.Operation
{
    public class CreateUpdateOperationDTO
    {
        public string Name { get; set; }
        public Point Point { get; set; }
        public decimal RadiusOfInterest { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long OperationStatusId { get; set; }
    }
}
