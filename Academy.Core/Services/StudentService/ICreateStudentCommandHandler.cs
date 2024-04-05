using MediatR;

namespace Academy.Core.Services.StudentService
{
    public interface ICreateStudentCommandHandler
    {
        Task<Unit> Handle(ICreateStudentCommand request, CancellationToken cancellationToken);
    }
}
