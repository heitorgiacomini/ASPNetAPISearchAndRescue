using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SearchAndRescue.Business;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace SearchAndRescue.EntityFrameworkCore.Mappings
{
    public class OperationMap : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> t)
        {

            t.ToTable(SearchAndRescueConsts.DbTablePrefix + nameof(Operation), SearchAndRescueConsts.DbSchema);
            t.ConfigureByConvention();

            //t.Property(e => e.CoordinateZ).HasColumnName("NetTopologySuitePoint").HasColumnType("geometry(PointZ, 4326)");
            t.Ignore(p => p.ExtraProperties);

        }



    }
}
