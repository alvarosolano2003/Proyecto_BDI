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
    public class Horas_Extras_EmpleadoController : Controller
    {
        private swatiEntities db = new swatiEntities();

        // GET: Horas_Extras_Empleado
        public ActionResult Index()
        {
            var horas_Extras_Empleado = db.Horas_Extras_Empleado.Include(h => h.Empleado);
            return View(horas_Extras_Empleado.ToList());
        }

        // GET: Horas_Extras_Empleado/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horas_Extras_Empleado horas_Extras_Empleado = db.Horas_Extras_Empleado.Find(id);
            if (horas_Extras_Empleado == null)
            {
                return HttpNotFound();
            }
            return View(horas_Extras_Empleado);
        }

        // GET: Horas_Extras_Empleado/Create
        public ActionResult Create()
        {
            ViewBag.Empleado_Id = new SelectList(db.Empleadoes, "Id", "Codigo_Empleado");
            return View();
        }

        // POST: Horas_Extras_Empleado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Pago_Por_Hora,Concepto,Inicio_Laboral,Finalizacion_Laboral,Fecha_Laboral,Empleado_Id,CreadoEn,ActualizadoEn")] Horas_Extras_Empleado horas_Extras_Empleado)
        {
            if (ModelState.IsValid)
            {
                horas_Extras_Empleado.Id = Guid.NewGuid();
                db.Horas_Extras_Empleado.Add(horas_Extras_Empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Empleado_Id = new SelectList(db.Empleadoes, "Id", "Codigo_Empleado", horas_Extras_Empleado.Empleado_Id);
            return View(horas_Extras_Empleado);
        }

        // GET: Horas_Extras_Empleado/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horas_Extras_Empleado horas_Extras_Empleado = db.Horas_Extras_Empleado.Find(id);
            if (horas_Extras_Empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Empleado_Id = new SelectList(db.Empleadoes, "Id", "Codigo_Empleado", horas_Extras_Empleado.Empleado_Id);
            return View(horas_Extras_Empleado);
        }

        // POST: Horas_Extras_Empleado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Pago_Por_Hora,Concepto,Inicio_Laboral,Finalizacion_Laboral,Fecha_Laboral,Empleado_Id,CreadoEn,ActualizadoEn")] Horas_Extras_Empleado horas_Extras_Empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horas_Extras_Empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Empleado_Id = new SelectList(db.Empleadoes, "Id", "Codigo_Empleado", horas_Extras_Empleado.Empleado_Id);
            return View(horas_Extras_Empleado);
        }

        // GET: Horas_Extras_Empleado/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horas_Extras_Empleado horas_Extras_Empleado = db.Horas_Extras_Empleado.Find(id);
            if (horas_Extras_Empleado == null)
            {
                return HttpNotFound();
            }
            return View(horas_Extras_Empleado);
        }

        // POST: Horas_Extras_Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Horas_Extras_Empleado horas_Extras_Empleado = db.Horas_Extras_Empleado.Find(id);
            db.Horas_Extras_Empleado.Remove(horas_Extras_Empleado);
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
