using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Responses
{
    public class RequiredValidationFault : ValidationFault
    {
        public RequiredValidationFault(string field) : base(field, "Required", "Required field is missing")
        {

        }
    }
}
