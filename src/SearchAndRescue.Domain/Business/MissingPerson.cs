using System;
using System.ComponentModel.DataAnnotations;
using System.Spatial;

namespace SearchAndRescue.Business
{
    public class MissingPerson
    {
        //HasConversion(new GeographyValueConverter()
        //[Column(TypeName = "geography")]
        public Geography LastSeenPoint { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        public Race Race { get; set; }
        public string photo { get; set; }
        public char Sex { get; set; }
        public DateTime Birthdate { get; set; }
        public decimal Weight { get; set; }
        public string EyeColor { get; set; }
        public string HairColor { get; set; }
        public string Clothes { get; set; }
        public string Description { get; set; }
    }
}
