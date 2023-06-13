using student_management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_management.Application.Services
{
    public interface IGenderService
    {
        Task<List<Gender>> GetAll();
        Task<Gender> GetByIdAsync(Guid id);
        Task AddAsync(Gender model);
        Task Update(Gender model);
        Task Delete(Guid id);
    }
}
