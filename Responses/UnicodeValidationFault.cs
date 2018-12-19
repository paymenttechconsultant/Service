
namespace Responses
{
    public class UnicodeValidationFault : ValidationFault
    {
        public UnicodeValidationFault(string field) : base(field, "UnicodeNotAllowed", "Field contains Unicode character(s) which is not allowed")
        {
        }
    }
}
