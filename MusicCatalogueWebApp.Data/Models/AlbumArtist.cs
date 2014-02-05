using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicCatalogueWebApp.Data.Models
{
    public class AlbumArtist 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int AlbumArtistId { get; set; }

        public int PersonId { get; set; }

        public int RecordingId { get; set; }

        public virtual Recording Album { get; set; }

        public virtual ICollection<Person> Artist { get; set; }
    }
}
