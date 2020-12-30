using System;
using iMusic.DataModel.Models;
using iMusic.DataModel.Repository.Interfaces;
using iMusic.DataModel.UnitOfWork;
using iMusic.Utils;

namespace iMusic
{
    public class FillMockDataDb
    {
        #region CONSTANTS
        //Music Genres
        readonly static string musicgenre_POP = "Pop";
        readonly static string musicgenre_HIPHOP = "Hip-Hop";
        readonly static string musicgenre_CLASSIC = "Classic";

        //Artists
        readonly static string artist_ARIANA_GRANDE = "Ariana Grande";
        readonly static string artist_MARIAH_CAREY = "Mariah Carey";
        readonly static string artist_EMINEM = "Eminem";
        readonly static string artist_TRAVIS_SCOTT = "Travis Scott";
        readonly static string artist_AMADEUS_MOZART = "Wolfgang Amadeus Mozart";
        readonly static string artist_FREDERIC_CHOPIN = "Frédéric Chopin";

        //Albums
        readonly static string album_THANK_U_NEXT = "thank u, next";
        readonly static string album_MERRY_CHRISTMAS = "Merry Christmas";
        readonly static string album_THE_EMINEM_SHOW = "The Eminem Show";
        readonly static string album_ASTROWORLD = "ASTROWORLD";
        #endregion

        public static void Fill()
        {
            FillUsers();
            FillMusicGenres();
            FillArtists();
            FillAlbums();
            FillSongs();
        }

        private static void FillUsers()
        {
            AddUser("zarzand", "zarzand@gmail.com", "zarzand");
        }

        private static void AddUser(string username, string email, string password)
        {
            using (var uow = new UnitOfWork())
            {
                var userRepo = uow.GetRepository<IUserRepository>();
                bool userExists;
                userExists = userRepo.GetByUsername(username) != null;
                if (!userExists)
                {
                    var newUser = new User()
                    {
                        Username = username,
                        Email = email,
                        Password = password
                    };
                    userRepo.Add(newUser);
                }

                uow.Save();
            }
        }

        private static void FillMusicGenres()
        {
            AddMusicGenre(musicgenre_POP);
            AddMusicGenre(musicgenre_HIPHOP);
            AddMusicGenre(musicgenre_CLASSIC);
        }

        private static void AddMusicGenre(string musicGenreName)
        {

            using (var uow = new UnitOfWork())
            {
                var musicGenreRepo = uow.GetRepository<IMusicGenreRepository>();
                bool musicGenreExists;
                musicGenreExists = musicGenreRepo.GetByName(musicGenreName) != null;
                if (!musicGenreExists)
                {
                    var newMusicGenre = new MusicGenre()
                    {
                        Name = musicGenreName,
                        //TODO Add image
                    };
                    musicGenreRepo.Add(newMusicGenre);
                }
                uow.Save();
            }
        }

