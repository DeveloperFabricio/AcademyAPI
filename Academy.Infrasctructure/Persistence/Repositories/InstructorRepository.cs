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
    public class InstructorRepository : IInstructorRepository
    {
        private readonly AppDbContext _appDbContext;

        public InstructorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Instructor> AddAsync(Instructor instructor)
        {
            _appDbContext.Instructors.Add(instructor);
            await _appDbContext.SaveChangesAsync();
            return instructor;
        }

        public async Task DeleteAsync(int id)
        {
            var instructor = await _appDbContext.Instructors.FindAsync(id);
            _appDbContext.Instructors.Remove(instructor);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Instructor> GetInstructorByEmailAndPasswordAsync(int id, string passwordHash)
        {
            return await _appDbContext.Instructors.SingleOrDefaultAsync(i => i.Id == id && i.Password == passwordHash);
        }

        public async Task<List<Instructor>> GettAllAsync()
        {
            return await _appDbContext.Instructors.ToListAsync();
        }

        public async Task<Instructor> GettByIdAsync(int id)
        {
            return await _appDbContext.Instructors.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task UpdateAsync(Instructor instructor)
        {
            var existingInstructor = await _appDbContext.Instructors.FindAsync(instructor.Id);

            if (existingInstructor == null)
            {
                throw new InvalidOperationException("Instructor not found");
            }

            existingInstructor.Name = instructor.Name;
            existingInstructor.Specialization = instructor.Specialization;
            existingInstructor.Availability = instructor.Availability;
            existingInstructor.Description = instructor.Description;
            existingInstructor.Location = instructor.Location;

            _appDbContext.Entry(existingInstructor).State = EntityState.Modified;

            await _appDbContext.SaveChangesAsync();
        }
    }
}
