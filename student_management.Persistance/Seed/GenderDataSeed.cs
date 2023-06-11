using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using student_management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_management.Persistance.Seed
{
    public class GenderDataSeed : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasData(
                new Gender()
                {
                    Id = Guid.Parse("41607D57-E74E-40C4-AFBF-BED0476C3BA8"),
                    Description = "Erkek"
                },
                new Gender()
                {
                    Id = Guid.Parse("E4A62A5F-1222-4F9D-9404-C6E691D7A4BF"),
                    Description = "Kadın"
                });
        }
    }
}
