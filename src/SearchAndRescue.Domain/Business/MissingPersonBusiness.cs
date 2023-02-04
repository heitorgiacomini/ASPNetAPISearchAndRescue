using System;
using System.ComponentModel.DataAnnotations;
using System.Spatial;

namespace SearchAndRescue.Business
{
    public class MissingPersonBusiness : BaseClassBusiness
    {
        //HasConversion(new GeographyValueConverter()
        //[Column(TypeName = "geography")]
        public Geography LastSeenPoint { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        public long RaceId { get; set; }
        public RaceBusiness Race { get; set; }
        [MaxLength(210)]
        public string PhotoUrl { get; set; }
        public long SexId { get; set; }
        public SexBusiness Sex { get; set; }
        public DateTime Birthdate { get; set; }
        public decimal Weight { get; set; }
        [MaxLength(20)]
        public string EyeColor { get; set; }
        [MaxLength(20)]
        public string HairColor { get; set; }
        [MaxLength(100)]
        public string Clothes { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
