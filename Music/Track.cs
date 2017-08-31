using System;
using System.Collections.Generic;
using System.Text;

namespace Music
{
    class Track
    {
        private string title;
        private Artist artist;
        private Album album;
        public Track()
        {
            artist = new Artist();
            album = new Album();
        }
        public Track(string title)
        {
            this.title = title;
            artist = new Artist();
            album = new Album();
        }
        public string GetTitle()
        {
            return title;
        }
        public void SetTitle(string title)
        {
            this.title = title;
        }
        public string GetArtist()
        {
            return this.artist.GetName();
        }
        public string GetAlbum()
        {
            return this.album.GetTitle();
        }
        public string SetAlbum()
        {
             = album;
        }
        public string GetArtist()
        {
            return this.artist.GetName();
        }
    }
}