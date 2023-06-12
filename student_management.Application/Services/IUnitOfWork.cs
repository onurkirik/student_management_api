using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_management.Application.Services
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
