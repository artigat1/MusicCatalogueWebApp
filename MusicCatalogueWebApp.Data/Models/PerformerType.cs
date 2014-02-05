using System.ComponentModel.DataAnnotations;

namespace MusicCatalogueWebApp.Data.Models
{
    /// <summary>
    /// The type of people associated with a recording.
    /// </summary>
    public enum PersonType
    {
        /// <summary>
        /// The unknown
        /// </summary>
        [Display(Name = "Select One...")]
        Unknown,

        /// <summary>
        /// The composer
        /// </summary>
        Composer,

        /// <summary>
        /// The lyricist
        /// </summary>
        Lyricist,

        /// <summary>
        /// The performer
        /// </summary>
        Performer,
    }
}
