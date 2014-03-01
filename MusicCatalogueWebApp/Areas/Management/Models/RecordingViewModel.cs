using MusicCatalogueWebApp.Data.Models;
using System.Collections.Generic;

namespace MusicCatalogueWebApp.Areas.Management.Models
{
    public class RecordingViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecordingViewModel"/> class.
        /// </summary>
        public RecordingViewModel()
        {
            NewPerformer = new Person();
            NewComposer = new Person();
            NewLyricist = new Person();
        }

        public Recording Recording { get; set; }

        public ICollection<Person> Performers { get; set; }

        public ICollection<Person> Composers { get; set; }

        public ICollection<Person> Lyricist { get; set; }

        public Person NewPerformer { get; set; }

        public Person NewComposer { get; set; }

        public Person NewLyricist { get; set; }
    }
}