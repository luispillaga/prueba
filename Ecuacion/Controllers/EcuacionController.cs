using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ecuacion;

namespace Ecuacion.Controllers
{
    public class EcuacionController : Controller
    {
        private EcuacionesEntities db = new EcuacionesEntities();

        // GET: Ecuacion
        public ActionResult Index()
        {
            return View(db.Ecuacions.ToList());
        }

        // GET: Ecuacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ecuacion ecuacion = db.Ecuacions.Find(id);
            if (ecuacion == null)
            {
                return HttpNotFound();
            }
            return View(ecuacion);
        }

        // GET: Ecuacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ecuacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ecuacion_id,ecuacion_a,ecuacion_b,ecuacion_c")] Ecuacion ecuacion)
        {
            if (ModelState.IsValid)
            {
                db.Ecuacions.Add(ecuacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ecuacion);
        }

        // GET: Ecuacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ecuacion ecuacion = db.Ecuacions.Find(id);
            if (ecuacion == null)
            {
                return HttpNotFound();
            }
            return View(ecuacion);
        }

        // POST: Ecuacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ecuacion_id,ecuacion_a,ecuacion_b,ecuacion_c")] Ecuacion ecuacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ecuacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ecuacion);
        }

        // GET: Ecuacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ecuacion ecuacion = db.Ecuacions.Find(id);
            if (ecuacion == null)
            {
                return HttpNotFound();
            }
            return View(ecuacion);
        }

        // POST: Ecuacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ecuacion ecuacion = db.Ecuacions.Find(id);
            db.Ecuacions.Remove(ecuacion);
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
