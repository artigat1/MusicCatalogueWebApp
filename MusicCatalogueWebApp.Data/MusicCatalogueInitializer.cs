using System.Collections.Generic;
using MusicCatalogueWebApp.Data.Models;

namespace MusicCatalogueWebApp.Data
{
    public class MusicCatalogueInitializer : 
        System.Data.Entity.DropCreateDatabaseIfModelChanges<MusicCatalogueContext>
    {
        protected override void Seed(MusicCatalogueContext context)
        {
            var performers = new List<Person>{
                new Person{ Name = "Ramin Karimloo" },
                new Person{ Name = "Luke Evans" },
                new Person{ Name = "Siubhan Harrison" },
                new Person{ Name = "Joanna Riding" },
                new Person{ Name = "Declan Bennett" }
            };
            performers.ForEach(p => context.People.Add(p));
            context.SaveChanges();

            var recordings = new List<Recording>{
                new Recording{
                    Title = "Les Miserables",
                    Type = RecordingType.Commercial,
                    RecordingDate = new System.DateTime(1986),
                    Music = new List<Person>{
                        new Person{ Name = "Claude-Michel Schönberg"}
                    },
                    Lyrics = new List<Person>{
                        new Person{ Name = "Alain Boubil"},
                        new Person{ Name = "Herbert Kretzmer"}
                    },
                    Media = MediaType.Digital,
                    CreatedOn = System.DateTime.Now,
                    AlbumArtist = "Original London Cast",
                    Performers = new List<Person>{
                        new Person{ Name = "Ruthie Henshall"},
                        new Person{ Name = "Michael Ball" },
                        new Person{ Name = "Colm Wilkinson" },
                        new Person{ Name = "Frances Ruffelle" }
                    }                    
                }
            };
            recordings.ForEach(r => context.Recordings.Add(r));
            context.SaveChanges();
        }
    }
}
