using Academy.Core.Entities;
using Academy.Core.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Infrasctructure.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _appDbContext;

        public StudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Student> AddAsync(Student student)
        {
            _appDbContext.Students.Add(student);
            await _appDbContext.SaveChangesAsync();
            return student;
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _appDbContext.Students.FindAsync(id);
            _appDbContext.Students.Remove(student);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _appDbContext.Students.ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _appDbContext.Students.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            var existingStudent = await _appDbContext.Students.FindAsync(student.Id);

            if (existingStudent == null)
            {
                throw new InvalidOperationException("Student not found");
            }

            existingStudent.Id = student.Id;
            existingStudent.Name = student.Name;
            existingStudent.Age = student.Age;
            existingStudent.SubscriptionPlan = student.SubscriptionPlan;
            existingStudent.PaymentHistory = student.PaymentHistory;

            _appDbContext.Entry(existingStudent).State = EntityState.Modified;

            await _appDbContext.SaveChangesAsync();
        }
    
    }
}
