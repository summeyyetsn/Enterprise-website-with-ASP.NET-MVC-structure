using KurumsalWeb.Models.DataContext;
using KurumsalWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace KurumsalWeb.Controllers
{
    public class ServiceController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();
        // GET: Service
        public ActionResult Index()
        {
            return View(db.Service.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Service service, HttpPostedFileBase ImageURL)
        {
            if (ModelState.IsValid)
            {
                if (ImageURL != null)
                {

                    WebImage img = new WebImage(ImageURL.InputStream);
                    FileInfo imgInfo = new FileInfo(ImageURL.FileName);

                    string ImageName = Path.GetFileNameWithoutExtension(ImageURL.FileName) + imgInfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/Service/" + ImageName);
                    service.ImageURL = "~/Uploads/Service/" + ImageName;
                }

                db.Service.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Warning("No service found to update!");
            }
            var service = db.Service.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int? id, Service service, HttpPostedFileBase ImageURL)
        {
            var s = db.Service.Where(x => x.ServiceId == id).SingleOrDefault();
            if (ModelState.IsValid)
                
            {
                if (ImageURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(s.ImageURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(s.ImageURL));
                    }
                    WebImage img = new WebImage(ImageURL.InputStream);
                    FileInfo imgInfo = new FileInfo(ImageURL.FileName);

                    string ImageName = ImageURL.FileName + imgInfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/Service" + ImageName);

                    s.ImageURL = "/Uploads/Service" + ImageName;
                }
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

               
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            var s = db.Service.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            db.Service.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Index");

            
            return View();
        }

    }
}