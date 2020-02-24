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
    public class TagModelsController : Controller
    {
        private ToLateToCare_5Context db = new ToLateToCare_5Context();

        // GET: TagModels
        public ActionResult Index()
        {
            return View(db.TagModels.ToList());
        }

        // GET: TagModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TagModel tagModel = db.TagModels.Find(id);
            if (tagModel == null)
            {
                return HttpNotFound();
            }
            return View(tagModel);
        }

        // GET: TagModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TagModels/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,libelle")] TagModel tagModel)
        {
            if (ModelState.IsValid)
            {
                db.TagModels.Add(tagModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tagModel);
        }

        // GET: TagModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TagModel tagModel = db.TagModels.Find(id);
            if (tagModel == null)
            {
                return HttpNotFound();
            }
            return View(tagModel);
        }

        // POST: TagModels/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,libelle")] TagModel tagModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tagModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tagModel);
        }

        // GET: TagModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TagModel tagModel = db.TagModels.Find(id);
            if (tagModel == null)
            {
                return HttpNotFound();
            }
            return View(tagModel);
        }

        // POST: TagModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TagModel tagModel = db.TagModels.Find(id);
            db.TagModels.Remove(tagModel);
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
