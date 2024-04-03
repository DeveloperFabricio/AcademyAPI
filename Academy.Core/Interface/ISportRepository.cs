using Academy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Interface
{
    public interface ISportRepository
    {
        Task<List<Sport>> GetAllAsync();
        Task<Sport> GettByIdAsync(int id);
        Task<Sport> AddAsync(Sport sport);
        Task UpdateAsync(Sport sport);
        Task DeleteAsync(int id);
    }
}
