using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Responses
{
    public abstract class ValidationFault : Fault
    {
        public string FieldName;
        public string ErrorType;

        public ValidationFault(string fName, string type, string status) :base ("HPSA", "FieldValidationError", status)
        {
            ErrorType = type;
            FieldName = fName;
        }
    }
}
