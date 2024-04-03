using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.Enums
{
    public enum SubscriptionPlanEnum
    {
        [Description("Basic")]
        Basic = 1,
        [Description("Standard")]
        Standard = 2,
        [Description("Premium")]
        Premium = 3
    }
}
