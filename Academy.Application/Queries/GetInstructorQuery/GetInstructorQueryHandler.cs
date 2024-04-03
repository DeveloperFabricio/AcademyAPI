using Academy.Core.Entities;
using Academy.Core.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Application.Queries.GetInstructorQuery
{
    public class GetInstructorQueryHandler : IRequestHandler<GetInstructorQuery, Instructor>
    {
        private readonly IInstructorRepository _repository;

        public GetInstructorQueryHandler(IInstructorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Instructor> Handle(GetInstructorQuery request, CancellationToken cancellationToken)
        {
            var instructor = await _repository.GettByIdAsync(request.InstructorId);
            if (instructor == null)
            {
                throw new ArgumentException(nameof(request));
            }

            return instructor;
        }
    }

}
