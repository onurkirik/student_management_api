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
                Id = Guid.NewGuid(),
                PhysicalAdress = model.Adress.PhysicalAdress,
                PostalAdress = model.Adress.PostalAdress
            };

            await _adressService.AddAsync(adress);

            model.Adress = adress;

            await _context.Student.AddAsync(model);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAll()
        {
            return await _context.Student.Include(s => s.Adress).Include(s => s.Gender).ToListAsync();
        }

        public async Task<Student> GetByIdAsync(Guid id)
        {
            return await _context.Student.Include(s => s.Adress).Include(s => s.Gender).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task Update(Guid id, Student model)
        {
            if (await _context.Student.AnyAsync(s => s.Id == id))
            {
                var updateStudent = await GetByIdAsync(id);
                updateStudent!.FirstName = model.FirstName;
                updateStudent.LastName = model.LastName;
                updateStudent.Phone = model.Phone;
                updateStudent.Email = model.Email;
                updateStudent.BirthDate = model.BirthDate;
                updateStudent.GenderId = model.GenderId;
                updateStudent.Adress.PhysicalAdress = model.Adress.PhysicalAdress;
                updateStudent.Adress.PostalAdress = model.Adress.PostalAdress;

                await _unitOfWork.SaveChangesAsync();
            }
        }
        public async Task Delete(Guid id)
        {
            var deletedModel = await GetByIdAsync(id);
            if (deletedModel != null)
            {
                _context.Student.Remove(deletedModel);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
