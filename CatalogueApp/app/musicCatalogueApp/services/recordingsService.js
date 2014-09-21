'use strict';

define(['app'], function(app) {
    var RecordingsFactory = function() {

        var recordings = [
            {
                id: 1,
                title: "Miss Saigon",
                albumArtist: "Original London Cast",
                recordingDate: "1990-02-02",
                type: "Commercial",
                media: "Digital",
                performers: ["Lea Salonga", "Jonathan Pryce", "Simon Bowman", "Claire Moore", "Peter Polycarpou", "Keith Burns", "Isay Alvarez"],
                music: ["Claude-Michel Schönberg"],
                lyrics: ["Alain Boublil", "Richard Maltby Jnr."],
                coverImage: "http://ecx.images-amazon.com/images/I/51rUNeZ3ebL._PJautoripBadge,BottomRight,4,-40_OU11__.jpg"
            },
            {
                id: 2,
                title: "Miss Saigon: The Complete Recording",
                albumArtist: "Studio Cast",
                recordingDate: "2014-09-12",
                type: "Commercial",
                media: "Digital",
                performers: ["Joanna Ampil", "Kevin Gray", "Peter Cousens", "Ruthie Henshall", "Hinton Battle", "Charles Azulay", "Sonia Swaby"],
                music: ["Claude-Michel Schönberg"],
                lyrics: ["Alain Boublil", "Richard Maltby Jnr."],
                coverImage: "http://jukebox.mndp.ru/wp/wp-content/uploads/2013/11/Miss-Saigon-CD-cover.jpg"
            },
            {
                id: 3,
                title: "Les Miserables",
                albumArtist: "Original London Cast",
                recordingDate: "1986-12-31",
                type: "Commercial",
                media: "Digital",
                performers: ["Colm Wilkinson", "Patti LuPone", "Michael Ball", "Frances Ruffelle", "Alun Armstrong", "Susan Jane Tanner", "Roger Allam", "David Burt", "Rebecca Caine"],
                music: ["Claude-Michel Schönberg"],
                lyrics: ["Alain Boublil", "Herbert Kretzmer"],
                coverImage: "http://cps-static.rovicorp.com/3/JPG_400/MI0001/091/MI0001091924.jpg?partner=allrovi.com"
            },
            {
                id: 4,
                title: "Les Miserables",
                albumArtist: "Original London Cast",
                recordingDate: "1986-12-31",
                type: "Commercial",
                media: "Digital",
                performers: ["Colm Wilkinson", "Patti LuPone", "Michael Ball", "Frances Ruffelle", "Alun Armstrong", "Susan Jane Tanner", "Roger Allam", "David Burt", "Rebecca Caine"],
                music: ["Claude-Michel Schönberg"],
                lyrics: ["Alain Boublil", "Herbert Kretzmer"],
                coverImage: "http://cps-static.rovicorp.com/3/JPG_400/MI0001/091/MI0001091924.jpg?partner=allrovi.com"
            },
            {
                id: 5,
                title: "Les Miserables",
                albumArtist: "Original London Cast",
                recordingDate: "1986-12-31",
                type: "Commercial",
                media: "Digital",
                performers: ["Colm Wilkinson", "Patti LuPone", "Michael Ball", "Frances Ruffelle", "Alun Armstrong", "Susan Jane Tanner", "Roger Allam", "David Burt", "Rebecca Caine"],
                music: ["Claude-Michel Schönberg"],
                lyrics: ["Alain Boublil", "Herbert Kretzmer"],
                coverImage: "http://cps-static.rovicorp.com/3/JPG_400/MI0001/091/MI0001091924.jpg?partner=allrovi.com"
            },
            {
                id: 6,
                title: "Les Miserables",
                albumArtist: "Original London Cast",
                recordingDate: "1986-12-31",
                type: "Commercial",
                media: "Digital",
                performers: ["Colm Wilkinson", "Patti LuPone", "Michael Ball", "Frances Ruffelle", "Alun Armstrong", "Susan Jane Tanner", "Roger Allam", "David Burt", "Rebecca Caine"],
                music: ["Claude-Michel Schönberg"],
                lyrics: ["Alain Boublil", "Herbert Kretzmer"],
                coverImage: "http://cps-static.rovicorp.com/3/JPG_400/MI0001/091/MI0001091924.jpg?partner=allrovi.com"
            },
            {
                id: 7,
                title: "Les Miserables",
                albumArtist: "Original London Cast",
                recordingDate: "1986-12-31",
                type: "Commercial",
                media: "Digital",
                performers: ["Colm Wilkinson", "Patti LuPone", "Michael Ball", "Frances Ruffelle", "Alun Armstrong", "Susan Jane Tanner", "Roger Allam", "David Burt", "Rebecca Caine"],
                music: ["Claude-Michel Schönberg"],
                lyrics: ["Alain Boublil", "Herbert Kretzmer"],
                coverImage: "http://cps-static.rovicorp.com/3/JPG_400/MI0001/091/MI0001091924.jpg?partner=allrovi.com"
            }
        ];

        var factory = {};

        factory.getRecordings = function() {
            return recordings;
        }

        return factory;
    }

    app.factory('recordingsService', RecordingsFactory);
});