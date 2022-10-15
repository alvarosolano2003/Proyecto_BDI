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
    public class EmpleadosController : Controller
    {
        private swatiEntities db = new swatiEntities();

        // GET: Empleados
        public ActionResult Index()
        {
            var empleadoes = db.Empleadoes.Include(e => e.Antiguedad_Empleado).Include(e => e.Cargo_Empleado);
            return View(empleadoes.ToList());
        }

        // GET: Empleados/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            ViewBag.Antiguedad_Empleado_Id = new SelectList(db.Antiguedad_Empleado, "Id", "Concepto");
            ViewBag.Cargo_Empleado_Id = new SelectList(db.Cargo_Empleado, "Id", "Puesto");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo_Empleado,Cedula_Identidad,Codigo_Inss,Nombres,Apellidos,Salario_Bruto,Vacaciones_Acumulados,Cargo_Empleado_Id,Antiguedad_Empleado_Id,CreadoEn,ActualizadoEn")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                empleado.Id = Guid.NewGuid();
                db.Empleadoes.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Antiguedad_Empleado_Id = new SelectList(db.Antiguedad_Empleado, "Id", "Concepto", empleado.Antiguedad_Empleado_Id);
            ViewBag.Cargo_Empleado_Id = new SelectList(db.Cargo_Empleado, "Id", "Puesto", empleado.Cargo_Empleado_Id);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Antiguedad_Empleado_Id = new SelectList(db.Antiguedad_Empleado, "Id", "Concepto", empleado.Antiguedad_Empleado_Id);
            ViewBag.Cargo_Empleado_Id = new SelectList(db.Cargo_Empleado, "Id", "Puesto", empleado.Cargo_Empleado_Id);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo_Empleado,Cedula_Identidad,Codigo_Inss,Nombres,Apellidos,Salario_Bruto,Vacaciones_Acumulados,Cargo_Empleado_Id,Antiguedad_Empleado_Id,CreadoEn,ActualizadoEn")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Antiguedad_Empleado_Id = new SelectList(db.Antiguedad_Empleado, "Id", "Concepto", empleado.Antiguedad_Empleado_Id);
            ViewBag.Cargo_Empleado_Id = new SelectList(db.Cargo_Empleado, "Id", "Puesto", empleado.Cargo_Empleado_Id);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Empleado empleado = db.Empleadoes.Find(id);
            db.Empleadoes.Remove(empleado);
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
