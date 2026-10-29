using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using nilakhas_collection.Models;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace nilakhas_collection.Controllers
{
    public class WorkersController : Controller
    {
        private readonly AppDbContext communicate;
        private readonly IWebHostEnvironment env;

        public WorkersController(AppDbContext communicate, IWebHostEnvironment env)
        {
            this.communicate = communicate;
            this.env = env;
        }

        [HttpGet]
        public IActionResult workersignuppage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> workersignuppage(workerssignup newworker)
        {
            // 1. Image presence validation
            if (newworker.workerimage == null || newworker.workerimage.Length == 0)
            {
                ModelState.AddModelError("workerimage", "Please upload an image.");
                return View(newworker);
            }

            var extension = Path.GetExtension(newworker.workerimage.FileName).ToLowerInvariant();
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };

            if (!allowedExtensions.Contains(extension))
            {
                ModelState.AddModelError("workerimage", "Only image files are allowed (jpg, jpeg, png, gif, webp).");
            }
            else if (newworker.workerimage.Length > 2 * 1024 * 1024) // 2MB limit
            {
                ModelState.AddModelError("workerimage", "Image size should not exceed 2MB.");
            }

            // Model state check (agar koi field miss ho)
            if (!ModelState.IsValid)
            {
                // Yahan aap debugging ke liye errors check kar sakte hain
                return View(newworker);
            }

            string? saveFilePath = null;

            try
            {
                // 2. Password Hashing
                var passwordHasher = new PasswordHasher<workerssignup>();
                newworker.password = passwordHasher.HashPassword(newworker, newworker.password);

                // 3. Image Saving Logic
                var uploadsfolder = Path.Combine(env.WebRootPath, "ASITS", "workerimages");
                if (!Directory.Exists(uploadsfolder))
                {
                    Directory.CreateDirectory(uploadsfolder);
                }

                var filename = $"{Guid.NewGuid():N}{extension}";
                saveFilePath = Path.Combine(uploadsfolder, filename);

                await using (var stream = new FileStream(saveFilePath, FileMode.Create))
                {
                    await newworker.workerimage.CopyToAsync(stream);
                }

                newworker.workerimagename = filename;

                // 4. Save to Database
                await communicate.workersignups.AddAsync(newworker);
                await communicate.SaveChangesAsync();

                return RedirectToAction("mainpagedashbaord", "AdminDashbaord");
            }
            catch (Exception ex)
            {
                if (saveFilePath != null && System.IO.File.Exists(saveFilePath))
                {
                    try { System.IO.File.Delete(saveFilePath); } catch { }
                }

                ModelState.AddModelError("", "Worker could not be assigned. Error: " + ex.Message);
                return View(newworker);
            }
        }

        //worker cards only signup page
        [HttpGet]
        public async Task<IActionResult> workerscardssignup()
        {
            var workersList = await communicate.workersignups.ToListAsync();
            return View(workersList);
        }

        //worker login page
        [HttpGet]
        public IActionResult workerloginpage()
        {
            
            return View();
        }

        //worker login page post method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> workerloginpage(WorkerLoginModel workerlogin)
        {
            if (!ModelState.IsValid)
            {
                return View(workerlogin);
            }

            // Find worker by username
            var worker = await communicate.workersignups.FirstOrDefaultAsync(w => w.workername == workerlogin.workername);

            if (worker == null)
            {
                ModelState.AddModelError("workername", "Worker not found.");
                return View(workerlogin);
            }

            // Verify hashed password
            var passwordHasher = new PasswordHasher<workerssignup>();
            var verificationResult = passwordHasher.VerifyHashedPassword(worker, worker.password, workerlogin.password);

            if (verificationResult == PasswordVerificationResult.Failed)
            {
                ModelState.AddModelError("password", "Invalid password.");
                return View(workerlogin);
            }

            return RedirectToAction("workerpagedashbaord", "workerpanel");
        }
    }
}