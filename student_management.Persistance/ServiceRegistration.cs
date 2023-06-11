using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using student_management.Persistance.Context;
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
        }
    }
}
