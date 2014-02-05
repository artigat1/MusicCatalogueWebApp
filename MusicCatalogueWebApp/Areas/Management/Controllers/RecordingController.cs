using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MusicCatalogueWebApp.Data.Models;
using MusicCatalogueWebApp.Data;

namespace MusicCatalogueWebApp.Areas.Management.Controllers
{
    public class RecordingController : Controller
    {
        private readonly MusicCatalogueContext _db = new MusicCatalogueContext();

        // GET: /Management/Recording/
        public ActionResult Index()
        {
            return View(_db.Recordings.ToList());
        }

        // GET: /Management/Recording/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recording recording = _db.Recordings.Find(id);
            if (recording == null)
            {
                return HttpNotFound();
            }

            return View(recording);
        }

        // GET: /Management/Recording/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Management/Recording/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="RecordingId,Title,AlbumArtist,RecordingDate,Type,Media,Comments")] Recording recording)
        {
            if (!ModelState.IsValid) return View(recording);

            recording.CreatedOn = DateTime.Now;
            recording.LastUpdated = DateTime.Now;

            _db.Recordings.Add(recording);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: /Management/Recording/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recording recording = _db.Recordings.Find(id);
            if (recording == null)
            {
                return HttpNotFound();
            }

            return View(recording);
        }

        // POST: /Management/Recording/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="RecordingId,Title,AlbumArtist,RecordingDate,Type,Media,Comments")] Recording recording)
        {
            if (!ModelState.IsValid) return View(recording);

            recording.LastUpdated = DateTime.Now;

            _db.Entry(recording).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: /Management/Recording/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recording recording = _db.Recordings.Find(id);
            if (recording == null)
            {
                return HttpNotFound();
            }
            return View(recording);
        }

        // POST: /Management/Recording/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recording recording = _db.Recordings.Find(id);
            _db.Recordings.Remove(recording);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
