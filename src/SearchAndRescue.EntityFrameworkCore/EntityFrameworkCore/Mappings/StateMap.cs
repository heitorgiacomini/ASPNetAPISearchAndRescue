using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SearchAndRescue.Business;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace SearchAndRescue.EntityFrameworkCore.Mappings
{
    public class StateMap : IEntityTypeConfiguration<StateBusiness>
    {
        public void Configure(EntityTypeBuilder<StateBusiness> t)
        {

            t.ToTable(SearchAndRescueConsts.DbTablePrefix + nameof(StateBusiness), SearchAndRescueConsts.DbSchema);
            t.ConfigureByConvention();

            t.Ignore(p => p.ExtraProperties);
        }



    }
}
