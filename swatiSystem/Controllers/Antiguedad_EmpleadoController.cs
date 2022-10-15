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
    public class Antiguedad_EmpleadoController : Controller
    {
        private swatiEntities db = new swatiEntities();

        // GET: Antiguedad_Empleado
        public ActionResult Index()
        {
            return View(db.Antiguedad_Empleado.ToList());
        }

        // GET: Antiguedad_Empleado/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Antiguedad_Empleado antiguedad_Empleado = db.Antiguedad_Empleado.Find(id);
            if (antiguedad_Empleado == null)
            {
                return HttpNotFound();
            }
            return View(antiguedad_Empleado);
        }

        // GET: Antiguedad_Empleado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Antiguedad_Empleado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Concepto,Limite_Antiguedad,Porcentage,CreadoEn,ActualizadoEn")] Antiguedad_Empleado antiguedad_Empleado)
        {
            if (ModelState.IsValid)
            {
                antiguedad_Empleado.Id = Guid.NewGuid();
                db.Antiguedad_Empleado.Add(antiguedad_Empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(antiguedad_Empleado);
        }

        // GET: Antiguedad_Empleado/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Antiguedad_Empleado antiguedad_Empleado = db.Antiguedad_Empleado.Find(id);
            if (antiguedad_Empleado == null)
            {
                return HttpNotFound();
            }
            return View(antiguedad_Empleado);
        }

        // POST: Antiguedad_Empleado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Concepto,Limite_Antiguedad,Porcentage,CreadoEn,ActualizadoEn")] Antiguedad_Empleado antiguedad_Empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(antiguedad_Empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(antiguedad_Empleado);
        }

        // GET: Antiguedad_Empleado/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Antiguedad_Empleado antiguedad_Empleado = db.Antiguedad_Empleado.Find(id);
            if (antiguedad_Empleado == null)
            {
                return HttpNotFound();
            }
            return View(antiguedad_Empleado);
        }

        // POST: Antiguedad_Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Antiguedad_Empleado antiguedad_Empleado = db.Antiguedad_Empleado.Find(id);
            db.Antiguedad_Empleado.Remove(antiguedad_Empleado);
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
