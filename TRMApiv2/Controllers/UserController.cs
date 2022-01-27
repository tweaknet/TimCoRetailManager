﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TRMApiv2.Data;
using TRMApiv2.Models;
using TRMDataManager.Library.DataAccess;
using TRMDataManager.Library.Models;

namespace TRMApiv2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserData _userData;
        private readonly ILogger<UserController> _logger;

        public UserController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IUserData userData, ILogger<UserController> logger)
        {
            _context = context;
            _userData = userData;
            _logger = logger;
            _userManager = userManager;
        }
        [HttpGet]
        public UserModel GetById()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _userData.GetUserById(userId).First();
        }
        public record UserRegistrationModel(string FirstName, string LastName, string EmailAddress, string Password);
        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserRegistrationModel user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(user.EmailAddress);
                if (existingUser == null)
                {
                    IdentityUser newUser = new()
                    {
                        Email = user.EmailAddress,
                        EmailConfirmed = true,
                        UserName = user.EmailAddress
                    };
                    IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);
                    if (result.Succeeded)
                    {
                        existingUser = await _userManager.FindByEmailAsync(user.EmailAddress);
                        if(existingUser == null)
                        {
                            return BadRequest();
                        }
                        UserModel u = new()
                        {
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            EmailAddress = user.EmailAddress,
                            Id = existingUser.Id
                        };
                        _userData.CreateUser(u);
                        return Ok();
                    }
                }
            }
            return BadRequest();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("Admin/GetAllUsers")]
        public List<ApplicationUserModel> GetAllUsers()
        {
            List<ApplicationUserModel> output = new();
                var users = _context.Users.ToList();
                var userRoles = from ur in _context.UserRoles
                                join r in _context.Roles on ur.RoleId equals r.Id
                                select new {ur.UserId, ur.RoleId,r.Name};
                foreach (var user in users)
                {
                    ApplicationUserModel u = new()
                    {
                        Id = user.Id,
                        Email = user.Email
                    };
                u.Roles = userRoles.Where(x => x.UserId == u.Id).ToDictionary(key => key.RoleId,val => val.Name);
                    output.Add(u);
                }
            return output;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("Admin/GetAllRoles")]
        public Dictionary<string, string> GetAllRoles()
        {
                return _context.Roles.ToDictionary(x => x.Id, x => x.Name);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("Admin/AddRole")]
        public async Task AddRole(UserRolePairModel pairing)
        {
            string loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var loggedInUser = _userData.GetUserById(loggedInUserId).First();
            var user = await _userManager.FindByIdAsync(pairing.UserId);
            _logger.LogInformation("Admin{Admin} added user {user} to role {Role}", loggedInUserId, user.Id, pairing.RoleName);
            await _userManager.AddToRoleAsync(user, pairing.RoleName);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("Admin/RemoveRole")]
        public async Task RemoveRole(UserRolePairModel pairing)
        {
            string loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(pairing.UserId);
            _logger.LogInformation("Admin{Admin} removed user {user} from role {Role}", loggedInUserId, user.Id, pairing.RoleName);
            await _userManager.RemoveFromRoleAsync(user, pairing.RoleName);
        }
    }
}
