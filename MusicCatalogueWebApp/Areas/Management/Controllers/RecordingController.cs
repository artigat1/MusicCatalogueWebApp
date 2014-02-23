using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicCatalogueWebApp.Data.Models;
using MusicCatalogueWebApp.Data;

namespace MusicCatalogueWebApp.Areas.Management.Controllers
{
    public class RecordingController : Controller
    {
        private MusicCatalogueContext db = new MusicCatalogueContext();

        // GET: /Management/Recording/
        public async Task<ActionResult> Index()
        {
            return View(await db.Recordings.ToListAsync());
        }

        // GET: /Management/Recording/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recording recording = await db.Recordings.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include="RecordingId,Title,AlbumArtist,RecordingDate,Type,Media,Comments,AlbumImageUrl,CreatedOn,LastUpdated")] Recording recording)
        {
            if (!ModelState.IsValid) 
                return View(recording);

            recording.CreatedOn = DateTime.Now;
            recording.LastUpdated = DateTime.Now;
            db.Recordings.Add(recording);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: /Management/Recording/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recording recording = await db.Recordings.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include="RecordingId,Title,AlbumArtist,RecordingDate,Type,Media,Comments,AlbumImageUrl,CreatedOn,LastUpdated")] Recording recording)
        {
            if (!ModelState.IsValid) 
                return View(recording);

            recording.LastUpdated = DateTime.Now;
            db.Entry(recording).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: /Management/Recording/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recording recording = await db.Recordings.FindAsync(id);
            if (recording == null)
            {
                return HttpNotFound();
            }
            return View(recording);
        }

        // POST: /Management/Recording/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Recording recording = await db.Recordings.FindAsync(id);
            db.Recordings.Remove(recording);
            await db.SaveChangesAsync();
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
