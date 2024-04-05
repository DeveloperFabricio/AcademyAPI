using Academy.Application.ViewModels;
using Academy.Core.Interface;
using Academy.Core.Services;
using Academy.Core.Services.LoginService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Application.Commands.LoginInstructorCommand
{
    public class LoginInstructorCommandHandler : IRequestHandler<LoginInstructorCommand, LoginInstructorViewModel>, ILoginInstructorCommandHandler
    {
        private readonly IAuthService _authService;
        private readonly IInstructorRepository _instructorRepository;

        public LoginInstructorCommandHandler(IAuthService authService, IInstructorRepository instructorRepository)
        {
            _authService = authService;
            _instructorRepository = instructorRepository;
        }

        public async Task<LoginInstructorViewModel> Handle(LoginInstructorCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var instructor = await _instructorRepository.GetInstructorByEmailAndPasswordAsync(request.Id, passwordHash);

            if (instructor == null)
            {
                return null;
            }

            var token = _authService.GenerateJwtToken(instructor.Email, instructor.Role);

            return new LoginInstructorViewModel(instructor.Email, token);
        }

        public async Task<ILoginInstructorViewModel> Handle(ILoginInstructorCommand request, CancellationToken cancellationToken)
        {
            return await Handle((ILoginInstructorCommand)request, cancellationToken);
        }
    }
    
    
}
