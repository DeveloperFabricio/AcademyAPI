using Academy.Core.Entities;
using Academy.Core.Services.InstructorService;
using Academy.Infrasctructure.Persistence;
using MediatR;

namespace Academy.Application.Commands.CreateInstructorCommand
{
    public class CreateInstructorCommandHandler : IRequestHandler<CreateInstructorCommand, Unit>, IInstructorService
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
            return await CreateInstructorAsync(request);
        }

        public async Task<Unit> CreateInstructorAsync(ICreateInstructorCommand request)
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
