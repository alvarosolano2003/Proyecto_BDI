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
    public class Solicitud_Vacaciones_EmpleadoController : Controller
    {
        private swatiEntities db = new swatiEntities();

        // GET: Solicitud_Vacaciones_Empleado
        public ActionResult Index()
        {
            var solicitud_Vacaciones_Empleado = db.Solicitud_Vacaciones_Empleado.Include(s => s.Empleado);
            return View(solicitud_Vacaciones_Empleado.ToList());
        }

        // GET: Solicitud_Vacaciones_Empleado/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud_Vacaciones_Empleado solicitud_Vacaciones_Empleado = db.Solicitud_Vacaciones_Empleado.Find(id);
            if (solicitud_Vacaciones_Empleado == null)
            {
                return HttpNotFound();
            }
            return View(solicitud_Vacaciones_Empleado);
        }

        // GET: Solicitud_Vacaciones_Empleado/Create
        public ActionResult Create()
        {
            ViewBag.Empleado_Id = new SelectList(db.Empleadoes, "Id", "Codigo_Empleado");
            return View();
        }

        // POST: Solicitud_Vacaciones_Empleado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Dias_De_Vacaciones,Vacaciones_Pagadas,Fecha_Aplicacion,Empleado_Id,CreadoEn,ActualizadoEn")] Solicitud_Vacaciones_Empleado solicitud_Vacaciones_Empleado)
        {
            if (ModelState.IsValid)
            {
                solicitud_Vacaciones_Empleado.Id = Guid.NewGuid();
                db.Solicitud_Vacaciones_Empleado.Add(solicitud_Vacaciones_Empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Empleado_Id = new SelectList(db.Empleadoes, "Id", "Codigo_Empleado", solicitud_Vacaciones_Empleado.Empleado_Id);
            return View(solicitud_Vacaciones_Empleado);
        }

        // GET: Solicitud_Vacaciones_Empleado/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud_Vacaciones_Empleado solicitud_Vacaciones_Empleado = db.Solicitud_Vacaciones_Empleado.Find(id);
            if (solicitud_Vacaciones_Empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Empleado_Id = new SelectList(db.Empleadoes, "Id", "Codigo_Empleado", solicitud_Vacaciones_Empleado.Empleado_Id);
            return View(solicitud_Vacaciones_Empleado);
        }

        // POST: Solicitud_Vacaciones_Empleado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Dias_De_Vacaciones,Vacaciones_Pagadas,Fecha_Aplicacion,Empleado_Id,CreadoEn,ActualizadoEn")] Solicitud_Vacaciones_Empleado solicitud_Vacaciones_Empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitud_Vacaciones_Empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Empleado_Id = new SelectList(db.Empleadoes, "Id", "Codigo_Empleado", solicitud_Vacaciones_Empleado.Empleado_Id);
            return View(solicitud_Vacaciones_Empleado);
        }

        // GET: Solicitud_Vacaciones_Empleado/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud_Vacaciones_Empleado solicitud_Vacaciones_Empleado = db.Solicitud_Vacaciones_Empleado.Find(id);
            if (solicitud_Vacaciones_Empleado == null)
            {
                return HttpNotFound();
            }
            return View(solicitud_Vacaciones_Empleado);
        }

        // POST: Solicitud_Vacaciones_Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Solicitud_Vacaciones_Empleado solicitud_Vacaciones_Empleado = db.Solicitud_Vacaciones_Empleado.Find(id);
            db.Solicitud_Vacaciones_Empleado.Remove(solicitud_Vacaciones_Empleado);
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
