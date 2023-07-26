using KurumsalWeb.Models.DataContext;
using KurumsalWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KurumsalWeb.Controllers
{
    public class AboutUsController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();
        // GET: AboutUs
        public ActionResult Index()
        {
            var about = db.AboutUs.ToList();
            return View(about);
        }

        public ActionResult Edit(int id)
        {
            var about = db.AboutUs.Where(x => x.AboutUsId == id).FirstOrDefault();
            return View(about);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, AboutUs about)
        {
            if (ModelState.IsValid)
            {
                var aboutUs = db.AboutUs.Where(x => x.AboutUsId == id).SingleOrDefault();

                aboutUs.Explanation = about.Explanation;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(about);
        }
    }
}