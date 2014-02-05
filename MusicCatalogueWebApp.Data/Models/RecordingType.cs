using System.ComponentModel.DataAnnotations;

namespace MusicCatalogueWebApp.Data.Models
{
    public enum RecordingType
    {
        /// <summary>
        /// The unknown
        /// </summary>
        [Display(Name = "Select One...")]
        Unknown,

        /// <summary>
        /// The commercial
        /// </summary>
        Commercial,

        /// <summary>
        /// The demo
        /// </summary>
        Demo,

        /// <summary>
        /// The live
        /// </summary>
        Live,

        /// <summary>
        /// The play
        /// </summary>
        Play,

        /// <summary>
        /// The radio
        /// </summary>
        Radio,

        /// <summary>
        /// The single
        /// </summary>
        Single,
    }
}