        private static void FillArtists()
        {
            AddArtist(artist_ARIANA_GRANDE, Base64MockImages.ARIANA_GRANDE, "Ariana Grande began performing onstage when she was a child. Her involvement in a Broadway play at age 15, followed by some " +
                            "small TV parts, helped her land the role of Cat on TV's Victorious. She followed that with the spinoff Sam & Cat and then dove headfirst into a chart-topping" +
                            " musical career, releasing five albums: Yours Truly (2013), My Everything (2014), Dangerous Woman (2016), Sweetener (2018) and Thank U, Next (2019).");
            AddArtist(artist_MARIAH_CAREY, Base64MockImages.MARIAH_CAREY, "At 18 Mariah Carey signed with Columbia Records, and her first album had four No. 1 singles, including \"Vision of Love\" " +
                            "and \"I Don't Wanna Cry.\" Carey went on to generate several more albums (later with other studios) and top singles, becoming one of " +
                            "the most commercially successful artists of all time with 19 No. 1 hits and more than 200 million records sold.");
            AddArtist(artist_EMINEM, Base64MockImages.EMINEM, "Eminem is an American rapper, record producer and actor known as one of the most controversial and best-selling artists of the early 21st century." +
                            "Rapper, actor and music producer Eminem is one of the best-selling musicians of the 21st century and one of the most influential rappers of all time.");
            AddArtist(artist_TRAVIS_SCOTT, Base64MockImages.TRAVIS_SCOTT, "Jacques Bermon Webster II known professionally as Travis Scott, is an American rapper, singer, songwriter, and record producer. Scott's musical style " +
                            "has been described as a fusion of traditional hip hop, lo-fi and ambient. In 2012, Scott signed his first major-label contract with Epic Records.");
            AddArtist(artist_AMADEUS_MOZART, Base64MockImages.MOZART, "Wolfgang Amadeus Mozart, in full Johann Chrysostom Wolfgang Amadeus Mozart, baptized as Johannes Chrysostomus Wolfgangus Theophilus Mozart, (born January 27, " +
                            "1756, Salzburg, archbishopric of Salzburg [Austria]—died December 5, 1791, Vienna), Austrian composer, widely recognized as one of the greatest composers in the history of " +
                            "Western music. With Haydn and Beethoven he brought to its height the achievement of the Viennese Classical school. Unlike any other composer in musical history, he wrote " +
                            "in all the musical genres of his day and excelled in every one. His taste, his command of form, and his range of expression have made him seem the most universal of all " +
                            "composers; yet, it may also be said that his music was written to accommodate the specific tastes of particular audiences.");
            AddArtist(artist_FREDERIC_CHOPIN, Base64MockImages.CHOPIN, "Considered Poland's greatest composer, Frédéric Chopin focused his efforts on piano composition and was a strong influence on composers who followed him." +
                            "Frédéric Chopin was a renowned Polish and French composer who published his first composition at age 7 and began performing one year later. In 1832, he moved to Paris, socialized " +
                            "with high society and was known as an excellent piano teacher. His piano compositions were highly influential.");
        }

        private static void AddArtist(string artistName, string image, string artistDetailsBio)
        {
            using (var uow = new UnitOfWork())
            {
                var artistRepo = uow.GetRepository<IArtistRepository>();
                bool artistExists;

                artistExists = artistRepo.GetByName(artistName) != null;
                if (!artistExists)
                {
                    var newArtist = new Artist()
                    {
                        Name = artistName,
                        Image = Converter.GetByteArrayFromString(image),
                        ArtistDetails = new ArtistDetails()
                        {
                            Bio = artistDetailsBio
                        }
                    };
                    artistRepo.Add(newArtist);
                }

                uow.Save();
            }
        }

        private static void FillAlbums()
        {
            AddAlbum(album_THANK_U_NEXT, artist_ARIANA_GRANDE, 10.0f, Base64MockImages.THANK_U_NEXT);
            AddAlbum(album_MERRY_CHRISTMAS, artist_MARIAH_CAREY, 7.5f, Base64MockImages.MERRY_CHRISTMAS);
            AddAlbum(album_THE_EMINEM_SHOW , artist_EMINEM, 15.0f, Base64MockImages.THE_EMINEM_SHOW);
            AddAlbum(album_ASTROWORLD, artist_TRAVIS_SCOTT, 13.5f, Base64MockImages.ASTROWORLD);
        }

        private static void AddAlbum(string albumName, string artistName, float price, string image)
        {
            using (var uow = new UnitOfWork())
            {
                var albumRepo = uow.GetRepository<IAlbumRepository>();
                var artistRepo = uow.GetRepository<IArtistRepository>();
                bool albumExists;

                albumExists = albumRepo.GetByName(albumName, artistName) != null;
                if (!albumExists)
                {
                    var artist = artistRepo.GetByName(artistName);
                    var newAlbum = new Album()
                    {
                        Name = albumName,
                        Image = Converter.GetByteArrayFromString(image),
                        Price = price,
                        ArtistId = artist.ArtistId
                    };
                    albumRepo.Add(newAlbum);
                }
                uow.Save();
            }
        }

