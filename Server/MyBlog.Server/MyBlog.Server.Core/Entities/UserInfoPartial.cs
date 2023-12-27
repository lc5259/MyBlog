using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Server.Core.Entities
{
    public partial class UserInfo
    {
        [DataMember]
        public string is_lock_name { get; set; }

        [DataMember]
        public string password { get; set; }
    }
}
