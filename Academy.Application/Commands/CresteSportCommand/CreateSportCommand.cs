using Academy.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Application.Commands.CresteSportCommand
{
    public class CreateSportCommand : IRequest<Unit>
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
