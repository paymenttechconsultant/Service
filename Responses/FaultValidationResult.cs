using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Responses
{
    public class FaultValidationResult: ValidationResult
    {
        public List<ValidationFault> fault = new List<ValidationFault>();
        public FaultValidationResult(): base("dummy")
        {
           
        }

        public FaultValidationResult(ValidationFault f) : base("dummy")
        {
            fault.Add(f);
        }
    }
}
