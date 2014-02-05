using System.ComponentModel.DataAnnotations;

namespace MusicCatalogueWebApp.Data.Models
{
    /// <summary>
    /// Type of media that a recording can be saved on
    /// </summary>
    public enum MediaType
    {
        /// <summary>
        /// The unknown
        /// </summary>
        [Display(Name = "Select One...")]
        Unknown,

        /// <summary>
        /// The blu ray
        /// </summary>
        [Display(Name = "Blu-ray")]
        BluRay,

        /// <summary>
        /// The cassette
        /// </summary>
        Cassette,

        /// <summary>
        /// The compact disc
        /// </summary>
        [Display(Name = "Compact Disc")]
        CompactDisc,

        /// <summary>
        /// The digital
        /// </summary>
        Digital,

        /// <summary>
        /// The DVD
        /// </summary>
        Dvd,

        /// <summary>
        /// The mini disc
        /// </summary>
        [Display(Name = "Mini Disc")]
        MiniDisc,
    }
}
