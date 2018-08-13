using System;
using System.Threading.Tasks;
using DziennikAdministratora.Api.Services;
using DziennikAdministratora.Api.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DziennikAdministratora.Api.Controllers
{
    public class UserController : Controller
    {
        private readonly IAccountService _accountService;

        public UserController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        [Route("api/admin/User/GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _accountService.GetUsersAsync();

            return Ok(users);
        }

        [HttpGet]
        [Route("api/admin/User/GetUserById/{Id}")]
        public async Task<IActionResult> GetUserById(Guid Id)
        {
            var user = await _accountService.GetUserByIdAsync(Id);

            return Ok(user);
        }

        [HttpPost]
        [Route("api/admin/User/AddUserAsync")]
        public async Task<IActionResult> AddUserAsync([FromBody]RegisterViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _accountService.RegisterUserAsync(model);

            return CreatedAtAction("GetUsers", new { id = model.Email});
        }

        [HttpDelete]
        [Route("api/admin/User/DeleteUsersASync/{Id}")]
        public async Task<IActionResult> DeleteUsersASync(Guid Id)
        {
            await _accountService.DeleteUserAsync(Id);

            return NoContent();
        }
    }
}