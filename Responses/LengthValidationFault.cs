namespace Responses
{
    public class LengthValidationFault : ValidationFault
    {
        public int MinLength;
        public int MaxLength;

        public LengthValidationFault(string field, int min, int max): base(field, "Length", "Field has wrong length")
        {
            MinLength = min;
            MaxLength = max;
        }
    }
}
