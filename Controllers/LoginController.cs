using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Controllers
{
    public class LoginController : Controller
    {
        [Route("home/Login")]
        public ViewResult Login()
        {
            return View("Login");

        }

    }
}
