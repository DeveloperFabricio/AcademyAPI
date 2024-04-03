using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Core.IntegrationEvents
{
    public sealed record SendEmailEvent
    (
        string Origin,
        string Destiny,
        string Subject,
        string Body
     );
}

