using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using student_management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_management.Persistance.Configurations
{
    public class AdressConfiguration : IEntityTypeConfiguration<Adress>
    {
        public void Configure(EntityTypeBuilder<Adress> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.PhysicalAdress).IsRequired().HasMaxLength(250);
            builder.Property(a => a.PostalAdress).IsRequired().HasMaxLength(250);
        }
    }
}
