using System;
using System.Collections.Generic;
using System.Text;

namespace Music
{
    // skeleton class used to create artists, instantiate the list of tracks and albums associated with a particular artist and some elementary methods.
    public class Artist
    {
        private string name;                                                        // artist name
        private HashSet<Track> tracks;                                              // all the tracks of a particular artist (no duplicates)
        private HashSet<Album> albums;                                              // albums of a particular artist (no duplicates)
        private static HashSet<Artist> artists = new HashSet<Artist>();             // to keep track of all the artists - no two artists have the same name.

        /* public Artist()                          // constructor - set artist name, instantiate list of tracks and albums, only used while testing.
        {
            artists.Add(this);
            tracks = new HashSet<Track>();
            albums = new HashSet<Album>();
        }*/

        public Artist(string name)                  // constructor - set artist name, instantiate list of tracks and albums
        {
            artists.Add(this);                      // add the new artist created to the static list of all the artists.
            this.name = name;                       // set name

            // when creating a new artist, automatically instantiate its list of tracks and albums.
            tracks = new HashSet<Track>();          
            albums = new HashSet<Album>();
        }
        // getters and setters for different private fields.
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
        public void AddAlbum(Album album)
        {
            albums.Add(album);
        }
        public HashSet<Album> GetAlbums()
        {
            return albums;
        }
        public static HashSet<Artist> GetArtists()      // get list of all the artists. // static because the list is same for all the objects of this class.
        {
            return artists;
        }
        public static Artist GetArtistByName(string name)   // this method is used when we need to add track to a specific artist - use this method
        {                                                   // to get the artist by its name. - used in MusicBot.Dialogs.SimpleLUISDialog class.
            foreach (Artist x in artists)
            {
                if (name == x.GetName())
                {
                    return x;
                }
            }
            return null;
        }
    }
}