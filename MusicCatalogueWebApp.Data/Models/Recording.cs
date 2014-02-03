using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicCatalogueWebApp.Data.Models
{
    /// <summary
    /// 
    /// </summary>
    public class Recording
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecordingId { get; set; }

        public string Title { get; set; }

        public string AlbumArtist { get; set; }

        public DateTime RecordingDate { get; set; }

        public RecordingType Type{get; set;}

        public MediaType Media { get; set; }

        public string Comments { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime LastUpdated { get; set; }

        public virtual ICollection<Person> Performers { get; set; }

        public virtual ICollection<Person> Music { get; set; }

        public virtual ICollection<Person> Lyrics { get; set; }
    }
}
