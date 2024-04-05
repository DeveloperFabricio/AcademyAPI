using Academy.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Services.LoginService
{
    public interface ILoginInstructorCommandHandler
    {
        Task<ILoginInstructorViewModel> Handle(ILoginInstructorCommand request, CancellationToken cancellationToken);
    }
}
