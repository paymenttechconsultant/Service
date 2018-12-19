using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Responses
{
    public class NumberValidationFault: ValidationFault
    {
        public object Min;
        public object Max;
        
        public NumberValidationFault(string fName, object Min, object Max) : base(fName, "Numeric", "Numeric field value out of bounds")
        {
            this.Min = Min;
            this.Max = Max;
        }
    }
}
