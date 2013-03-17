using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.Library.Services
{
    interface IUser
    {
        string UserName { get; set; }
        string Id { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string Lastname { get; set; }
        

    }
}
