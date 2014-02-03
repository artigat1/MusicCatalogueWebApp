using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicCatalogueWebApp.Data.Models
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PersonId { get; set; }

        [Required]
        public string Name { get; set; }

        public PersonType Type { get; set; }
    }
}
