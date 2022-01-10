using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Tribo.Controllers
{
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Roles()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await _roleManager.CreateAsync(role);
            return RedirectToAction("Roles");
        }
    }
}
