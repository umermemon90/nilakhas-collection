using Microsoft.AspNetCore.Mvc;
using nilakhas_collection.Models;
//using nilakhas_collection.ViewModels;

namespace nilakhas_collection.Controllers
{
    public class AdminDashbaordController : Controller
    {
        private readonly AppDbContext communicate;

        public AdminDashbaordController(AppDbContext communicate)
        {
            this.communicate = communicate;
        }

        public IActionResult mainpagedashbaord()
        {
            mainpageviewclass model = new mainpageviewclass();

            // Total Orders
            model.totalorders = communicate.createneworders.Count(x => x.orderstatus != "Cancelled");

            // Total Billing
            model.totalbilling = communicate.createneworders
                                           .Where(x => x.orderstatus != "Cancelled")
                                           .Sum(x => x.advanced);

            // Pending Orders
            model.pendingorders = communicate.createneworders.Count(x => x.orderstatus == "Pending");

            // Pending Billing
            model.pendingbilling = communicate.createneworders
                                              .Where(x => x.orderstatus != "Cancelled")
                                              .Sum(x => x.duepayment);

            model.orderlist = communicate.createneworders
     .Where(x => x.diliverydate.Date == DateTime.Today.AddDays(7).Date)
     .ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult neworderform()
        {
            var order = new neworderformki
            {
                bookingdate = DateTime.Today,
                diliverydate = DateTime.Today.AddDays(7)
            };

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> neworderform(neworderformki neworder)
        {
            if (!ModelState.IsValid)
            {
                return View(neworder);
            }

            communicate.createneworders.Add(neworder);
            await communicate.SaveChangesAsync();

            // Order number generate karein
            neworder.ordernumber = $"ORD-{neworder.orderid:D4}";


            communicate.Entry(neworder).Property(x => x.ordernumber).IsModified = true;

            await communicate.SaveChangesAsync();

            return RedirectToAction("reciptprint", "AdminDashbaord", new { id = neworder.orderid });
        }
        //recipt pageee
        public IActionResult reciptprint(int id)
        {
            var model = new mainpageviewclass();
            model.orderlist = communicate.createneworders.Where(x => x.orderid == id).ToList();
            if (model.orderlist == null || !model.orderlist.Any())
            {
                return NotFound();
            }
            return View(model);
        }


        //all orders page
        public IActionResult viewallorderspage(int id)
        {
            var model = new mainpageviewclass();
            {
                model.orderlist = communicate.createneworders.OrderByDescending(x => x.orderid == id).ToList();
            }
            ;
            return View(model);
        }


        //view onee order full details
        public IActionResult viewdetailsorder(int id)
        {
            var model = new mainpageviewclass
            {
                orderlist = communicate.createneworders
                    .Where(x => x.orderid == id)
                    .ToList()
            };

            if (!model.orderlist.Any())
            {
                return NotFound();
            }

            return View(model);
        }


        //edit order page
        [HttpGet]
        public IActionResult editorderpage(int id)
        {
            var editorder = communicate.createneworders.Find(id);
            return View(editorder);
        }
        //edit order page post
        [HttpPost]
        public IActionResult editorderpage(neworderformki uptorder)
        {
            communicate.createneworders.Update(uptorder);
            communicate.SaveChanges();
            return RedirectToAction("viewallorderspage", "AdminDashbaord");
        }


        // Delete
        [HttpGet]
        public IActionResult deleteorder(int id)
        {
            var delorder = communicate.createneworders.Find(id);
            if (delorder == null)
            {
                return NotFound();
            }
            return View(delorder);
        }

        // Delete/Cancel Order POST (Status "Cancelled" karne ke liye)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("deleteorder")]
        public IActionResult deleteorderConfirmed(int id)
        {
            var delorder = communicate.createneworders.Find(id);
            if (delorder != null)
            {
                delorder.orderstatus = "Cancelled";
                communicate.SaveChanges();
            }
            return RedirectToAction("viewallorderspage", "AdminDashbaord");
        }


        //workers signup poage

        public IActionResult workersignuppage()
        {
            return View();
        }


    }
}







