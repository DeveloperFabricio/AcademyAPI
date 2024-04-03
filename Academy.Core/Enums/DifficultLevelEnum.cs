using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Enums
{
    public enum DifficultLevelEnum
    {
        [Description("Easy")]
        Easy = 1,
        [Description("Medium")]
        Medium = 2,
        [Description("Hard")]
        Hard = 3
    }
}
