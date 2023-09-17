using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcDangNhap.common
{
    [Serializable]
    public class UserLogin
    {
        public string UserName { get; internal set; }
    }
}