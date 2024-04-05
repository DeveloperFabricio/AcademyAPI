using Academy.Core.Enums;
using Academy.Core.Services.SportService;
using MediatR;

namespace Academy.Application.Commands.CresteSportCommand
{
    public class CreateSportCommand : IRequest<Unit>, ICreateSportCommand
    {
        public CreateSportCommand(int id,
            string name,
            string description,
            DifficultLevelEnum difficultLevel)

        {
            Id = id;
            Name = name;
            Description = description;
            DifficultLevel = difficultLevel;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DifficultLevelEnum DifficultLevel { get; set; }
    }
}
