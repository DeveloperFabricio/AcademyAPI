using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Services.SportService
{
    public interface ICreateSportCommandHandler
    {
        Task<Unit> Handle(ICreateSportCommand request, CancellationToken cancellationToken);
    }
}
