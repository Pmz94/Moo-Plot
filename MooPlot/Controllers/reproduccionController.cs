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
    public class reproduccionController : Controller
    {
        private ganadoEntities db = new ganadoEntities();

        // GET: reproduccion
        public ActionResult Index()
        {
            var reproduccions = db.reproduccions.Include(r => r.animale);
            return View(reproduccions.ToList());
        }

        // GET: reproduccion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reproduccion reproduccion = db.reproduccions.Find(id);
            if (reproduccion == null)
            {
                return HttpNotFound();
            }
            return View(reproduccion);
        }

        // GET: reproduccion/Create
        public ActionResult Create()
        {
            ViewBag.ID_Animal = new SelectList(db.animales, "ID_Animal", "Especie");
            return View();
        }

        // POST: reproduccion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Reprod,ID_Animal,ID_Padre,Embarazos,Partos,Abortos,Partos_Complicaciones")] reproduccion reproduccion)
        {
            if (ModelState.IsValid)
            {
                db.reproduccions.Add(reproduccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Animal = new SelectList(db.animales, "ID_Animal", "Especie", reproduccion.ID_Animal);
            return View(reproduccion);
        }

        // GET: reproduccion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reproduccion reproduccion = db.reproduccions.Find(id);
            if (reproduccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Animal = new SelectList(db.animales, "ID_Animal", "Especie", reproduccion.ID_Animal);
            return View(reproduccion);
        }

        // POST: reproduccion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Reprod,ID_Animal,ID_Padre,Embarazos,Partos,Abortos,Partos_Complicaciones")] reproduccion reproduccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reproduccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Animal = new SelectList(db.animales, "ID_Animal", "Especie", reproduccion.ID_Animal);
            return View(reproduccion);
        }

        // GET: reproduccion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reproduccion reproduccion = db.reproduccions.Find(id);
            if (reproduccion == null)
            {
                return HttpNotFound();
            }
            return View(reproduccion);
        }

        // POST: reproduccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reproduccion reproduccion = db.reproduccions.Find(id);
            db.reproduccions.Remove(reproduccion);
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
