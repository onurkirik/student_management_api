using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using student_management.Application.Services;
using student_management.Persistance.Context;
using student_management.Persistance.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_management.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistance(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(connectionString));
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAdressService, AdressService>();
            services.AddScoped<IGenderService, GenderService>();

        }
    }
}
