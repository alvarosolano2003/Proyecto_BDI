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
    public class Seguridad_Social_EmpleadoController : Controller
    {
        private swatiEntities db = new swatiEntities();

        // GET: Seguridad_Social_Empleado
        public ActionResult Index()
        {
            var seguridad_Social_Empleado = db.Seguridad_Social_Empleado.Include(s => s.Empleado);
            return View(seguridad_Social_Empleado.ToList());
        }

        // GET: Seguridad_Social_Empleado/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seguridad_Social_Empleado seguridad_Social_Empleado = db.Seguridad_Social_Empleado.Find(id);
            if (seguridad_Social_Empleado == null)
            {
                return HttpNotFound();
            }
            return View(seguridad_Social_Empleado);
        }

        // GET: Seguridad_Social_Empleado/Create
        public ActionResult Create()
        {
            ViewBag.Empleado_Id = new SelectList(db.Empleadoes, "Id", "Codigo_Empleado");
            return View();
        }

        // POST: Seguridad_Social_Empleado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Deduccion_Base,Deduccion_IR,Pago_Patronal,Fecha_Aplicacion_Impuesto,Empleado_Id,CreadoEn,ActualizadoEn")] Seguridad_Social_Empleado seguridad_Social_Empleado)
        {
            if (ModelState.IsValid)
            {
                seguridad_Social_Empleado.Id = Guid.NewGuid();
                db.Seguridad_Social_Empleado.Add(seguridad_Social_Empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Empleado_Id = new SelectList(db.Empleadoes, "Id", "Codigo_Empleado", seguridad_Social_Empleado.Empleado_Id);
            return View(seguridad_Social_Empleado);
        }

        // GET: Seguridad_Social_Empleado/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seguridad_Social_Empleado seguridad_Social_Empleado = db.Seguridad_Social_Empleado.Find(id);
            if (seguridad_Social_Empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Empleado_Id = new SelectList(db.Empleadoes, "Id", "Codigo_Empleado", seguridad_Social_Empleado.Empleado_Id);
            return View(seguridad_Social_Empleado);
        }

        // POST: Seguridad_Social_Empleado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Deduccion_Base,Deduccion_IR,Pago_Patronal,Fecha_Aplicacion_Impuesto,Empleado_Id,CreadoEn,ActualizadoEn")] Seguridad_Social_Empleado seguridad_Social_Empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seguridad_Social_Empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Empleado_Id = new SelectList(db.Empleadoes, "Id", "Codigo_Empleado", seguridad_Social_Empleado.Empleado_Id);
            return View(seguridad_Social_Empleado);
        }

        // GET: Seguridad_Social_Empleado/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seguridad_Social_Empleado seguridad_Social_Empleado = db.Seguridad_Social_Empleado.Find(id);
            if (seguridad_Social_Empleado == null)
            {
                return HttpNotFound();
            }
            return View(seguridad_Social_Empleado);
        }

        // POST: Seguridad_Social_Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Seguridad_Social_Empleado seguridad_Social_Empleado = db.Seguridad_Social_Empleado.Find(id);
            db.Seguridad_Social_Empleado.Remove(seguridad_Social_Empleado);
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
