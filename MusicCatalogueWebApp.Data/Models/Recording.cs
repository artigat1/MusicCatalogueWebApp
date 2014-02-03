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
        [Key]
        public int RecordingId { get; set; }

        public string Title { get; set; }

        [Display(Name = "Album Artist")]
        public string AlbumArtist { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Recording Date")]
        public DateTime RecordingDate { get; set; }

        [Display(Name = "Recording Date")]
        public RecordingType Type{get; set;}

        public MediaType Media { get; set; }

        public string Comments { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Created")]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Last Updated")]
        public DateTime LastUpdated { get; set; }

        public virtual ICollection<Person> Performers { get; set; }

        public virtual ICollection<Person> Music { get; set; }

        public virtual ICollection<Person> Lyrics { get; set; }
    }
}
