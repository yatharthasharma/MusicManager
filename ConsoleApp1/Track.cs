using System;
using System.Collections.Generic;
using System.Text;

namespace Music
{
    public class Track
    {
        private string title;
        private Artist artist;
        private Album album;
        public Track()
        {
        }
        public Track(string title)
        {
            this.title = title;
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
            return artist.GetName();
        }
        public string GetAlbum()
        {
            return album.GetTitle();
        }
        public void SetAlbum(Album album)
        {
             this.album = album;
        }
        public void SetArtist(Artist artist)
        {
            this.artist = artist;
        }
    }
}