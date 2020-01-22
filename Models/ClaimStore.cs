using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class ClaimStore
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {
            new Claim("Create Role","Create Role"),
            new Claim("Edit Role","Edit Role"),
            new Claim("Delete Role","Delete Role"),
            new Claim("Create Project Role","Create Project Role"),
            new Claim("Edit Project Role","Edit Project Role"),
            new Claim("Create Reported Issues Role","Create Reported Issues Role"),
            new Claim("Edit Reported Issues Role","Edit Reported Issues Role"),
            new Claim("Delete Reported Issues Role","Delete Reported Issues Role"),
            
        };
    }
}
