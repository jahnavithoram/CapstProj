using CapstProj.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstProj.Controllers
{
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> roleManager;
        //   UserManager<IdentityUser> userManager;
        private readonly ApplicationDbContext _context;

        public RoleController(RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            this.roleManager = roleManager;
            _context = context;
        }

        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }
        public IActionResult Users()

        { 
          //  var context = new ApplicationDbContext();
            //_context = context;
            var allUsers = _context.Users.ToList();
            return View(allUsers); }
        
    }
}
