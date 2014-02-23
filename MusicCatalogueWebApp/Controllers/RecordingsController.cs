using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicCatalogueWebApp.Data.Models;
using MusicCatalogueWebApp.Models;

namespace MusicCatalogueWebApp.Controllers
{   
    public class RecordingsController : Controller
    {
        private MusicCatalogueWebAppContext context = new MusicCatalogueWebAppContext();

        //
        // GET: /Recordings/

        public ViewResult Index()
        {
            return View(context.Recordings.Include(recording => recording.Performers).Include(recording => recording.Music).Include(recording => recording.Lyrics).ToList());
        }

        //
        // GET: /Recordings/Details/5

        public ViewResult Details(int id)
        {
            Recording recording = context.Recordings.Single(x => x.RecordingId == id);
            return View(recording);
        }

        //
        // GET: /Recordings/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Recordings/Create

        [HttpPost]
        public ActionResult Create(Recording recording)
        {
            if (ModelState.IsValid)
            {
                context.Recordings.Add(recording);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(recording);
        }
        
        //
        // GET: /Recordings/Edit/5
 
        public ActionResult Edit(int id)
        {
            Recording recording = context.Recordings.Single(x => x.RecordingId == id);
            return View(recording);
        }

        //
        // POST: /Recordings/Edit/5

        [HttpPost]
        public ActionResult Edit(Recording recording)
        {
            if (ModelState.IsValid)
            {
                context.Entry(recording).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recording);
        }

        //
        // GET: /Recordings/Delete/5
 
        public ActionResult Delete(int id)
        {
            Recording recording = context.Recordings.Single(x => x.RecordingId == id);
            return View(recording);
        }

        //
        // POST: /Recordings/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Recording recording = context.Recordings.Single(x => x.RecordingId == id);
            context.Recordings.Remove(recording);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}