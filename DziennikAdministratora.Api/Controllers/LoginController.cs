using System;
using System.Threading.Tasks;
using DziennikAdministratora.Api.Services;
using DziennikAdministratora.Api.ViewModels;
using DziennikAdministratora.Api.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using DziennikAdministratora.Api.Infrastructure.Extensions;

namespace DziennikAdministratora.Api.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IMemoryCache _cache;

        public LoginController(IAccountService accountService, IMemoryCache cache)
        {
            _accountService = accountService;
            _cache = cache;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginViewModel model)
        {
            int result = 0;
            if (!ModelState.IsValid)
            {
                return Json("Logowanie nie powiodło się!");
            }
            model.TokenId = Guid.NewGuid();
            await _accountService.Login(model);

            var jwt = _cache.GetJwt(model.TokenId);
            return Ok(jwt);

        }
    }
}