using Amajuso.API.DTO;
using Amajuso.Domain.Entities;
using Amajuso.Domain.Interfaces;
using Amajuso.Domain.Utils;
using Amajuso.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Amajuso.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;
        private TokenService _tokenService;

        public LoginController(LoginService loginService, TokenService tokenService)
        {
            _loginService = loginService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody] LoginDTO obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = _loginService.ValidCredentials(obj.UserID, obj.AccessKey, obj.GrantType);

                if (user == null)
                {
                    return Unauthorized();
                }

                Token token = _tokenService.GenerateToken(user);
                
                return Ok(token);
           
            }
            catch(ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }
    }
}