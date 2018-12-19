using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Responses
{
    /// <summary>
    /// POCO class - data container used for serialization before sending response from health check
    /// </summary>
    [DataContract]
    public class HealthResponse
    {
        /// <summary>
        /// Number of build to display
        /// </summary>
        [DataMember(Order = 0, Name = "Build")]
        public string buildNumber = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        /// <summary>
        /// 
        /// Date of first call to health service
        /// </summary>
        [DataMember(Order = 1, Name = "DateOfFirstHealthCheck")]
        public string firstCall;
        /// <summary>
        /// Number of total calls to health check
        /// </summary>
        [DataMember(Order = 2, Name = "NumberOfTotalCalls")]
        public int callCount;

        /// <summary>
        /// History of calls to main service
        /// </summary>
        [DataMember(Order = 3, Name = "CallHistory")]
        public List<string> callHistory;

        /// <summary>
        /// Builds response with current history
        /// </summary>
        public HealthResponse()
        {
         
        }
    }
}