using Microsoft.AspNetCore.Mvc;


using System.Collections.Generic;
using System;
using BaoTangBn.Data.Models;
using BaoTangBn.Data.Dtos;
using Microsoft.AspNetCore.Authorization;
using BaoTangBn.API.Attributes;
using BaoTangBn.Service.UserService;

namespace BaoTangBn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserService _userService;


        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("LoginAndGetToken")]
        public IActionResult Login(AuthenticateRequest user)
        {
            try
            {
                var response = _userService.Authenticate(user);
                //if (response == null)
                //    return BadRequest(new { message = "Username or password is incorrect" });

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.ToString() });
            }
        }

        [HttpPost]
        [Route("AddUser")]
        public bool AddUser(UserDto user)
        {
            var temp = _userService.AddUser(user);


            return temp;
        }


    }
}
