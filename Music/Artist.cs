
using System;
using System.Collections.Generic;
using System.Text;

namespace Music
{
    class Artist
    {
        private string name;                        // artist name
        private HashSet<Track> tracks;              // all the tracks of a particular artist
        private HashSet<Album> albums;              // albums of a particular artist
        private static HashSet<Artist> artists = new HashSet<Artist>();            // assume no two artists with the same name
        public Artist()                             // constructor - set artist name, instantiate list of tracks and albums
        {
            artists.Add(this);
            tracks = new HashSet<Track>();
            albums = new HashSet<Album>();
        }
        public Artist(string name)                  // constructor - set artist name, instantiate list of tracks and albums
        {
            artists.Add(this);
            this.name = name;
            tracks = new HashSet<Track>();
            albums = new HashSet<Album>();
        }
        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public HashSet<Track> GetTracks()
        {
            return tracks;
        }
        public HashSet<Album> GetAlbums()
        {
            return albums;
        }
        public static HashSet<Artist> GetArtists()
        {
            return artists;
        }
    }
}