using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Music
{
    class Album
    {
        private string title;
        private Artist artist;
        private HashSet<Track> tracks;
        public Album() { tracks = new HashSet<Track>(); }
        public Album(string artistName)
        {
            tracks = new HashSet<Track>();
            foreach (Artist x in Artist.GetArtists())
            {
                if (artistName == x.GetName())
                {
                    artist = x;
                }
            }
            if (artist == null)
            {
                artist = new Artist(artistName);
            }
        }
        public Album(string title, string artistName)
        {
            this.title = title;
            tracks = new HashSet<Track>();
            foreach (Artist x in Artist.GetArtists())
            {
                if (artistName == x.GetName())
                {
                    artist = x;
                }
            }
            if (artist == null)
            {
                artist = new Artist(artistName);
            }
        }
        public string GetTitle()
        {
            return title;
        }
        public void SetTitle(string title)
        {
            this.title = title;
        }
        public void AddTrack(Track track)
        {
            tracks.Add(track);
            track.SetArtist(GetArtist());
            track.SetAlbum(this);
        }
        public void GetTrack()
        {
            Track[] trackNames = new Track[tracks.Count];
            tracks.CopyTo(trackNames);
            for (int i = 0; i < trackNames.Length; i++)
            {
                Console.WriteLine(trackNames[i].GetTitle() + " ");
            }
            Console.WriteLine();
            trackNames = null;
        }
        public Artist GetArtist()
        {
            return artist;
        }
    }
}