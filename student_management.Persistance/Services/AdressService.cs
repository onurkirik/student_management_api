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
    public class AdressService : IAdressService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public AdressService(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Adress model)
        {
            await _context.Adress.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var deletedModel = _context.Adress.Find(id);
            if (deletedModel != null)
            {
                _context.Adress.Remove(deletedModel);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<List<Adress>> GetAll()
        {
            return await _context.Adress.ToListAsync();
        }

        public async Task<Adress> GetByIdAsync(Guid id)
        {
            return await _context.Adress.FirstAsync(s => s.Id == id);
        }

        public async Task Update(Adress model)
        {
            _context.Adress.Update(model);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
