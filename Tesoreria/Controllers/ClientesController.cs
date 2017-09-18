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
    public class ClientesController : Controller
    {
        private class client
        {
            public int IDCliente { get; set; }
            public string Idenficacion { get; set; }
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
        }

        private TesoreriaContext db = new TesoreriaContext();

        // GET: Clientes
        public ActionResult Index()
        {
            return View(db.Clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCliente,Idenficacion,Nombres,Apellidos")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCliente,Idenficacion,Nombres,Apellidos")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clientes clientes = db.Clientes.Find(id);
            db.Clientes.Remove(clientes);
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

        public PartialViewResult Recibos(Int32 IDCliente) 
        {
            Recibos recibos = new Recibos();
            recibos.IDCliente = IDCliente;

            return PartialView(recibos);
        
        }

        public ActionResult GuardarRecibo(Recibos recibos) 
        {
            db.Entry(recibos).State = EntityState.Added;
            db.SaveChanges();

            return RedirectToAction("/Details/" + recibos.IDCliente.ToString());
        }

         [HttpGet]
         [Route("ListadoCliente")]
        public JsonResult ListadoCliente() 
        {
            var clientes = db.Clientes
                .Select(x => new client { IDCliente = x.IDCliente, 
                                          Idenficacion = x.Idenficacion,
                                          Nombres = x.Nombres,
                                          Apellidos = x.Apellidos
                })
                .OrderBy(x => x.IDCliente);             

            //return new JsonResult { Data = clientes, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return Json( clientes, JsonRequestBehavior.AllowGet);        
        }

        public ActionResult List() 
        {
            return View();
        }
    }
}
