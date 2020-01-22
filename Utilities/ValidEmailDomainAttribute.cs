using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Utilities
{
    public class ValidEmailDomainAttribute : ValidationAttribute
    {
        //Allowed Domain names for logging in 
        //              hotmail.com
        private readonly string allowedDomain;
        //              gmail.com
        private readonly string allowedDomain1;
        //              yahoo.com
        private readonly string allowedDomain2;
        //               live.com
        private readonly string allowedDomain3;

        public ValidEmailDomainAttribute(string allowedDomain ,
            string allowedDomain1, 
            string allowedDomain2,
            string allowedDomain3
            )
        {
            this.allowedDomain = allowedDomain;
            this.allowedDomain1 = allowedDomain1;
            this.allowedDomain2 = allowedDomain2;
            this.allowedDomain3 = allowedDomain3;


        }
        public override bool IsValid(object value)
        {
            string[] strings = value.ToString().Split('@');
            return strings[1].ToUpper() == allowedDomain.ToUpper() || 
                   strings[1].ToUpper() == allowedDomain1.ToUpper() ||
                   strings[1].ToUpper() == allowedDomain2.ToUpper() ||
                   strings[1].ToUpper() == allowedDomain3.ToUpper();
        }


    }
}
