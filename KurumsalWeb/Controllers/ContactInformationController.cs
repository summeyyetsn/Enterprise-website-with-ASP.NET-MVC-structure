using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KurumsalWeb.Models.DataContext;
using KurumsalWeb.Models.Model;

namespace KurumsalWeb.Controllers
{
    public class ContactInformationController : Controller
    {
        private KurumsalDBContext db = new KurumsalDBContext();

        // GET: ContactInformation
        public ActionResult Index()
        {
            return View(db.ContactInformation.ToList());
        }

        // GET: ContactInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInformation contactInformation = db.ContactInformation.Find(id);
            if (contactInformation == null)
            {
                return HttpNotFound();
            }
            return View(contactInformation);
        }

        // GET: ContactInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactInformation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContactInfoId,Address,Phone,Fax,Facebook,Twitter,Instagram,Whatsapp")] ContactInformation contactInformation)
        {
            if (ModelState.IsValid)
            {
                db.ContactInformation.Add(contactInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactInformation);
        }

        // GET: ContactInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInformation contactInformation = db.ContactInformation.Find(id);
            if (contactInformation == null)
            {
                return HttpNotFound();
            }
            return View(contactInformation);
        }

        // POST: ContactInformation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContactInfoId,Address,Phone,Fax,Facebook,Twitter,Instagram,Whatsapp")] ContactInformation contactInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactInformation);
        }

        // GET: ContactInformation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInformation contactInformation = db.ContactInformation.Find(id);
            if (contactInformation == null)
            {
                return HttpNotFound();
            }
            return View(contactInformation);
        }

        // POST: ContactInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactInformation contactInformation = db.ContactInformation.Find(id);
            db.ContactInformation.Remove(contactInformation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
