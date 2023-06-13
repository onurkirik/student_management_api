using Microsoft.EntityFrameworkCore;
using student_management.Application.Services;
using student_management.Domain.Entities;
using student_management.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_management.Persistance.Services
{
    public class GenderService : IGenderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public GenderService(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(Gender model)
        {
            await _context.Gender.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var deletedModel = await _context.Gender.FindAsync(id);
            if (deletedModel != null)
            {
                _context.Gender.Remove(deletedModel);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<List<Gender>> GetAll()
        {
            return await _context.Gender.ToListAsync();
        }

        public async Task<Gender> GetByIdAsync(Guid id)
        {
            return await _context.Gender.FirstAsync(s => s.Id == id);
        }

        public async Task Update(Gender model)
        {
            _context.Gender.Update(model);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
