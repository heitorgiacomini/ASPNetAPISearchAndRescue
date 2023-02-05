using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SearchAndRescue.Business;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace SearchAndRescue.EntityFrameworkCore.Mappings
{
    public class RaceMap : IEntityTypeConfiguration<RaceBusiness>
    {
        public void Configure(EntityTypeBuilder<RaceBusiness> t)
        {

            t.ToTable(SearchAndRescueConsts.DbTablePrefix + nameof(RaceBusiness), SearchAndRescueConsts.DbSchema);
            t.ConfigureByConvention();

            t.Ignore(p => p.ExtraProperties);
        }



    }
}
