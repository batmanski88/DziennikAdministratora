using System;
using System.Threading.Tasks;
using DziennikAdministratora.Api.Services;
using DziennikAdministratora.Api.ViewModels;
using DziennikAdministratora.Api.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DziennikAdministratora.Api.Controllers
{   
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IRoleService _roleService;

        public LoginController(IAccountService accountService, IRoleService roleService)
        {
            _accountService = accountService;
            _roleService = roleService;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return Json("Logowanie nie powiodło się!");
            }

            await _accountService.Login(model);
            var jwt = await _accountService.GetJwtAsync(model.Email);

            return Ok(jwt);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserRolesAsync([FromBody]Guid userId)
        {
            var userRoles = await _roleService.GetUserRolesAsync(userId);
            return Ok(userRoles);
        }
    }
}