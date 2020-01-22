using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Controllers
{
    public class HowToUseController : Controller
    {
        [Authorize]
        [Route("home/HowToUse")]
        [AllowAnonymous]
        public ViewResult HowToUse()
        {
            return View("howToUse");
        }
    }
}
