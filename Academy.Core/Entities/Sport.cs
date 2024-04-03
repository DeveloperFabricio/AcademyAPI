using Academy.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Entities
{
    public class Sport
    {
        public Sport(int id, string name, string description, DifficultLevelEnum difficultLevel)
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
