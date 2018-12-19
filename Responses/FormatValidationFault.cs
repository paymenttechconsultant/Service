using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Responses
{
    public class FormatValidationFault : ValidationFault
    {
        public string AcceptedFormat;

        public FormatValidationFault(string field, string format) : base(field, "Format", "Field has invalid format")
        {
            AcceptedFormat = format;
        }
    }
}
