using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Music
{
    /// <summary>
    /// skeleton class used to create albums, instantiate the list of tracks and all other fields associated with a particular album. 
    /// </summary>
    public class Album
    {
        private string title;
        private Artist artist;                                  // assume only one artist contributes to an album
        private HashSet<Track> tracks;                          // assume no duplicates or two tracks of the same name
        // the two following constructors were just used during the initial phase of testing - no use in the final program.
        //public Album() { tracks = new HashSet<Track>(); }
        /*public Album(string artistName)
        {
            tracks = new HashSet<Track>();
            foreach (Artist x in Artist.GetArtists())
            {
                if (artistName == x.GetName())
                {
                    artist = x;
                    break;
                }
            }
            if (artist == null)
            {
                artist = new Artist(artistName);
            }
        }*/
        // constructor which when given album name and artist name creates a new album and its set of tracks, and assigns it to a new or an existing artist.
        public Album(string title, string artistName)
        {
            this.title = title;
            tracks = new HashSet<Track>();                  // new set of tracks for each album object
            foreach (Artist x in Artist.GetArtists())       // iterate through the static list of artists to see if the artist given already exists,
            {                                               // (that is, this specific artist already has some albums, or not.) If it does exist, assign the new   
                if (artistName == x.GetName())              // album to it. 
                {
                    artist = x;
                    artist.AddAlbum(this);
                    break;
                }
            }
            if (artist == null)                             // If not, create a new artist and assign the album to it.
            {
                artist = new Artist(artistName);
                artist.AddAlbum(this);
            }
        }
        // getter/setter of album title.
        public string GetTitle()
        {
            return title;
        }
        public void SetTitle(string title)
        {
            this.title = title;
        }
        // add track to the album by adding it to the list of tracks and setting the artist of the track.
        public void AddTrack(Track track)
        {
            tracks.Add(track);
            track.SetArtist(GetArtist());
            track.SetAlbum(this);
        }
        // get names of tracks which are in a specific album
        public void GetTrack()
        {
            // copy the contents of set of tracks to an array so we can easily iterate through it.
            Track[] trackTempArray = new Track[tracks.Count];
            tracks.CopyTo(trackTempArray);
            for (int i = 0; i < trackTempArray.Length; i++)
            {
                Console.WriteLine(trackTempArray[i].GetTitle() + " ");
            }
            Console.WriteLine();
            trackTempArray = null;
        }
        // getter for artist
        public Artist GetArtist()
        {
            return artist;
        }
    }
}