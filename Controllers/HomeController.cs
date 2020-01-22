using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Models;
using BugTracker.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        


    [AllowAnonymous]
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public ViewResult Index() 
        {
            return View("Index");
        }
    }
}
