using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SearchAndRescue.Business;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace SearchAndRescue.EntityFrameworkCore.Mappings
{
    public class GeoFunctionsMap : IEntityTypeConfiguration<GeoFunctionsBusiness>
    {
        public void Configure(EntityTypeBuilder<GeoFunctionsBusiness> t)
        {

            t.ToTable(SearchAndRescueConsts.DbTablePrefix + nameof(GeoFunctionsBusiness), SearchAndRescueConsts.DbSchema);// SearchAndRescueConsts.DbSchema
            t.ConfigureByConvention();

            //t.Property(e => e.Point).HasColumnName("NetTopologySuitePoint").HasColumnType("geometry(PointZ, 4326)");
            //t.Property(e => e.GeometryPoint).HasColumnName("NetTopologySuitePoint").HasColumnType("geometry(PointZ, 4326)");

            //t.Ignore(p => p.ExtraProperties);
        }



    }
}
