using System;
using System.Collections.Generic;
using System.Text;

namespace Research.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class PermissionAuthorizeAttribute : Attribute, IPermissionAuthorizeData
    {
        public string Policy { get; set; }
        public string Roles { get; set; }
        public string AuthenticationSchemes { get; set; }
        public string Groups { get; set; }
        public string Permissions { get; set; }
    }
}
