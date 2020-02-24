using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToLateToCare_5.Data;
using ToLateToCare_5.Models;

namespace ToLateToCare_5.Controllers
{
    public class UtilisateurModelsController : Controller
    {
        private ToLateToCare_5Context db = new ToLateToCare_5Context();

        // GET: UtilisateurModels
        public ActionResult Index()
        {
            return View(db.UtilisateurModels.ToList());
        }

        // GET: UtilisateurModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UtilisateurModel utilisateurModel = db.UtilisateurModels.Find(id);
            if (utilisateurModel == null)
            {
                return HttpNotFound();
            }
            return View(utilisateurModel);
        }

        // GET: UtilisateurModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UtilisateurModels/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,pseudo,mail")] UtilisateurModel utilisateurModel)
        {
            if (ModelState.IsValid)
            {
                db.UtilisateurModels.Add(utilisateurModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(utilisateurModel);
        }

        // GET: UtilisateurModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UtilisateurModel utilisateurModel = db.UtilisateurModels.Find(id);
            if (utilisateurModel == null)
            {
                return HttpNotFound();
            }
            return View(utilisateurModel);
        }

        // POST: UtilisateurModels/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,pseudo,mail")] UtilisateurModel utilisateurModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utilisateurModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(utilisateurModel);
        }

        // GET: UtilisateurModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UtilisateurModel utilisateurModel = db.UtilisateurModels.Find(id);
            if (utilisateurModel == null)
            {
                return HttpNotFound();
            }
            return View(utilisateurModel);
        }

        // POST: UtilisateurModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UtilisateurModel utilisateurModel = db.UtilisateurModels.Find(id);
            db.UtilisateurModels.Remove(utilisateurModel);
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
