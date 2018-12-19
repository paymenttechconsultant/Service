using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Responses
{
    public class NullValidatorFault : ValidationFault
    {
        public string fieldName;

        public NullValidatorFault(string fieldName) : base(fieldName, "Validator", "No matching validator found for this field")
        {
            this.fieldName = fieldName;
        }
    }
}
