using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Manual_ASP_NET_WEB.Models;

namespace Manual_ASP_NET_WEB.Controllers
{
    public class ConsultasController : Controller
    {
        private Manual_ASP_NET_DBEntities db = new Manual_ASP_NET_DBEntities();

        // GET: Consultas
        public ActionResult Index()
        {
            var consulta = db.Consulta.Include(c => c.Medico).Include(c => c.Paciente);
            return View(consulta.ToList());
        }

        // GET: Consulta/Details/5
        public ActionResult Details(int? PacienteId, int? MedicoId, DateTime? Fecha)
        {
            if (PacienteId == null || MedicoId == null || Fecha == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consulta.Find(PacienteId, MedicoId, Fecha);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // GET: Consultas/Create
        public ActionResult Create()
        {
            ViewBag.IdMedico = new SelectList(db.Medico, "Id", "Nombre");
            ViewBag.IdPaciente = new SelectList(db.Paciente, "Id", "Nombre");
            return View();
        }

        // POST: Consultas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPaciente,IdMedico,Fecha,Sintomas,Diagnostico")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                db.Consulta.Add(consulta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMedico = new SelectList(db.Medico, "Id", "Nombre", consulta.IdMedico);
            ViewBag.IdPaciente = new SelectList(db.Paciente, "Id", "Nombre", consulta.IdPaciente);
            return View(consulta);
        }

        // GET: Consulta/Edit/5
        public ActionResult Edit(int? PacienteId, int? MedicoId, DateTime? Fecha)
        {
            if (PacienteId == null || MedicoId == null || Fecha == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consulta.Find(PacienteId, MedicoId, Fecha);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMedico = new SelectList(db.Medico, "Id", "Nombre", consulta.IdMedico);
            ViewBag.IdPaciente = new SelectList(db.Paciente, "Id", "Nombre", consulta.IdPaciente);
            return View(consulta);
        }

        // POST: Consultas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPaciente,IdMedico,Fecha,Sintomas,Diagnostico")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consulta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMedico = new SelectList(db.Medico, "Id", "Nombre", consulta.IdMedico);
            ViewBag.IdPaciente = new SelectList(db.Paciente, "Id", "Nombre", consulta.IdPaciente);
            return View(consulta);
        }

        // GET: Consulta/Delete/5
        public ActionResult Delete(int? PacienteId, int? MedicoId, DateTime? Fecha)
        {
            if (PacienteId == null || MedicoId == null || Fecha == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consulta.Find(PacienteId, MedicoId, Fecha);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // POST: Consulta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? PacienteId, int? MedicoId, DateTime? Fecha)
        {
            Consulta consulta = db.Consulta.Find(PacienteId, MedicoId,
           Fecha);
            db.Consulta.Remove(consulta);
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
