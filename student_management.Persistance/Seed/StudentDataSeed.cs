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
    public class StudentDataSeed : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasData(
                new Student()
                {
                    Id = Guid.Parse("9650103C-8F99-4A39-83DA-70459BFF90BA"),
                    BirthDate = DateTime.Now,
                    Email = "kirikonurr@gmail.com",
                    FirstName = "Onur",
                    LastName = "KIRIK",
                    Phone = "5423815262",
                    ProfileImageUrl = "fjdksajf",
                    GenderId = Guid.Parse("41607D57-E74E-40C4-AFBF-BED0476C3BA8"),
                    AdressId = Guid.Parse("B8BF0B78-0202-4883-AB4D-6D57832A1046")
                });
        }
    }
}
