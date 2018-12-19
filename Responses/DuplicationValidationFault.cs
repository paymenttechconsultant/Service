using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Responses
{
    public class DuplicationValidationFault : ValidationFault
    {
        public ICollection<object> DuplicatedItems;

        public DuplicationValidationFault(string fName, string text, ICollection<object> duplicates) : base(fName, "DuplicatedItem", text)
        {
            DuplicatedItems = duplicates;
        }
    }
}
