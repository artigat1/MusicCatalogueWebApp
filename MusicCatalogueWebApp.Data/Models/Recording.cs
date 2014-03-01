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

        [Display(Name = "Title")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Album Artist")]
        public string AlbumArtist { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Recording Date")]
        public DateTime RecordingDate { get; set; }

        [Display(Name = "Recording Type")]
        [Required]
        public RecordingType Type{get; set;}

        [Display(Name = "Recording Media")]
        [Required]
        public MediaType Media { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }

        [Display(Name = "Cover Url")]
        public string AlbumImageUrl { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Created")]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Last Updated")]
        public DateTime LastUpdated { get; set; }

        [Display(Name = "Performers")]
        public virtual ICollection<Person> Performers { get; set; }

        [Display(Name = "Composer")]
        public virtual ICollection<Person> Music { get; set; }

        [Display(Name = "Lyricist")]
        public virtual ICollection<Person> Lyrics { get; set; }
    }
}
