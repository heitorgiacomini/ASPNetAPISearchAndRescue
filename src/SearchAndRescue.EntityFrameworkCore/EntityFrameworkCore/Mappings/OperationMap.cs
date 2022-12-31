using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SearchAndRescue.Business.Operation;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace SearchAndRescue.EntityFrameworkCore.Mappings
{
    public class OperationMap : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> t)
        {

            t.ToTable(SearchAndRescueConsts.DbTablePrefix + nameof(Operation), SearchAndRescueConsts.DbSchema);// SearchAndRescueConsts.DbSchema
            t.ConfigureByConvention();

            //t.Property(e => e.Point).HasColumnName("NetTopologySuitePoint").HasColumnType("geometry(PointZ, 4326)");
            //t.Property(e => e.GeometryPoint).HasColumnName("NetTopologySuitePoint").HasColumnType("geometry(PointZ, 4326)");

            //t.Ignore(p => p.ExtraProperties);
        }



    }
}
