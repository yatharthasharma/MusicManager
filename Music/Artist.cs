
using System;
using System.Collections.Generic;
using System.Text;

namespace Music
{
    class Artist
    {
        private string name;                        // artist name
        private HashSet<Track> tracks;                 // all the tracks of a particular artist
        private HashSet<Album> albums;                 // albums of a particular artist
        public Artist()                             // constructor - set artist name, instantiate list of tracks and albums
        {
            tracks = new HashSet<Track>();
            albums = new HashSet<Album>();
        }
        public Artist(string name)                             // constructor - set artist name, instantiate list of tracks and albums
        {
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
    }
}