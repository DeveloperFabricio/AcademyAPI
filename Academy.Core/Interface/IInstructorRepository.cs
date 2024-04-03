using Academy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Interface
{
    public interface IInstructorRepository
    {
        Task<List<Instructor>> GettAllAsync();
        Task<Instructor> GettByIdAsync(int id);
        Task<Instructor> AddAsync(Instructor instructor);
        Task UpdateAsync(Instructor instructor);
        Task DeleteAsync(int id);
        Task<Instructor> GetInstructorByEmailAndPasswordAsync(int id, string password);
    }
}
