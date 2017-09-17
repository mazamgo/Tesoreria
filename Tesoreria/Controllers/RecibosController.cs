using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tesoreria.Models;

namespace Tesoreria.Controllers
{
    public class RecibosController : Controller
    {
        private TesoreriaContext db = new TesoreriaContext();

        // GET: Recibos
        public ActionResult Index()
        {
            var recibos = db.Recibos.Include(r => r.Clientes);
            return View(recibos.ToList());
        }

        // GET: Recibos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recibos recibos = db.Recibos.Find(id);
            if (recibos == null)
            {
                return HttpNotFound();
            }
            return View(recibos);
        }

        // GET: Recibos/Create
        public ActionResult Create()
        {
            ViewBag.IDCliente = new SelectList(db.Clientes, "IDCliente", "Idenficacion");
            return View();
        }

        // POST: Recibos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDRecibo,IDCliente,NoRecibo,Monto")] Recibos recibos)
        {
            if (ModelState.IsValid)
            {
                db.Recibos.Add(recibos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCliente = new SelectList(db.Clientes, "IDCliente", "Idenficacion", recibos.IDCliente);
            return View(recibos);
        }

        // GET: Recibos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recibos recibos = db.Recibos.Find(id);
            if (recibos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCliente = new SelectList(db.Clientes, "IDCliente", "Idenficacion", recibos.IDCliente);
            return View(recibos);
        }

        // POST: Recibos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDRecibo,IDCliente,NoRecibo,Monto")] Recibos recibos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recibos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCliente = new SelectList(db.Clientes, "IDCliente", "Idenficacion", recibos.IDCliente);
            return View(recibos);
        }

        // GET: Recibos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recibos recibos = db.Recibos.Find(id);
            if (recibos == null)
            {
                return HttpNotFound();
            }
            return View(recibos);
        }

        // POST: Recibos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recibos recibos = db.Recibos.Find(id);
            db.Recibos.Remove(recibos);
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
