using System;
using System.Threading.Tasks;
using DziennikAdministratora.Api.Services;
using DziennikAdministratora.Api.ViewModels.AccountViewModels;
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
        [Route("api/admin/User/GetUsers")]
        public async Task<JsonResult> GetUsers()
        {
            var users = await _accountService.GetUsersAsync();

            return Json(users);
        }

        [HttpGet]
        [Route("api/admin/User/GetUserById/{Id}")]
        public async Task<JsonResult> GetUserById(Guid Id)
        {
            var user = await _accountService.GetUserByIdAsync(Id);

            return Json(user);
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