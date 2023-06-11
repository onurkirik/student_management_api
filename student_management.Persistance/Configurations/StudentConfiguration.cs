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
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(s => s.LastName).IsRequired().HasMaxLength(50);
            builder.Property(s => s.BirthDate).IsRequired();
            builder.Property(s => s.Email).IsRequired();
            builder.Property(s => s.Phone).IsRequired();
            builder.HasOne(s => s.Gender).WithOne().HasForeignKey<Gender>(g => g.StudentId);
            builder.HasOne(s => s.Adress).WithOne().HasForeignKey<Adress>(a => a.StudentId);

        }


    }
}
