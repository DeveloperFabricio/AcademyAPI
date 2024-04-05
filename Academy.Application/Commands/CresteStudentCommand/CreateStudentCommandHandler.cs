using Academy.Core.Entities;
using Academy.Core.Services.StudentService;
using Academy.Infrasctructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Application.Commands.CresteStudentCommand
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Unit>, ICreateStudentCommandHandler
    {
        private readonly AppDbContext _appDbContext;
        private readonly IUnitOfWork _unitOfWork;

        public CreateStudentCommandHandler(AppDbContext appDbContext, IUnitOfWork unitOfWork)
        {
            _appDbContext = appDbContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            List<Payment> paymentHistory = new List<Payment>();

            var student = new Student(
                    request.Id,
                    request.Name,
                    request.Age,
                    request.SubscriptionPlan,
                    paymentHistory
                );

            _appDbContext.Students.Add(student);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }

        public async Task<Unit> Handle(ICreateStudentCommand request, CancellationToken cancellationToken)
        {
            return await Handle((ICreateStudentCommand)request, cancellationToken);
        }
    }
    
    
}
