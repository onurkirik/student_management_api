using student_management.Domain.Entities;
using student_management.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace student_management.Application.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAll();
        Task<Student> GetByIdAsync(Guid id);
        Task AddAsync(Student model);
        Task Update(Student model);
        Task Delete(Guid id);
    }
}
