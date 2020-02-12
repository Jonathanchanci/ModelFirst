using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelFirst.Models;

namespace ModelFirst.Controllers
{
    public class PeliculasController : Controller
    {
        private PeliculasModelContainer db = new PeliculasModelContainer();

        // GET: Peliculas
        public ActionResult Index()
        {
            var peliculasSet = db.PeliculasSet.Include(p => p.Director);
            return View(peliculasSet.ToList());
        }

        // GET: Peliculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peliculas peliculas = db.PeliculasSet.Find(id);
            if (peliculas == null)
            {
                return HttpNotFound();
            }
            return View(peliculas);
        }

        // GET: Peliculas/Create
        public ActionResult Create()
        {
            ViewBag.DirectorId = new SelectList(db.DirectorSet, "Id", "Nombre");
            return View();
        }

        // POST: Peliculas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Anio,DirectorId")] Peliculas peliculas)
        {
            if (ModelState.IsValid)
            {
                db.PeliculasSet.Add(peliculas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DirectorId = new SelectList(db.DirectorSet, "Id", "Nombre", peliculas.DirectorId);
            return View(peliculas);
        }

        // GET: Peliculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peliculas peliculas = db.PeliculasSet.Find(id);
            if (peliculas == null)
            {
                return HttpNotFound();
            }
            ViewBag.DirectorId = new SelectList(db.DirectorSet, "Id", "Nombre", peliculas.DirectorId);
            return View(peliculas);
        }

        // POST: Peliculas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Anio,DirectorId")] Peliculas peliculas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(peliculas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DirectorId = new SelectList(db.DirectorSet, "Id", "Nombre", peliculas.DirectorId);
            return View(peliculas);
        }

        // GET: Peliculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peliculas peliculas = db.PeliculasSet.Find(id);
            if (peliculas == null)
            {
                return HttpNotFound();
            }
            return View(peliculas);
        }

        // POST: Peliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Peliculas peliculas = db.PeliculasSet.Find(id);
            db.PeliculasSet.Remove(peliculas);
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
