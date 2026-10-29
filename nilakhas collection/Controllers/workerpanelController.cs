using Microsoft.AspNetCore.Mvc;
using nilakhas_collection.Models;

namespace nilakhas_collection.Controllers
{
    public class workerpanelController : Controller
    {
        private readonly AppDbContext communicate;
        public workerpanelController(AppDbContext communicate)
        {
            this.communicate = communicate;
        }



        public IActionResult workerpagedashbaord()
        {
            return View();
        }
    }
}
