using System.Threading.Tasks;
using DziennikAdministratora.Api.Services;
using DziennikAdministratora.Api.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DziennikAdministratora.Api.Controllers
{   
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IAccountService _accountService;

        public LoginController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _accountService.Login(model);
            var jwt = await _accountService.GetJwtAsync(model.Email);

            return Json(jwt);
        }
    }
}