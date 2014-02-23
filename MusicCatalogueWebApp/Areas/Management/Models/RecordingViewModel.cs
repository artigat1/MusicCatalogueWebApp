using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicCatalogueWebApp.Data.Models;

namespace MusicCatalogueWebApp.Areas.Management.Models
{
    public class RecordingViewModel
    {
        public Recording Recording { get; set; }

        public ICollection<Person> Performers { get; set; }
    }
}