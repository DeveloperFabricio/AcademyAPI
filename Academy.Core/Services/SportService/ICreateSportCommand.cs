using Academy.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Services.SportService
{
    public interface ICreateSportCommand
    {
        int Id { get; }
        string Name { get; }
        string Description { get; }
        DifficultLevelEnum DifficultLevel { get; }
    }
}
