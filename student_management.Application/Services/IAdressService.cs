using student_management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_management.Application.Services
{
    public interface IAdressService
    {
        Task<List<Adress>> GetAll();
        Task<Adress> GetByIdAsync(Guid id);
        Task AddAsync(Adress model);
        Task Update(Adress model);
        Task Delete(Guid id);
    }
}
