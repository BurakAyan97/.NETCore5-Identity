using Microsoft.AspNetCore.Identity;
using System;

namespace AspNetCoreIdentity.Entities
{
    public class AppRole:IdentityRole<int>
    {
        public DateTime CreatedTime { get; set; }
    }
}
