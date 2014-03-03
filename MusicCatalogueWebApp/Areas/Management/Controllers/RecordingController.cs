using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicCatalogueWebApp.Areas.Management.Models;
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
            return View(
                await db.Recordings
                    .OrderBy(x => x.Title)
                    .ThenBy(x => x.Type)
                    .ThenBy(x => x.RecordingDate)
                    .ToListAsync());
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
        public async Task<ActionResult> Create(Recording model)
        {
            if (!ModelState.IsValid) 
                return View(model);

            model.CreatedOn = DateTime.Now;
            model.LastUpdated = DateTime.Now;
            db.Recordings.Add(model);
            await db.SaveChangesAsync();
            return RedirectToAction("Edit", new {id = model.RecordingId});
        }

        // GET: /Management/Recording/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(await GetViewModelAsync(id));
        }

        // POST: /Management/Recording/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RecordingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(await GetViewModelAsync(model.Recording.RecordingId));
            }

            model.Recording.LastUpdated = DateTime.Now;
            db.Entry(model.Recording).State = EntityState.Modified;
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

        // POST: /Management/Recording/AddPerson
        [HttpPost, ActionName("AddPerson")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPerson()
        {
            var recordingId = int.Parse(Request["recordingId"]);
            var nameToAdd = Request["Name"];
            if (string.IsNullOrEmpty(nameToAdd))
            {
                ModelState.AddModelError("Name", "Name is required");
                return View("Edit", await GetViewModelAsync(recordingId));
            }

            var personExists =
                await db.People.Where(p => p.Name.Equals(nameToAdd, StringComparison.CurrentCultureIgnoreCase))
                    .SingleOrDefaultAsync();

            var albumArtist = new AlbumArtist
            {
                RecordingId = recordingId,
                Role = (AlbumArtistType)Enum.Parse(typeof(AlbumArtistType), Request["personType"]),
                CreatedOn = DateTime.Now,
                LastUpdated = DateTime.Now,
            };

            if (personExists != null)
            {
                albumArtist.PersonId = personExists.PersonId;
            }
            else
            {
                var person = new Person
                {
                    Name = nameToAdd,
                    CreatedOn = DateTime.Now,
                    LastUpdated = DateTime.Now,
                };

                db.People.Add(person);
                await db.SaveChangesAsync();
                albumArtist.PersonId = person.PersonId;
            }

            db.AlbumArtist.Add(albumArtist);
            await db.SaveChangesAsync();

            return RedirectToAction("Edit", new {id = albumArtist.RecordingId});
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Gets the view model.
        /// </summary>
        /// <param name="recordingId">The recording identifier.</param>
        /// <returns></returns>
        private async Task<RecordingViewModel> GetViewModelAsync(int? recordingId)
        {
            if (recordingId == null) 
                throw new ArgumentNullException("recordingId");

            var viewModel = new RecordingViewModel();
            Recording recording = await db.Recordings.FindAsync(recordingId);
            if (recording == null)
            {
                throw new DataException(
                    string.Format("Failed to find recording with id: '{0}'", recordingId));
            }

            viewModel.Recording = recording;

            viewModel.Composers =
                (from p in db.People
                 join albums in db.AlbumArtist
                     on p.PersonId equals albums.PersonId
                 where (albums.Role == AlbumArtistType.Composer
                        && albums.RecordingId == recordingId)
                 select p).ToList();

            viewModel.Lyricist =
                (from p in db.People
                 join albums in db.AlbumArtist
                     on p.PersonId equals albums.PersonId
                 where (albums.Role == AlbumArtistType.Lyricist
                        && albums.RecordingId == recordingId)
                 select p).ToList();

            viewModel.Performers =
                (from p in db.People
                 join albums in db.AlbumArtist
                     on p.PersonId equals albums.PersonId
                 where (albums.Role == AlbumArtistType.Performer
                        && albums.RecordingId == recordingId)
                 select p).ToList();
            return viewModel;
        }
    }
}
