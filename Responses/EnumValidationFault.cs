using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Responses
{
    public class EnumValidationFault : ValidationFault
    {
        public string AcceptedValues;

        public EnumValidationFault(string field, string values) : base(field, "Value", "Field has invalid value")
        {
            AcceptedValues = values;
        }
        
    }
}
