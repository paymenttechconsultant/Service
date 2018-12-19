using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Responses
{
    public class CharacterValidationFault : ValidationFault
    {
        public string ForbiddenCharacters;

        public CharacterValidationFault(string field, string forbiddenChars) : base(field, "BadChar", "Field contains invalid characters")
        {
            ForbiddenCharacters = forbiddenChars;
        }
    }
}