        private static void FillSongs()
        {
            AddSong("Nocturne op.9 No2", artist_FREDERIC_CHOPIN, null, musicgenre_CLASSIC, 2.99f, 6.56f, Base64MockImages.CHOPIN);
            AddSong("Eine Kleine Nachtmusik, K. 525: I. Allegro", artist_AMADEUS_MOZART, null, musicgenre_CLASSIC, 2.99f, 4.56f, Base64MockImages.MOZART);

            AddSong("imagine", artist_ARIANA_GRANDE, album_THANK_U_NEXT, musicgenre_POP, 1.00f, 2.34f, Base64MockImages.THANK_U_NEXT);
            AddSong("needy", artist_ARIANA_GRANDE, album_THANK_U_NEXT, musicgenre_POP, 1.00f, 2.34f, Base64MockImages.THANK_U_NEXT);
            AddSong("NASA", artist_ARIANA_GRANDE, album_THANK_U_NEXT, musicgenre_POP, 1.00f, 2.34f, Base64MockImages.THANK_U_NEXT);
            AddSong("bloodline", artist_ARIANA_GRANDE, album_THANK_U_NEXT, musicgenre_POP, 1.00f, 2.34f, Base64MockImages.THANK_U_NEXT);
            AddSong("fake smile", artist_ARIANA_GRANDE, album_THANK_U_NEXT, musicgenre_POP, 1.00f, 2.34f, Base64MockImages.THANK_U_NEXT);
            AddSong("bad idea", artist_ARIANA_GRANDE, album_THANK_U_NEXT, musicgenre_POP, 1.00f, 2.34f, Base64MockImages.THANK_U_NEXT);
            AddSong("make up", artist_ARIANA_GRANDE, album_THANK_U_NEXT, musicgenre_POP, 1.00f, 2.34f, Base64MockImages.THANK_U_NEXT);
            AddSong("ghostin", artist_ARIANA_GRANDE, album_THANK_U_NEXT, musicgenre_POP, 1.00f, 2.34f, Base64MockImages.THANK_U_NEXT);
            AddSong("in my head", artist_ARIANA_GRANDE, album_THANK_U_NEXT, musicgenre_POP, 1.00f, 2.34f, Base64MockImages.THANK_U_NEXT);
            AddSong("7 rings", artist_ARIANA_GRANDE, album_THANK_U_NEXT, musicgenre_POP, 1.00f, 2.34f, Base64MockImages.THANK_U_NEXT);
            AddSong("thank u, next", artist_ARIANA_GRANDE, album_THANK_U_NEXT, musicgenre_POP, 1.00f, 2.34f, Base64MockImages.THANK_U_NEXT);
            AddSong("break up with your girlfriend, i'm bored", artist_ARIANA_GRANDE, album_THANK_U_NEXT, musicgenre_POP, 1.00f, 2.34f, Base64MockImages.THANK_U_NEXT);

            AddSong("Silent Night", artist_MARIAH_CAREY, album_MERRY_CHRISTMAS, musicgenre_POP, 1.00f, 2.20f, Base64MockImages.MERRY_CHRISTMAS);
            AddSong("All I Want for Christmas Is You", artist_MARIAH_CAREY, album_MERRY_CHRISTMAS, musicgenre_POP, 1.00f, 2.20f, Base64MockImages.MERRY_CHRISTMAS);
            AddSong("O Holy Night", artist_MARIAH_CAREY, album_MERRY_CHRISTMAS, musicgenre_POP, 1.00f, 2.20f, Base64MockImages.MERRY_CHRISTMAS);
            AddSong("Christmas", artist_MARIAH_CAREY, album_MERRY_CHRISTMAS, musicgenre_POP, 1.00f, 2.20f, Base64MockImages.MERRY_CHRISTMAS);
            AddSong("Miss You Most", artist_MARIAH_CAREY, album_MERRY_CHRISTMAS, musicgenre_POP, 1.00f, 2.20f, Base64MockImages.MERRY_CHRISTMAS);
            AddSong("Joy to the World", artist_MARIAH_CAREY, album_MERRY_CHRISTMAS, musicgenre_POP, 1.00f, 2.20f, Base64MockImages.MERRY_CHRISTMAS);
            AddSong("Jesus Born on This Day", artist_MARIAH_CAREY, album_MERRY_CHRISTMAS, musicgenre_POP, 1.00f, 2.20f, Base64MockImages.MERRY_CHRISTMAS);
            AddSong("Santa Claus Is Comin'to Town", artist_MARIAH_CAREY, album_MERRY_CHRISTMAS, musicgenre_POP, 1.00f, 2.20f, Base64MockImages.MERRY_CHRISTMAS);
            AddSong("Hark!", artist_MARIAH_CAREY, album_MERRY_CHRISTMAS, musicgenre_POP, 1.00f, 2.20f, Base64MockImages.MERRY_CHRISTMAS);
            AddSong("Jesus Oh What a Wonderful Child", artist_MARIAH_CAREY, album_MERRY_CHRISTMAS, musicgenre_POP, 1.00f, 2.20f, Base64MockImages.MERRY_CHRISTMAS);

            AddSong("Curtains Up", artist_EMINEM, album_THE_EMINEM_SHOW, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.THE_EMINEM_SHOW);
            AddSong("White America", artist_EMINEM, album_THE_EMINEM_SHOW, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.THE_EMINEM_SHOW);
            AddSong("Business", artist_EMINEM, album_THE_EMINEM_SHOW, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.THE_EMINEM_SHOW);
            AddSong("Cleanin' Out My Closet", artist_EMINEM, album_THE_EMINEM_SHOW, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.THE_EMINEM_SHOW);
            AddSong("Square Dance", artist_EMINEM, album_THE_EMINEM_SHOW, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.THE_EMINEM_SHOW);
            AddSong("The Kiss", artist_EMINEM, album_THE_EMINEM_SHOW, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.THE_EMINEM_SHOW);
            AddSong("Say Goodbye Hollywood", artist_EMINEM, album_THE_EMINEM_SHOW, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.THE_EMINEM_SHOW);
            AddSong("Drips", artist_EMINEM, album_THE_EMINEM_SHOW, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.THE_EMINEM_SHOW);
            AddSong("Without Me", artist_EMINEM, album_THE_EMINEM_SHOW, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.THE_EMINEM_SHOW);
            AddSong("Paul Rosenberg", artist_EMINEM, album_THE_EMINEM_SHOW, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.THE_EMINEM_SHOW);
            AddSong("Sing for the Moment", artist_EMINEM, album_THE_EMINEM_SHOW, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.THE_EMINEM_SHOW);
            AddSong("Superman", artist_EMINEM, album_THE_EMINEM_SHOW, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.THE_EMINEM_SHOW);
            AddSong("Hailie's Song", artist_EMINEM, album_THE_EMINEM_SHOW, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.THE_EMINEM_SHOW);
            AddSong("Steve Berman", artist_EMINEM, album_THE_EMINEM_SHOW, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.THE_EMINEM_SHOW);
            AddSong("When the Music Stops", artist_EMINEM, album_THE_EMINEM_SHOW, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.THE_EMINEM_SHOW);
            AddSong("Say What You Say", artist_EMINEM, album_THE_EMINEM_SHOW, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.THE_EMINEM_SHOW);
            AddSong("'Till I Collapse", artist_EMINEM, album_THE_EMINEM_SHOW, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.THE_EMINEM_SHOW);
            AddSong("My Dad's Gone Crazy", artist_EMINEM, album_THE_EMINEM_SHOW, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.THE_EMINEM_SHOW);
            AddSong("Curtains Close", artist_EMINEM, album_THE_EMINEM_SHOW, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.THE_EMINEM_SHOW);

            AddSong("Stargazing".ToUpper(), artist_TRAVIS_SCOTT, album_ASTROWORLD, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.ASTROWORLD);
            AddSong("Carousel".ToUpper(), artist_TRAVIS_SCOTT, album_ASTROWORLD, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.ASTROWORLD);
            AddSong("Sicko Mode".ToUpper(), artist_TRAVIS_SCOTT, album_ASTROWORLD, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.ASTROWORLD);
            AddSong("R.I.P. Screw".ToUpper(), artist_TRAVIS_SCOTT, album_ASTROWORLD, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.ASTROWORLD);
            AddSong("Stop Trying to Be God".ToUpper(), artist_TRAVIS_SCOTT, album_ASTROWORLD, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.ASTROWORLD);
            AddSong("No Bystanders".ToUpper(), artist_TRAVIS_SCOTT, album_ASTROWORLD, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.ASTROWORLD);
            AddSong("Skeletons".ToUpper(), artist_TRAVIS_SCOTT, album_ASTROWORLD, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.ASTROWORLD);
            AddSong("Wake Up".ToUpper(), artist_TRAVIS_SCOTT, album_ASTROWORLD, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.ASTROWORLD);
            AddSong("5% Tint".ToUpper(), artist_TRAVIS_SCOTT, album_ASTROWORLD, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.ASTROWORLD);
            AddSong("NC-17".ToUpper(), artist_TRAVIS_SCOTT, album_ASTROWORLD, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.ASTROWORLD);
            AddSong("Astrothunder".ToUpper(), artist_TRAVIS_SCOTT, album_ASTROWORLD, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.ASTROWORLD);
            AddSong("Yosemite".ToUpper(), artist_TRAVIS_SCOTT, album_ASTROWORLD, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.ASTROWORLD);
            AddSong("Can't Say".ToUpper(), artist_TRAVIS_SCOTT, album_ASTROWORLD, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.ASTROWORLD);
            AddSong("Who? What!".ToUpper(), artist_TRAVIS_SCOTT, album_ASTROWORLD, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.ASTROWORLD);
            AddSong("Butterfly Effect".ToUpper(), artist_TRAVIS_SCOTT, album_ASTROWORLD, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.ASTROWORLD);
            AddSong("Houstonfornication".ToUpper(), artist_TRAVIS_SCOTT, album_ASTROWORLD, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.ASTROWORLD);
            AddSong("Coffee Bean".ToUpper(), artist_TRAVIS_SCOTT, album_ASTROWORLD, musicgenre_HIPHOP, 1.00f, 2.10f, Base64MockImages.ASTROWORLD);




        }

