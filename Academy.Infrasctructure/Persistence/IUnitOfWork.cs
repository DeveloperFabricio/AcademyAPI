using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Infrasctructure.Persistence
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
        Task<int> DeleteAsync();
    }
}
