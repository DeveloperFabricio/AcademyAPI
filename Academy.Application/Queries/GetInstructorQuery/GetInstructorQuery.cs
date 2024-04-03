using Academy.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Application.Queries.GetInstructorQuery
{
    public class GetInstructorQuery : IRequest<Instructor>
    {
        public int InstructorId { get; }

        public GetInstructorQuery(int intructorId)
        {
            InstructorId = intructorId;
        }
    }

}
