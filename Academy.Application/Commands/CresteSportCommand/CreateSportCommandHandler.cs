using Academy.Core.Entities;
using Academy.Infrasctructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Application.Commands.CresteSportCommand
{
    public class CreateSportCommandHandler : IRequestHandler<CreateSportCommand, Unit>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSportCommandHandler(AppDbContext appDbContext, IUnitOfWork unitOfWork)
        {
            _appDbContext = appDbContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateSportCommand request, CancellationToken cancellationToken)
        {
            var sport = new Sport(

                request.Id,
                request.Name,
                request.Description,
                request.DifficultLevel
            );

            _appDbContext.Sports.Add(sport);
            await _unitOfWork.CommitAsync();
            return Unit.Value;
        }

    }
}


    