        private static void AddSong(string songName, string artistName, string albumName, string genreOfSong, float price, float length, string image)
        {
            using (var uow = new UnitOfWork())
            {
                var songRepo = uow.GetRepository<ISongRepository>();
                var artistRepo = uow.GetRepository<IArtistRepository>();
                var albumRepo = uow.GetRepository<IAlbumRepository>();
                var musicGenreRepo = uow.GetRepository<IMusicGenreRepository>();
                bool songExists;

                songExists = songRepo.GetByName(songName, artistName) != null;
                if (!songExists)
                {
                    var artist = artistRepo.GetByName(artistName);
                    var album = albumRepo.GetByName(albumName, artistName);
                    var musicGenre = musicGenreRepo.GetByName(genreOfSong);
                    var newSong = new Song()
                    {
                        Name = songName,
                        AlbumId = album != null ? (int?)album.AlbumId : null,
                        Image = Converter.GetByteArrayFromString(image),
                        Length = length,
                        Price = price
                    };
                    SongGenre songGenre = new SongGenre()
                    {
                        MusicGenre = musicGenre,
                        Song = newSong
                    };
                    musicGenre.SongGenres.Add(songGenre);

                    ArtistSong artistSong = new ArtistSong()
                    {
                        Artist = artist,
                        Song = newSong
                    };
                    artist.ArtistSongs.Add(artistSong);

                    songRepo.Add(newSong);
                }

                uow.Save();
            }
        }
    }
}
