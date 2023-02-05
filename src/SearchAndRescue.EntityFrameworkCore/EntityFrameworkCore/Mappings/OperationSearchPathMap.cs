using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SearchAndRescue.Business;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace SearchAndRescue.EntityFrameworkCore.Mappings
{
    public class PathSearchOperationMap : IEntityTypeConfiguration<PathSearchOperationBusiness>
    {
        public void Configure(EntityTypeBuilder<PathSearchOperationBusiness> t)
        {

            t.ToTable(SearchAndRescueConsts.DbTablePrefix + nameof(PathSearchOperationBusiness), SearchAndRescueConsts.DbSchema);
            t.ConfigureByConvention();

            t.Ignore(p => p.ExtraProperties);
        } 

    }
}
