using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Enums
{
    public enum SpecializationEnum
    {
        [Description("Yoga")]
        Yoga = 1,
        [Description("Pilates")]
        Pilates = 2,
        [Description("CrossFit")]
        CrossFit = 3,
        [Description("Aerobics")]
        Aerobics = 4,
        [Description("PersonalTraining")]
        PersonalTraining = 5,
        [Description("Bodybuilding")]
        Bodybuilding = 6
    }
}
