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
    public class animalesController : Controller
    {
        private ganadoEntities db = new ganadoEntities();

        // GET: animales
        public ActionResult Index()
        {
            return View(db.animales.ToList());
        }

        // GET: animales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            animale animale = db.animales.Find(id);
            if (animale == null)
            {
                return HttpNotFound();
            }
            return View(animale);
        }

        // GET: animales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: animales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //ira karnal esta madre we cuando editas la base de datos tambien tienes que poner y quitar los nombres de las columnas que agregas o quitas
        public ActionResult Create([Bind(Include = "ID_Animal,Num_Caravana,Especie,Raza,Genero,Fecha_Nac,Peso_Nac,IMC_Actual,Observaciones,Cod_Signia,Status,Fecha_Muerte,Imagen__Ruta_,Imagen__Foto_,Peso_Actual,Celo")] animale animale)
        {
            if (ModelState.IsValid)
            {
                db.animales.Add(animale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(animale);
        }

        // GET: animales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            animale animale = db.animales.Find(id);
            if (animale == null)
            {
                return HttpNotFound();
            }
            return View(animale);
        }

        // POST: animales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Animal,Num_Caravana,Especie,Raza,Genero,Fecha_Nac,Peso_Nac,IMC_Actual,Observaciones,Cod_Signia,Status,Fecha_Muerte,Imagen__Ruta_,Imagen__Foto_,Peso_Actual,Celo")] animale animale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(animale);
        }

        // GET: animales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            animale animale = db.animales.Find(id);
            if (animale == null)
            {
                return HttpNotFound();
            }
            return View(animale);
        }

        // POST: animales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            animale animale = db.animales.Find(id);
            db.animales.Remove(animale);
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
