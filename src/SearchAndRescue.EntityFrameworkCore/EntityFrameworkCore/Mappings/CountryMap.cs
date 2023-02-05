using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SearchAndRescue.Business;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace SearchAndRescue.EntityFrameworkCore.Mappings
{
    public class CountryMap : IEntityTypeConfiguration<CountryBusiness>
    {
        public void Configure(EntityTypeBuilder<CountryBusiness> t)
        {

            t.ToTable(SearchAndRescueConsts.DbTablePrefix + nameof(CountryBusiness), SearchAndRescueConsts.DbSchema);
            t.ConfigureByConvention();

            t.Ignore(p => p.ExtraProperties);
        }



    }
}
