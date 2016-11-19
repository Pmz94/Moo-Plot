using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MooPlot.Models;

namespace MooPlot.Controllers
{
    public class enfermedadesController : Controller
    {
        private ganadoEntities db = new ganadoEntities();

        // GET: enfermedades
        public ActionResult Index()
        {
            return View(db.enfermedades.ToList());
        }

        // GET: enfermedades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enfermedade enfermedade = db.enfermedades.Find(id);
            if (enfermedade == null)
            {
                return HttpNotFound();
            }
            return View(enfermedade);
        }

        // GET: enfermedades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: enfermedades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_enfermedad,Nom_Enfermedad")] enfermedade enfermedade)
        {
            if (ModelState.IsValid)
            {
                db.enfermedades.Add(enfermedade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(enfermedade);
        }

        // GET: enfermedades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enfermedade enfermedade = db.enfermedades.Find(id);
            if (enfermedade == null)
            {
                return HttpNotFound();
            }
            return View(enfermedade);
        }

        // POST: enfermedades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_enfermedad,Nom_Enfermedad")] enfermedade enfermedade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enfermedade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enfermedade);
        }

        // GET: enfermedades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enfermedade enfermedade = db.enfermedades.Find(id);
            if (enfermedade == null)
            {
                return HttpNotFound();
            }
            return View(enfermedade);
        }

        // POST: enfermedades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            enfermedade enfermedade = db.enfermedades.Find(id);
            db.enfermedades.Remove(enfermedade);
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
