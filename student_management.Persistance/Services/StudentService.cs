using Microsoft.EntityFrameworkCore;
using student_management.Application.Services;
using student_management.Domain.Entities;
using student_management.Domain.Entities.Common;
using student_management.Persistance.Context;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace student_management.Persistance.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAdressService _adressService;
        public StudentService(ApplicationDbContext context, IUnitOfWork unitOfWork, IAdressService adressService)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _adressService = adressService;
        }

        public async Task AddAsync(Student model)
        {
            var adress = new Adress()
            {
                Id = model.Adress.Id,
                PhysicalAdress = model.Adress.PhysicalAdress,
                PostalAdress = model.Adress.PostalAdress
            };

            await _adressService.AddAsync(adress);

            await _context.Student.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAll()
        {
            return await _context.Student.Include(s => s.Adress).Include(s => s.Gender).ToListAsync();
        }

        public async Task<Student> GetByIdAsync(Guid id)
        {
            return await _context.Student.Include(s => s.Adress).Include(s => s.Gender).FirstAsync(s => s.Id == id);
        }

        public async Task Update(Student model)
        {
            _context.Student.Update(model);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task Delete(Guid id)
        {
            var deletedModel = _context.Student.Find(id);
            if (deletedModel != null)
            {
                _context.Student.Remove(deletedModel);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
