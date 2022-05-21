using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using UserMicroservice.Authentication;
using UserMicroservice.Models;
using UserMicroservice.Services;

namespace UserMicroservice.Controllers
{

    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UserContoller : ControllerBase
    {
        private readonly IUserService _service;

        public UserContoller(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> getUsers()
        {
            return Ok(_service.GetAllUsers());
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<int> getUser([FromRoute] string id)
        {
            User user = _service.GetUserById(id);
            if (user != null)
            {
                return Ok(_service.GetUserById(id));
            }
            return NotFound();
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public ActionResult<string> login(UserCred user)
        {
            var jwt = _service.login(user.Username, user.Password);
            if(jwt != null)
            {
                return Ok(jwt);

            }
            return Unauthorized("Login credentials are incorrect!");
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult<string> register(User user)
        {
            _service.RegisterUser(user);
            return Ok("User successfully registered!");
        }
    }
}
