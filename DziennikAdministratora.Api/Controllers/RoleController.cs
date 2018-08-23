using System;
using System.Threading.Tasks;
using DziennikAdministratora.Api.Services;
using DziennikAdministratora.Api.ViewModels.RolesViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DziennikAdministratora.Api.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [Route("api/admin/Role/GetRoles")]
        public async Task<JsonResult> GetRoles()
        {
            var roles = await _roleService.GetRolesAsync();

            return Json(roles);
        }

        [HttpGet]
        [Route("api/admin/Role/GetRoleById/{Id}")]
        public async Task<JsonResult> GetRoleById(Guid Id)
        {
            var role = await _roleService.GetRoleByIdAsync(Id);

            return Json(role);
        }

        [HttpPost]
        [Route("api/admin/Role/AddRole")]
        public async Task<IActionResult> AddRole([FromBody]RoleViewModel model)
        {
            await _roleService.AddRoleAsync(model);

            return CreatedAtAction("GetRoles", new { id = model.RoleId});
        }

        [HttpPut]
        [Route("api/admin/Role/UpdateRole")]
        public async Task<IActionResult> UpdateRole([FromBody]RoleViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _roleService.UpdateRolesAsync(model);

            return new OkObjectResult("Rola pomyślnie utworzona!");
        }

        [HttpDelete]
        [Route("api/admin/Role/DeleteRole/{Id}")]
        public async Task<IActionResult> DeleteRole(Guid Id)
        {
            await _roleService.RemoveRoleAsync(Id);

            return NoContent();
        }
    }
}