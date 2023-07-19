using KurumsalWeb.Models.DataContext;
using KurumsalWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace KurumsalWeb.Controllers
{
    public class SystemIdentityController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();
        // GET: SystemIdentity
        public ActionResult Index()
        {
            return View(db.SystemIdentity.ToList());
        }

        // GET: SystemIdentity/Edit/5
        public ActionResult Edit(int id)
        {
            var SystemIdentity = db.SystemIdentity.Where(x => x.IdentityId == id).SingleOrDefault();
            return View(SystemIdentity);
        }

        // POST: SystemIdentity/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, SystemIdentity SystemIdentity, HttpPostedFileBase LogoURL)
        {
            if (ModelState.IsValid)
            {
                var i = db.SystemIdentity.Where(x => x.IdentityId == id).SingleOrDefault();
                if(LogoURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(i.LogoURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(i.LogoURL));
                    }
                    WebImage img = new WebImage(LogoURL.InputStream);
                    FileInfo imgInfo = new FileInfo(LogoURL.FileName);

                    string logoName = Path.GetFileNameWithoutExtension(LogoURL.FileName) + imgInfo.Extension;
                    img.Resize(100, 100);
                    img.Save("~/Uploads/SystemIdentityImg/" + logoName);
                    i.LogoURL= "~/Uploads/SystemIdentityImg/" + logoName;
                }

                i.Title = SystemIdentity.Title;
                i.Keywords = SystemIdentity.Keywords;
                i.Description = SystemIdentity.Description;
                i.SuperScription = SystemIdentity.SuperScription;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(SystemIdentity);
        }


    }
}
