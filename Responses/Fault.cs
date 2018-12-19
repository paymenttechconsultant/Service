using System;

namespace Responses
{
    public class Fault
    {
        public string Origin { get; set; }

        public string ReturnCode { get; set; }

        public string StatusText { get; set; }

        public string DebugMessage { get; set; }

        public string DebugStackTrace { get; set; }

        public Fault(string o , string e , string m)
        {
            Origin = o;
            ReturnCode = e;
            StatusText = m;
        }

        public Fault(string e, string m) : this("PaymentService", e, m)
        {
        }
        
        public Fault(Fault f, Exception e)
        {
            Origin = f.Origin;
            ReturnCode = f.ReturnCode;
            StatusText = f.StatusText;
            if (e != null && ConfigurationUtils.ShowStackTrace)
            {
                DebugMessage = e.Message;
                DebugStackTrace = e.StackTrace;
            }            
        }
    }
}