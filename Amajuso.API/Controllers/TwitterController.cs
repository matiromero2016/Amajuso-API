using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amajuso.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwitterController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Twitter()
        {
            return View("Views/Twitter.cshtml");
        }
    }
}