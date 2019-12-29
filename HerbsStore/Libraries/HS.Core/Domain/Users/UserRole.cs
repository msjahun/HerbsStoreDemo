using System;
using Microsoft.AspNetCore.Identity;

namespace HerbsStore.Libraries.HS.Core.Domain.Users
{
    public class UserRole : IdentityRole
    {

        public string Access { get; set; }
        public bool IsSystemRole { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
