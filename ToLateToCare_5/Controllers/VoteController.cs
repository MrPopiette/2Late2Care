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
    public class VoteModelsController : Controller
    {
        private ToLateToCare_5Context db = new ToLateToCare_5Context();

        // GET: VoteModels/5
        public int Index(int? ticketId)
        {
            return db.VoteModels.Where(p => p.ticketId == ticketId).Count();
        }

        // GET: VoteModels/5/10
        public ActionResult Details(int? ticketId, int? utilisateurId)
        {
            if (ticketId == null || utilisateurId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoteModel voteModel = db.VoteModels.Where(p => p.ticketId == ticketId && p.utilisateurId == utilisateurId).SingleOrDefault();
            if (voteModel == null)
            {
                return HttpNotFound();
            }
            return View(voteModel);
        }

        // GET: VoteModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VoteModel/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ticketId, utilisateurId")] VoteModel voteModel)
        {
            if (ModelState.IsValid)
            {
                db.VoteModels.Add(voteModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(voteModel);
        }

        // POST: VoteModels/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ticketId, utilisateurId")] VoteModel voteModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voteModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(voteModel);
        }

        // GET: VoteModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoteModel voteModel = db.VoteModels.Find(id);
            if (voteModel == null)
            {
                return HttpNotFound();
            }
            return View(voteModel);
        }

        // POST: VoteModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VoteModel voteModel = db.VoteModels.Find(id);
            db.VoteModels.Remove(voteModel);
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
