using Amajuso.API.DTO;
using Amajuso.Domain.Entities;
using Amajuso.Domain.Interfaces;
using Amajuso.Domain.Utils;
using Amajuso.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Amajuso.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;
        private TokenService _tokenService;
        private IService<BlackList> _blackListService;

        public LoginController(LoginService loginService, TokenService tokenService, IService<BlackList> blackListService)
        {
            _loginService = loginService;
            _tokenService = tokenService;
            _blackListService = blackListService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody] LoginDTO obj)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            try
            {
                var user = _loginService.ValidCredentials(obj.UserID, obj.AccessKey, obj.GrantType);

                if (user == null)
                    return Unauthorized();
                
                Token token = _tokenService.GenerateToken(user);
                return Ok(token);
            }
            catch(ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }

        /// <summary>
        /// Realiza logout del usuario
        /// </summary>
        [HttpPost("/api/login/logout")]
        [Authorize("Bearer")]
        [Produces("application/json")]
        public IActionResult Post()
        {
            try
            {
                string token = Request.Headers["Authorization"].Single().Replace("Bearer ", "");
                string refreshToken = User.Claims.First(p => p.Type == ClaimTypes.Hash).Value;
                var id = Convert.ToInt32(User.Identity.Name);

                BlackList blackListObj = new BlackList()
                {
                    Token = token,
                    RefreshToken = refreshToken
                };

                _blackListService.Post(blackListObj);
                return new OkResult();
            }
            catch
            {
                return Unauthorized();
            }
        }
    }
}