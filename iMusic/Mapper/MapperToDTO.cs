using System;
using System.Collections.Generic;
using System.Linq;
using iMusic.DataModel.Models;
using iMusic.Dto.Model;
using iMusic.Utils;

namespace iMusic.Mapper
{
    public class MapperToDTO
    {
        public static List<SongDTO> Convert(List<Song> songs)
        {
            List<SongDTO> songDTOs = new List<SongDTO>();
            songs.ForEach(p => songDTOs.Add(Convert(p)));
            return songDTOs;
        }

        public static SongDTO Convert(Song song)
        {
            var songDTO = new SongDTO()
            {
                SongId = song.SongId,
                Name = song.Name,
                Length = song.Length.ToString().Replace(".",":"),
                Price = song.Price,
                Image = Converter.GetStringFromByteArray(song.Image),
                Artists = Convert(GetArtistsFromArtistsSongs(song.ArtistSongs.ToList()))
            };
            return songDTO;
        }

        public static List<ArtistDTO> Convert(List<Artist> artists)
        {
            List<ArtistDTO> artistDTOs = new List<ArtistDTO>();
            artists.ForEach(p => artistDTOs.Add(Convert(p)));
            return artistDTOs;
        }

        public static ArtistDTO Convert(Artist artist)
        {
            var artistDTO = new ArtistDTO()
            {
                ArtistId = artist.ArtistId,
                Name = artist.Name,
                Image = Converter.GetStringFromByteArray(artist.Image),
                Bio = artist.ArtistDetails != null ? artist.ArtistDetails.Bio : String.Empty
            };
            return artistDTO;
        }

        private static List<Artist> GetArtistsFromArtistsSongs(List<ArtistSong> artistSongs)
        {
            List<Artist> artists = new List<Artist>();
            artistSongs.ForEach(p => artists.Add(p.Artist));
            return artists;
        }
    }
}
