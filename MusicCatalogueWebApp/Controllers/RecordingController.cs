using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicCatalogueWebApp.Data.Models;
using MusicCatalogueWebApp.Data;

namespace MusicCatalogueWebApp.Controllers
{
    public class RecordingController : Controller
    {
        private MusicCatalogueContext db = new MusicCatalogueContext();

        // GET: /Recording/
        public ActionResult Index()
        {
            return View(db.Recordings.ToList());
        }

        // GET: /Recording/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recording recording = db.Recordings.Find(id);
            if (recording == null)
            {
                return HttpNotFound();
            }
            return View(recording);
        }

        // GET: /Recording/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Recording/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="RecordingId,Title,AlbumArtist,RecordingDate,Type,Media,Comments,CreatedOn,LastUpdated")] Recording recording)
        {
            if (ModelState.IsValid)
            {
                db.Recordings.Add(recording);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recording);
        }

        // GET: /Recording/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recording recording = db.Recordings.Find(id);
            if (recording == null)
            {
                return HttpNotFound();
            }
            return View(recording);
        }

        // POST: /Recording/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="RecordingId,Title,AlbumArtist,RecordingDate,Type,Media,Comments,CreatedOn,LastUpdated")] Recording recording)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recording).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recording);
        }

        // GET: /Recording/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recording recording = db.Recordings.Find(id);
            if (recording == null)
            {
                return HttpNotFound();
            }
            return View(recording);
        }

        // POST: /Recording/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recording recording = db.Recordings.Find(id);
            db.Recordings.Remove(recording);
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
