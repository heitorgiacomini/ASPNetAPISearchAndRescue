using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SearchAndRescue.Business;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace SearchAndRescue.EntityFrameworkCore.Mappings
{
    public class AdressMap : IEntityTypeConfiguration<AdressBusiness>
    {
        public void Configure(EntityTypeBuilder<AdressBusiness> t)
        {

            t.ToTable(SearchAndRescueConsts.DbTablePrefix + nameof(AdressBusiness), SearchAndRescueConsts.DbSchema);
            t.ConfigureByConvention();

            t.Ignore(p => p.ExtraProperties);
        }



    }
}
