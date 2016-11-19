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
    public class ranchosController : Controller
    {
        private ganadoEntities db = new ganadoEntities();

        // GET: ranchos
        public ActionResult Index()
        {
            return View(db.ranchos.ToList());
        }

        // GET: ranchos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rancho rancho = db.ranchos.Find(id);
            if (rancho == null)
            {
                return HttpNotFound();
            }
            return View(rancho);
        }

        // GET: ranchos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ranchos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Rancho,Nombre_Rancho,Estado,Ciudad,Hectareas,Dueño")] rancho rancho)
        {
            if (ModelState.IsValid)
            {
                db.ranchos.Add(rancho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rancho);
        }

        // GET: ranchos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rancho rancho = db.ranchos.Find(id);
            if (rancho == null)
            {
                return HttpNotFound();
            }
            return View(rancho);
        }

        // POST: ranchos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Rancho,Nombre_Rancho,Estado,Ciudad,Hectareas,Dueño")] rancho rancho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rancho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rancho);
        }

        // GET: ranchos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rancho rancho = db.ranchos.Find(id);
            if (rancho == null)
            {
                return HttpNotFound();
            }
            return View(rancho);
        }

        // POST: ranchos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rancho rancho = db.ranchos.Find(id);
            db.ranchos.Remove(rancho);
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
