using System;
using System.Linq;
using System.Security.Claims;
using DziennikAdministratora.Repository.Model;
using Microsoft.AspNetCore.Mvc;

namespace DziennikAdministratora.Api.Infrastructure.Extensions
{
    public static class ControllerExtensions
    {
        public static Guid GetUserId(this Controller controller) => 
            Guid.Parse(controller.HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
    }
}