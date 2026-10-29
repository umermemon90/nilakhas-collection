using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nilakhas_collection.Models;

namespace nilakhas_collection.Controllers
{
    public class ADMINLOGINController : Controller
    {

        private readonly AppDbContext _context;
        private readonly PasswordHasher<adminlogin> _passwordHasher;

        public ADMINLOGINController(AppDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<adminlogin>();
        }
        // Show login page
        [HttpGet]

        public IActionResult ADMINLOGIN()
        {
            return View();
        }

        // Handle login submission
        [HttpPost]
       
        public async Task<IActionResult>ADMINLOGIN(adminlogin admin)
        {
            if (!ModelState.IsValid)
            {
                return View(admin);
            }
            //username database se check
            var existingAdmin = await _context.adminlogins
                .FirstOrDefaultAsync(x => x.username == admin.username);


            if (existingAdmin == null) { 
                ModelState.AddModelError("username", "Username is Wrong.");
                return View(admin);
            }

            ////pasword check databse se
            ////var Result = _passwordHasher.VerifyHashedPassword
            ////    (existingAdmin,
            ////    existingAdmin.password,
            ////    admin.password
            //ModelState.AddModelError("password", ""
            //    );

            if (existingAdmin.password != admin.password)
            {
                ModelState.AddModelError("password", "Incorrect password.");
                return View(existingAdmin);
            }

            return RedirectToAction("mainpagedashbaord", "AdminDashbaord");
        }
        
    }
}
