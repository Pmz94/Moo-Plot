using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MooPlot.Models;

namespace MooPlot
{
    public class animales_enfermosController : Controller
    {
        private ganadoEntities db = new ganadoEntities();

        // GET: animales_enfermos
        public ActionResult Index()
        {
            var animales_enfermos = db.animales_enfermos.Include(a => a.enfermedade).Include(a => a.animale);
            return View(animales_enfermos.ToList());
        }

        // GET: animales_enfermos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            animales_enfermos animales_enfermos = db.animales_enfermos.Find(id);
            if (animales_enfermos == null)
            {
                return HttpNotFound();
            }
            return View(animales_enfermos);
        }

        // GET: animales_enfermos/Create
        public ActionResult Create()
        {
            ViewBag.ID_enfermedad = new SelectList(db.enfermedades, "ID_enfermedad", "Nom_Enfermedad");
            ViewBag.ID_animal = new SelectList(db.animales, "ID_Animal", "Especie");
            return View();
        }

        // POST: animales_enfermos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_enfermo,ID_animal,ID_enfermedad,Descripcion")] animales_enfermos animales_enfermos)
        {
            if (ModelState.IsValid)
            {
                db.animales_enfermos.Add(animales_enfermos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_enfermedad = new SelectList(db.enfermedades, "ID_enfermedad", "Nom_Enfermedad", animales_enfermos.ID_enfermedad);
            ViewBag.ID_animal = new SelectList(db.animales, "ID_Animal", "Especie", animales_enfermos.ID_animal);
            return View(animales_enfermos);
        }

        // GET: animales_enfermos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            animales_enfermos animales_enfermos = db.animales_enfermos.Find(id);
            if (animales_enfermos == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_enfermedad = new SelectList(db.enfermedades, "ID_enfermedad", "Nom_Enfermedad", animales_enfermos.ID_enfermedad);
            ViewBag.ID_animal = new SelectList(db.animales, "ID_Animal", "Especie", animales_enfermos.ID_animal);
            return View(animales_enfermos);
        }

        // POST: animales_enfermos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_enfermo,ID_animal,ID_enfermedad,Descripcion")] animales_enfermos animales_enfermos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animales_enfermos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_enfermedad = new SelectList(db.enfermedades, "ID_enfermedad", "Nom_Enfermedad", animales_enfermos.ID_enfermedad);
            ViewBag.ID_animal = new SelectList(db.animales, "ID_Animal", "Especie", animales_enfermos.ID_animal);
            return View(animales_enfermos);
        }

        // GET: animales_enfermos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            animales_enfermos animales_enfermos = db.animales_enfermos.Find(id);
            if (animales_enfermos == null)
            {
                return HttpNotFound();
            }
            return View(animales_enfermos);
        }

        // POST: animales_enfermos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            animales_enfermos animales_enfermos = db.animales_enfermos.Find(id);
            db.animales_enfermos.Remove(animales_enfermos);
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
