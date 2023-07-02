using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [DataContract]
    public class UserDeleteDto
    {
        [DataMember]
        public int Id { get; set; }
    }
}
