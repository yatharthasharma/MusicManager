using System;
using System.Collections.Generic;
using System.Text;

namespace Music
{
    // skeleton class used to create artists, instantiate the list of tracks and albums associated with a particular artist and some elementary methods.
    public class Artist
    {
        private string name;                        // artist name
        private HashSet<Track> tracks;              // all the tracks of a particular artist
        private HashSet<Album> albums;              // albums of a particular artist
        private static HashSet<Artist> artists = new HashSet<Artist>();            // to keep track of all the artists - assume no two artists have the same name.

        /* public Artist()                             // constructor - set artist name, instantiate list of tracks and albums, only used while testing.
        {
            artists.Add(this);
            tracks = new HashSet<Track>();
            albums = new HashSet<Album>();
        }*/

        public Artist(string name)                  // constructor - set artist name, instantiate list of tracks and albums
        {
            artists.Add(this);
            this.name = name;
            // when creating a new artist, automatically instantiate its list of tracks and albums.
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
        public static HashSet<Artist> GetArtists()      // get list of all the artists. // static because the list is same for all the objects of this class.
        {
            return artists;
        }
    }
}