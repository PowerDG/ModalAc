using System;
using System.Collections.Generic;
using System.Text;

namespace Research.Authorization
{
    public interface IPermissionAuthorizeData : IAuthorizeData
    {
        string Groups { get; set; }
        string Permissions { get; set; }
    }
}
