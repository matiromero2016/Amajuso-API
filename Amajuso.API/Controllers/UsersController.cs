using System;
using System.Net;
using System.Threading.Tasks;
using Amajuso.API.DTO;
using Amajuso.Domain.Entities;
using Amajuso.Domain.Interfaces;
using Amajuso.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amajuso.API.Controllers {    
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase 
    {
        private IService<User> _userService;
        public UsersController(IService<User> userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        [Produces("application/json")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var obj = await _userService.Get(long.Parse(HttpContext.User.Identity.Name));
                UserDTO user = new UserDTO(obj);
                return new ObjectResult(user);
            }
            catch(ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpGet]
        [Produces("application/json")]
        [Route("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try {
                var obj = await _userService.Get(id);
                UserDTO user = new UserDTO(obj);
                return new ObjectResult(user);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }

        /// <summary>
        /// Crea un nuevo usuario
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Produces("application/json")]
        // [ProducesResponseType(201, Type = typeof(AccountDTO))]
        // [ProducesResponseType(400, Type = typeof(ReturnMessage))]
        public async Task<IActionResult> Post([FromBody] UserPostDTO item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                var userExist = await _userService.Exist(x => x.Email == item.Email);
                if (userExist)
                {
                    var errorMessage = "Ya existe el email";
                    return BadRequest(errorMessage);
                }
                User obj = await _userService.Post(item.ToModel());
                return Ok(new UserDTO(obj));
            }
            catch(ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }

        }

    }
}