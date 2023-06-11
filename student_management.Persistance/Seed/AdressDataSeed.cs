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
    public class AdressDataSeed : IEntityTypeConfiguration<Adress>
    {
        public void Configure(EntityTypeBuilder<Adress> builder)
        {
            builder.HasData(
                new Adress()
                {
                    Id = Guid.Parse("B8BF0B78-0202-4883-AB4D-6D57832A1046"),
                    PhysicalAdress = "Altındağ/Ankara",
                    PostalAdress = "Türkiye",
                });
        }
    }
}
