using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS.Data;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.Controllers
{
    public class MedicineController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicineController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string search = "")
        { 
            ViewBag.search = search;
            var med = _context.medicines.Where(temp => temp.MedicineName.Contains(search)).ToList();
            return View(med);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Medicine med)
        {
            _context.Add(med);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {
            var med = _context.medicines.Find(id);
            return View(med);
        }

        [HttpPost]
        public IActionResult Update(Medicine med)
        {
            _context.medicines.Update(med);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Cart()
        {

            var c = new List<Medicine>();
            var done = 0;
            var rep = 0;
            var go = 1;

            if (HttpContext.Session.GetString("final") == null)
            {
                done = 1;
            }
            else
            {
                rep = int.Parse(HttpContext.Session.GetString("final"));
            }

            if (done == 1)
            {
                ViewBag.table = "disable";
                ViewBag.data = "empty";
            }
            else
            {
                while (go <= rep)
                {
                    var id = int.Parse(HttpContext.Session.GetString("cart" + go));
                    var med = _context.medicines.Where(temp => temp.MedicineId == id).ToList();
                    c.AddRange(med);
                    go++;
                }
            }
            return View(c);
        }

        public IActionResult Addtocart(int id)
        {
            //var add = "cart";
            var last = HttpContext.Session.GetString("final");
            if (last == null)
            {
                var numb = 1;
                HttpContext.Session.SetString("final", numb.ToString());
                var index = int.Parse(HttpContext.Session.GetString("final"));
                HttpContext.Session.SetString("cart1", id.ToString());
            }
            else
            {
                var num = int.Parse(HttpContext.Session.GetString("final"));
                num++;
                HttpContext.Session.SetString("cart" + num, id.ToString());
                HttpContext.Session.SetString("final", num.ToString());
            }
            return RedirectToAction("Index"); ;
        }

        public IActionResult Details(int id)
        {
            var detailsProduct = _context.medicines.Find(id);
            return View(detailsProduct);
        }
        public IActionResult Delete(long? id)
        {
            var exsitingMedicine = _context.medicines.Find(id);
            return View(exsitingMedicine);
        }
        [HttpPost]
        public IActionResult Delete(long? id, Medicine med)
        {
            var exsitingMedicine = _context.medicines.Find(id);
            _context.medicines.Remove(exsitingMedicine);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }

}
