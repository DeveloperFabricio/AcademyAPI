using Academy.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Application.Queries.GetSportQuery
{
    public class GetSportQuery : IRequest<Sport>
    {
        public int SportId { get; }

        public GetSportQuery(int sportId)
        {
            SportId = sportId;
        }
    }
    
}
