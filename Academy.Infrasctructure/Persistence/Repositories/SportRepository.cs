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
    public class SportRepository : ISportRepository
    {
        private readonly AppDbContext _appDbContext;

        public SportRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Sport> AddAsync(Sport sport)
        {
            _appDbContext.Sports.Add(sport);
            await _appDbContext.SaveChangesAsync();
            return sport;
        }

        public async Task DeleteAsync(int id)
        {
            var sport = await _appDbContext.Sports.FindAsync(id);
            _appDbContext.Sports.Remove(sport);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Sport>> GetAllAsync()
        {
            return await _appDbContext.Sports.ToListAsync();
        }

        public async Task<Sport> GettByIdAsync(int id)
        {
            return await _appDbContext.Sports.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateAsync(Sport sport)
        {
            var existingSport = await _appDbContext.Sports.FindAsync(sport.Id);

            if (existingSport == null)
            {
                throw new InvalidOperationException("Sport not found");
            }

            existingSport.Id = sport.Id;
            existingSport.Name = sport.Name;
            existingSport.Description = sport.Description;
            existingSport.DifficultLevel = sport.DifficultLevel;


            _appDbContext.Entry(existingSport).State = EntityState.Modified;

            await _appDbContext.SaveChangesAsync();
        }
    }
}
