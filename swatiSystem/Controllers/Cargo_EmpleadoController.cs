using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using swatiSystem;

namespace swatiSystem.Controllers
{
    public class Cargo_EmpleadoController : Controller
    {
        private swatiEntities db = new swatiEntities();

        // GET: Cargo_Empleado
        public ActionResult Index()
        {
            return View(db.Cargo_Empleado.ToList());
        }

        // GET: Cargo_Empleado/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo_Empleado cargo_Empleado = db.Cargo_Empleado.Find(id);
            if (cargo_Empleado == null)
            {
                return HttpNotFound();
            }
            return View(cargo_Empleado);
        }

        // GET: Cargo_Empleado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cargo_Empleado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Puesto,Salario")] Cargo_Empleado cargo_Empleado)
        {
            if (ModelState.IsValid)
            {
                cargo_Empleado.Id = Guid.NewGuid();
                db.Cargo_Empleado.Add(cargo_Empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cargo_Empleado);
        }

        // GET: Cargo_Empleado/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo_Empleado cargo_Empleado = db.Cargo_Empleado.Find(id);
            if (cargo_Empleado == null)
            {
                return HttpNotFound();
            }
            return View(cargo_Empleado);
        }

        // POST: Cargo_Empleado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Puesto,Salario")] Cargo_Empleado cargo_Empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cargo_Empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cargo_Empleado);
        }

        // GET: Cargo_Empleado/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo_Empleado cargo_Empleado = db.Cargo_Empleado.Find(id);
            if (cargo_Empleado == null)
            {
                return HttpNotFound();
            }
            return View(cargo_Empleado);
        }

        // POST: Cargo_Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Cargo_Empleado cargo_Empleado = db.Cargo_Empleado.Find(id);
            db.Cargo_Empleado.Remove(cargo_Empleado);
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
