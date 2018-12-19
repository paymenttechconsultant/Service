using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Responses
{

    [DataContract()]
    public class ResponseBase
    {
        
        [DataMember]
        public HashSet<Fault> FaultItemList = new HashSet<Fault>();

        public override string ToString()
        {
            string ret="";
            foreach(Fault f in FaultItemList)
            {
                ret += $"[code:({f.ReturnCode}) origin:({f.Origin}) text:({f.StatusText}) debug:({f.DebugMessage}) stack:({f.DebugStackTrace})] ";
            }
            return ret;
        }
    }
     
}
