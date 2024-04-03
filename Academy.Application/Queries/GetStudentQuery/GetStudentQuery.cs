using Academy.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Application.Queries.GetStudentQuery
{
    public class GetStudentQuery : IRequest<Student>
    {
        public int StudentId { get; }

        public GetStudentQuery(int studentId)
        {
            StudentId = studentId;
        }
    }
    
}

