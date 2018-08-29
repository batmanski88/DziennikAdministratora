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
        private readonly IAdminService _adminService;

        public UserController(IAccountService accountService, IAdminService adminService)
        {
            _accountService = accountService;
            _adminService = adminService;
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        [Route("api/admin/User/GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _adminService.GetUsersAsync();

            return Ok(users);
        }

        [HttpGet]
        [Route("api/admin/User/GetUserById/{Id}")]
        public async Task<IActionResult> GetUserById(Guid Id)
        {
            var user = await _adminService.GetUserByIdAsync(Id);

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

            await _adminService.RegisterUserAsync(model);

            return CreatedAtAction("GetUsers", new { id = model.Email});
        }

        [HttpDelete]
        [Route("api/admin/User/DeleteUsersASync/{Id}")]
        public async Task<IActionResult> DeleteUsersASync(Guid Id)
        {
            await _adminService.DeleteUserAsync(Id);

            return NoContent();
        }

        [HttpPost]
        [Route("api/admin/User/ResetPassword/{Id}")]
        public async Task<IActionResult> ResetPassword(Guid Id)
        {
            var result = await _adminService.ResetPassword(Id);

            return Ok(result);
        }
    }
}