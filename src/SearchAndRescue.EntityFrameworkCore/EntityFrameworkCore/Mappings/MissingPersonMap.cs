using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SearchAndRescue.Business;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace SearchAndRescue.EntityFrameworkCore.Mappings
{
    public class MissingPersonMap : IEntityTypeConfiguration<MissingPersonBusiness>
    {
        public void Configure(EntityTypeBuilder<MissingPersonBusiness> t)
        {

            t.ToTable(SearchAndRescueConsts.DbTablePrefix + nameof(MissingPersonBusiness), SearchAndRescueConsts.DbSchema);
            t.ConfigureByConvention();

            t.Ignore(p => p.ExtraProperties);
        }



    }
}
