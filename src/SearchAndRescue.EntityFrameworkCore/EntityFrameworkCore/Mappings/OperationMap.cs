using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SearchAndRescue.Business;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace SearchAndRescue.EntityFrameworkCore.Mappings
{
    public class OperationMap : IEntityTypeConfiguration<OperationBusiness>
    {
        public void Configure(EntityTypeBuilder<OperationBusiness> t)
        {

            t.ToTable(SearchAndRescueConsts.DbTablePrefix + nameof(OperationBusiness), SearchAndRescueConsts.DbSchema);
            t.ConfigureByConvention();

            t.Ignore(p => p.ExtraProperties);
        } 

    }
}
