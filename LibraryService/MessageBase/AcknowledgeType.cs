
using System.Runtime.Serialization;

namespace LibraryService.MessageBase
{
   
        /// <summary>
        /// Enumeration of message response acknowledgements. This is a simple
        /// enumerated values indicating success of failure.
        /// </summary>
        [DataContract(Namespace = "http://www.artizani-media.com/types/svc/2012/08/")]
        public enum AcknowledgeType
        {
            /// <summary>
            /// Represents an failed response.
            /// </summary>
            [EnumMember]
            Failure = 0,

            /// <summary>
            /// Represents a successful response.
            /// </summary>
            [EnumMember]
            Success = 1
        }
    
}