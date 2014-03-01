using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicCatalogueWebApp.Data.Models
{
    /// <summary>
    /// The mapper that links a person to a recording and their role on the recording
    /// </summary>
    public class AlbumArtist 
    {
        /// <summary>
        /// Gets or sets the album artist identifier.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int AlbumArtistId { get; set; }

        /// <summary>
        /// Gets or sets the recording identifier.
        /// </summary>
        public int RecordingId { get; set; }

        /// <summary>
        /// Gets or sets the album <see cref="Recording"/>.
        /// </summary>
        [ForeignKey("RecordingId")]
        public virtual Recording Album { get; set; }

        /// <summary>
        /// Gets or sets the person identifier.
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Gets or sets the artist <see cref="Person"/>.
        /// </summary>
        [ForeignKey("PersonId")]
        public virtual Person Artist { get; set; }

        /// <summary>
        /// Gets or sets the role of the person <see cref="AlbumArtistType"/>.
        /// </summary>
        [Required]
        public AlbumArtistType Role { get; set; }

        /// <summary>
        /// Gets or sets the created time.
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Created")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the last updated time.
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Last Updated")]
        public DateTime LastUpdated { get; set; }
    }
}
