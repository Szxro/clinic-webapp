using Clinic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Data.Persistence.Configurations;

public sealed class DoctorConfiguration : IEntityTypeConfiguration<Doctorresponse>
{
    public void Configure(EntityTypeBuilder<Doctorresponse> builder)
    {
        builder.HasIndex(x => x.CollegueNumber).IsUnique();

        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}
