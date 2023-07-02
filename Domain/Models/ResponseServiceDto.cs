using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [DataContract]
    public class ResponseServiceDto
    {
        [DataMember]
        public bool Result { get; set; }
        [DataMember]
        public object Data { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}
