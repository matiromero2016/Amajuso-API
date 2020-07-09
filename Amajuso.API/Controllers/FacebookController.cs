using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace amajuso_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacebookController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Facebook()
        {
            return View("Views/Facebook.cshtml");
        }
    }
}