using System;
using System.Collections.Generic;
using System.Text;

namespace Music
{
    class Album
    {
        public Album() { }
        private string title;
        private Artist artist;
        private HashSet<Track> tracks;
        public Album(string artistName)
        {
            tracks = new HashSet<Track>();
            artist = new Artist();
            artist.SetName(artistName);
        }
        public Album(string title, string artistName)
        {
            this.title = title;
            tracks = new HashSet<Track>();
            artist.SetName(artistName);
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
            track.
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
    }
}