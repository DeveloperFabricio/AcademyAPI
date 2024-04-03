using Academy.Core.Entities;
using Academy.Infrasctructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Application.Commands.CreateInstructorCommand
{
    public class CreateInstructorCommandHandler : IRequestHandler<CreateInstructorCommand, Unit>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IUnitOfWork _unitOfWork;

        public CreateInstructorCommandHandler(AppDbContext appDbContext, IUnitOfWork unitOfWork)
        {
            _appDbContext = appDbContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateInstructorCommand request, CancellationToken cancellationToken)
        {
            var instructor = new Instructor(

                request.Id,
                request.Name,
                request.Email,
                request.Password,
                request.Specialization,
                request.Availability,
                request.Description,
                request.Location,
                request.Role
            );

            _appDbContext.Instructors.Add(instructor);
            await _unitOfWork.CommitAsync();
            return Unit.Value;
        }
    }
}
