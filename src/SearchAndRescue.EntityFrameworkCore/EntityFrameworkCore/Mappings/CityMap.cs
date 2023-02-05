using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SearchAndRescue.Business;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace SearchAndRescue.EntityFrameworkCore.Mappings
{
    public class CityMap : IEntityTypeConfiguration<CityBusiness>
    {
        public void Configure(EntityTypeBuilder<CityBusiness> t)
        {

            t.ToTable(SearchAndRescueConsts.DbTablePrefix + nameof(CityBusiness), SearchAndRescueConsts.DbSchema);
            t.ConfigureByConvention();

            t.Ignore(p => p.ExtraProperties);
        }



    }
}
