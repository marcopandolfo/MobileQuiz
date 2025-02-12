﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Quiz.API.Models.Auxiliary;
using Quiz.API.Repository.Interfaces;
using Quiz.Dependencies.Enums;
using Quiz.Dependencies.Models;

using System.Threading.Tasks;

namespace Quiz.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class RegisterController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public RegisterController(IUserRepository userRepository) => _userRepository = userRepository;

        // POST: /Register
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterRequestModel user)
        {
            if (ModelState.IsValid)
            {
                bool loginExists = await _userRepository.CheckIfEmailOrUserExistsTaskAsync(user.Email, user.Username);
                if (loginExists)
                {
                    return BadRequest("Ja existe um usuario cadastrado com esse email ou username");
                }

                UserBaseModel createdUser = await _userRepository.CreateTaskAync(new UserBaseModel
                {
                    Email = user.Email,
                    Level = 0,
                    Password = user.Password,
                    Username = user.Username,
                    UserType = UserTypeEnum.Normal
                });

                return Created($"/users/{createdUser.UserID}", createdUser);
            }
            return BadRequest();
        }
    }
}