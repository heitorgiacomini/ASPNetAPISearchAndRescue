using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace SearchAndRescue.Business
{
    public class AdressBusiness : BaseClassBusiness
    {
        [MaxLength(30)]
        public string PostalCode { get; set; }
        [MaxLength(30)]
        public string Street { get; set; }
        [MaxLength(10)]
        public string Number { get; set; }
        public long CityId { get; set; }
        public CityBusiness City { get; set; }

    }
}
