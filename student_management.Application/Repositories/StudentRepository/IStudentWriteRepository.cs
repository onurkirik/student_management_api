using student_management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_management.Application.Repositories.StudentRepository
{
    public interface IStudentWriteRepository : IWriteRepository<Student>
    {
    }
}
