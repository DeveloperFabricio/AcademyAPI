using Academy.Core.Entities;
using Academy.Core.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Application.Queries.GetSportQuery
{
    public class GetSportQueryHandler : IRequestHandler<GetSportQuery, Sport>
    {
        private readonly ISportRepository _repository;

        public GetSportQueryHandler(ISportRepository repository)
        {
            _repository = repository;
        }

        public async Task<Sport> Handle(GetSportQuery request, CancellationToken cancellationToken)
        {
            var sport = await _repository.GettByIdAsync(request.SportId);
            if (sport == null)
            {
                throw new ArgumentException(nameof(request));
            }

            return sport;
        }
    }
}
